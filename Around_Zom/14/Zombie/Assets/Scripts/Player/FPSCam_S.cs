using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCam_S : MonoBehaviour
{    
    public float rotSpeed = 3.0f;
    bool OnMotion;
    public Camera fpsCam;
    
    // Start is called before the first frame update
    void Start()
    {
        OnMotion = true;
    }

    public void ChangeMotion()
    {
        if (OnMotion)
        {
            OnMotion = false;
        }
        else
            OnMotion = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (OnMotion)
        {
           
            //RotCtrl();
            //Cursor.visible = false;                     //마우스 커서가 보이지 않게 함
            // Cursor.lockState = CursorLockMode.Locked;   //마우스 커서를 고정시킴
        }
    }

    
}
