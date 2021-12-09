using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Moving : MonoBehaviour
{
    public enum State {
    Standing = 0,
    Walking,
    Running,
    Jump,
    One_Hand_Attack,
    Death,
    Total
    }

    Animator PlayerAni; // walking wasd // running shift / jump space bar / one hand attack mouse left click / kick v
    Ray cameraRay;
    public float Speed = 5.0f;
    Rigidbody rid;

    // Start is called before the first frame update
    void Start()
    {
        rid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스를 통한 캐릭터 시점 이동
        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (GroupPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointTolook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));
        }
        PlayerMove();
    }

    void PlayerMove()
    {
        float Horizon = Input.GetAxis("Horizontal");
        float Verti = Input.GetAxis("Vertical");
        float FallSpeed = rid.velocity.y;
        Vector3 Velocity = new Vector3(Horizon, 0, Verti);
        Velocity *= Speed;
        Velocity.y = FallSpeed; //중력에 의해 떨어지는 속도까지 구하는 식
        rid.velocity = Velocity; // 속도 구하는 식
    }

















    }
