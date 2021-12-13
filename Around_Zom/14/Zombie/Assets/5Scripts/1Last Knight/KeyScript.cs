using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    KeyManager KeyManager;
    public GameObject KeyEquipPopUp;

    // Start is called before the first frame update
    void Start()
    {
        KeyManager = FindObjectOfType<KeyManager>(); //key찾기
        KeyEquipPopUp.SetActive(false); //획득 시 팝업 꺼두기
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            KeyEquipPopUp.SetActive(true); //획득 팝업 켜기
            KeyManager.PotalOpen();
            Destroy(gameObject); //획득한 열쇠 삭제
        }
    }
}
