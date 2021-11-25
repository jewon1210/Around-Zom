using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    GameObject CamON;
    PlayerInput Inp;
    FPSCam_S Camcam;

    public Camera[] arrCam;

    int nCamCount = 2;
    int nNowCam = 1;

    // Start is called before the first frame update
    void Start()
    {
        CamON = GameObject.Find("Player Character");
        Inp = CamON.GetComponent<PlayerInput>();
        CamON = GameObject.Find("FPS Cam");
        Camcam = CamON.GetComponent<FPSCam_S>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Inp.ChangeOn();
            Camcam.ChangeMotion();

            ++nNowCam;

            if(nNowCam>=nCamCount)
            {
                nNowCam = 0;
            }

            for(int i=0; i<arrCam.Length;i++)
            {
                arrCam[i].enabled = (i == nNowCam);
            }
        }
    }
}
