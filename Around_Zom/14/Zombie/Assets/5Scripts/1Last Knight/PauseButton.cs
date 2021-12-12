using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject PausePopUp;

    // Start is called before the first frame update
    void Start()
    {
        PausePopUp.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PausePopUp.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PausePopUp.SetActive(false);
    }
}


