using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Delay_Ending()
    {
        yield return new WaitForSeconds(3.5f);
        //Scene_Manager.control.Go_Home();
    }

    public void Click_Clear()
    {
        StartCoroutine(Delay_Ending());
    }
}
