using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalScript : MonoBehaviour
{
    public GameObject EnteranceBoard; //입구 보드 찾기

    // Start is called before the first frame update
    void Start()
    {
        EnteranceBoard.SetActive(false);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EnteranceBoard.SetActive(true);
        }
    }
}
