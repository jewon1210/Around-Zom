using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Btn : MonoBehaviour
{
    public GameObject PauseUi;
    // Start is called before the first frame update
    void Start()
    {
        PauseUi.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale=0;
        PauseUi.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        PauseUi.SetActive(false);
    }

    public void OutHome()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
}
