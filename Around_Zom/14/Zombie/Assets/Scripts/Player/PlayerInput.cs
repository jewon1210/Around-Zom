using UnityEngine;
using System.Collections;

// 플레이어 캐릭터를 조작하기 위한 사용자 입력을 감지
// 감지된 입력값을 다른 컴포넌트들이 사용할 수 있도록 제공

public class PlayerInput : MonoBehaviour {
    Ray cameraRay;
    bool OnOff;
    LivingEntity Dead;
    GameObject CamON;
    GameObject Aim;
    Quaternion quaternion;
    public GameObject GrenadaPrefab;

    float turnSpeed = 150f;

    public string moveAxisName = "Vertical"; // 앞뒤 움직임을 위한 입력축 이름
    //public string rotateAxisName = "Horizontal"; // 좌우 회전을 위한 입력축 이름
    public string fireButtonName = "Fire1"; // 발사를 위한 입력 버튼 이름
    public string reloadButtonName = "Reload"; // 재장전을 위한 입력 버튼 이름
    
   

    // 값 할당은 내부에서만 가능
    public float move { get; private set; } // 감지된 움직임 입력값
    //public float rotate { get; private set; } // 감지된 회전 입력값
    public bool fire { get; private set; } // 감지된 발사 입력값
    public bool reload { get; private set; } // 감지된 재장전 입력값
    public bool Throw { get; private set; }

    private void Start()
    {
        quaternion = Quaternion.identity;
        OnOff = false;
        CamON = GameObject.Find("Player Character");
        Dead = CamON.GetComponent<LivingEntity>();
        Aim = GameObject.Find("Aim_Img");
    }

    public void ChangeOn()
    {
        if (OnOff)
        {
            OnOff = false;
        }
        else
            OnOff = true;
    }
    // 매프레임 사용자 입력을 감지
    private void Update() {
        //if (Dead.dead == true)
        //{
        //    return;
        //}
        float h = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.LeftBracket))
        {
            turnSpeed -= 10f;
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            turnSpeed += 10f;
        }

        if (OnOff)//3인칭일때 움직임
        {
            Aim.SetActive(false);
            Cursor.visible = true;
            cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (GroupPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointTolook = cameraRay.GetPoint(rayLength);
                transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));
            }
        }

        else if(!OnOff)//1인칭일때 움직임
        {
            Aim.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            transform.Rotate(0f, h * turnSpeed * Time.deltaTime, 0f);          
        }



        // 게임오버 상태에서는 사용자 입력을 감지하지 않는다
        if (GameManager.instance != null && GameManager.instance.isGameover)
        {
            move = 0;
            //rotate = 0;
            Throw = false;
            fire = false;
            reload = false;
            Cursor.visible = true;
            return;
        }


        // move에 관한 입력 감지
        move = Input.GetAxis(moveAxisName);
        // rotate에 관한 입력 감지
        //rotate = Input.GetAxis(rotateAxisName);
        // fire에 관한 입력 감지
        fire = Input.GetButton(fireButtonName);
        // reload에 관한 입력 감지
        reload = Input.GetButtonDown(reloadButtonName);
        Throw = Input.GetKeyDown(KeyCode.Alpha4);
    }
}