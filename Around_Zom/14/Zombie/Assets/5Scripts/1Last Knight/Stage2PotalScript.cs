using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2PotalScript : MonoBehaviour
{
    public Transform SpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.SendMessage("Warp", SpawnPos.position);//Knight_Moving 스크립트에 있는 워프를 사용해라!
        }
    }
}
