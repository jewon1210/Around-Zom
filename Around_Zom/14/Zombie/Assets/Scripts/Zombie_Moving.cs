using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_Moving : MonoBehaviour
{
    public NavMeshAgent AI;
    public Transform PlayerTrans;//플레이어 위치 변수
    Animator ZombieAni;

    // Start is called before the first frame update
    void Start()
    {
        AI = gameObject.GetComponent<NavMeshAgent>();//초기화
        ZombieAni = gameObject.GetComponent<Animator>();//초기화
        AI.destination = PlayerTrans.position;//ai로 플레이어한테 걸어가게 하는 코드
        ZombieAni.SetBool("IsTracing", true);
    }

    // Update is called once per frame
    void Update()
    {
        float SaveDistance= Vector3.Distance(gameObject.transform.position,PlayerTrans.position);//거리저장
        ZombieAni.SetFloat("Attack_Range",SaveDistance);//애니메이터에 계속 거리 알려주는 역할
        if(SaveDistance<=1.5f)
        {
            ZombieAni.SetBool("IsCanRun", true);
            AI.speed = 0.0f;
        }

        if (SaveDistance>1.5f && ZombieAni.GetBool("IsCanRun") == true)
        {
            AI.speed = 5.5f;
            AI.destination = PlayerTrans.position;
        }
        else if (SaveDistance > 1.5f && ZombieAni.GetBool("IsCanRun") == false)
        {
            AI.speed = 3.0f;
            AI.destination = PlayerTrans.position;
        }

    }
}
