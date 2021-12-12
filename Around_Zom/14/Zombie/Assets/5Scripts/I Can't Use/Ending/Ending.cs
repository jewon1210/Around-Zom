using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    float dis;//딸과 엄마와의 거리
    public GameObject EndingUi;
    public Transform Daughter_pos;
    public Transform Mother_pos;

    // Start is called before the first frame update
    void Start()
    {
        dis = 0;
        EndingUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(Daughter_pos.position,Mother_pos.position);
        if(dis <= 1f)
        {
            EndingUi.SetActive(true);
            StartCoroutine(Delay_time()); // 5초동안 딜레이
        }
    }

    IEnumerator Delay_time()
    {
        yield return new WaitForSeconds(5.0f);
        //Scene_Manager.control.Go_Home();
    }
}
