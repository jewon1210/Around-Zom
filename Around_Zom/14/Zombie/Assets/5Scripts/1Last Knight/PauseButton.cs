using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject PausePopUp;
    Knight_Moving player;// 퍼즈 버튼 눌렀을 때 시점 변환도 안되게 하기 위해 추가


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Knight_Moving>();
        PausePopUp.SetActive(false);
        Time.timeScale = 0;

        player.isPaused();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PausePopUp.SetActive(true);
        player.isPaused();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PausePopUp.SetActive(false);
        player.isResume();
    }
}


