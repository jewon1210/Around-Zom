using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending_Time : MonoBehaviour
{
    public GameObject[] TimeText;
    public GameObject HomeButton;
    public float TimeCheck=3.5f;
    public bool Timegoing=false;//타임 흐르는거 체크

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timegoing)
        {
            TimeCheck -= Time.deltaTime;
            if (TimeCheck >= 3)
            {
                TimeTextControl(3);
            }

            if (TimeCheck >= 2 && TimeCheck < 3)
            {
                TimeTextControl(2);
            }

            if (TimeCheck >= 1 && TimeCheck < 2)
            {
                TimeTextControl(1);
            }

            if (TimeCheck >= 0 && TimeCheck < 1)
            {
                TimeTextControl(0);
            }
        }

    }

    public void TimeTextControl(int CountDown)
    {
        switch (CountDown)
        {
            case 3 :
                TimeText[0].SetActive(true);
                break;

            case 2 :
                TimeText[1].SetActive(true);
                TimeText[0].SetActive(false);
                break;

            case 1:
                TimeText[2].SetActive(true);
                TimeText[1].SetActive(false);
                break;

            case 0:
                TimeText[3].SetActive(true);
                TimeText[2].SetActive(false);
                break;
        }
    }

    public void TimeGoingStart()
    {
        HomeButton.SetActive(false);
        Timegoing = true;
    }
}