using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ok_Btn : MonoBehaviour
{
    public GameObject StoryBoardUi;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void Ok()
    {
        StoryBoardUi.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Ok();
        }
    }
}
