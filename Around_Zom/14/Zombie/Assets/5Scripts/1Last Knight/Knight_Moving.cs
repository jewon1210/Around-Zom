using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Moving : MonoBehaviour
{
    Ray cameraRay;
    public float Speed = 2.5f;

    CharacterStatus Status;
    CharacterController Controller;
    Vector3 dir = Vector3.zero;
    //public GameObject Died; //죽었을때 팝업창->PlayerAnimation으로 이동

    bool isRolling = false;
    bool isAttack = false;
    bool isPause = false;
    float timecheck = 0;


   

    // Start is called before the first frame update
    void Start()
    {
        Controller = gameObject.GetComponent<CharacterController>();//초기화
        Status = gameObject.GetComponent<CharacterStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Status.Hp <=0f)
        {
            //Died.SetActive(true); PlayerAnimation 스크립트로 이동
            return;
        }

        if (!isPause)
        {
            if (!isAttack)
            {
                if (!isRolling) // 구르지 않거나, 공격하지 않을때만 시점이동 가능하게 구현
                {
                    Cursor.visible = true;
                    cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스를 통한 캐릭터 시점 이동
                    Plane GroupPlane = new Plane(Vector3.up, gameObject.transform.position);
                    float rayLength;

                    if (GroupPlane.Raycast(cameraRay, out rayLength))
                    {
                        Vector3 pointTolook = cameraRay.GetPoint(rayLength);
                        transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));
                    }
                }
            }
        }

        Moving();
    }

    void Moving()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isAttack = true;
            timecheck = 0;
        }

        timecheck += Time.deltaTime;//frame초단위로

        if (!isAttack)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.LeftShift))//달리기
                {
                    Speed = 4f;

                }
                else
                {
                    Speed = 2.5f;
                }
            }

            if (Controller.isGrounded && !isRolling)//땅에 닿아있고, 구르는 상태 아닐때
            {
                dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //입력값을 통해 방향 알아오기
                dir = transform.TransformDirection(dir); //로컬좌표에서 월드좌표로(에셋이 방향이 변한다 한들 xyz그대로)

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Speed = 6;
                    dir = dir.normalized * Speed;//방향과 속도를 알아옴
                    isRolling = true;
                    timecheck = 0;
                }
                else
                    dir = dir.normalized * Speed;
            }

            dir.y -= 100 * Time.deltaTime;//중력 구현
            Controller.Move(dir * Time.deltaTime);

            if (timecheck >= 1.0f && isRolling) // 구르기 동작의 초기화  
            {
                Speed = 0;
                isRolling = false;
            }
        }

        else if (timecheck >= 1f && isAttack)//공격 시 다른 행동 안되게
        {
         isAttack = false;
        }        
    }

    public void isPaused()
    {
        isPause = true;
    }

    public void isResume()
    {
        isPause = false;
    }
}