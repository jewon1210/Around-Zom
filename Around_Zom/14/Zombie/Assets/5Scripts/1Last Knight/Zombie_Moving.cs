using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_Moving : MonoBehaviour
{
    public CharacterStatus Status;

    public NavMeshAgent AI;
    public Transform PlayerTrans;//플레이어 위치 변수
    Animator ZombieAni;
    AttackAreaScript AttackArea;
    bool isAttack = false;

    void Start()
    {
        PlayerTrans = GameObject.FindWithTag("Player").GetComponent<Transform>();
        AI = gameObject.GetComponent<NavMeshAgent>();//초기화
        ZombieAni = gameObject.GetComponent<Animator>();//초기화
        AI.destination = PlayerTrans.position;//ai로 플레이어한테 걸어가게 하는 코드
        ZombieAni.SetBool("IsTracing", true);
        AttackArea = GetComponentInChildren<AttackAreaScript>();

        Status = gameObject.GetComponent<CharacterStatus>();

    }

    void Update()
    {
        if(Status.Hp <= 0)
        {
            //CapsuleCollider collider = gameObject.GetComponent<CapsuleCollider>();
            //collider.enabled = false;
            ZombieAni.SetBool("Dead", true);
            return;
        }


        float SaveDistance = Vector3.Distance(gameObject.transform.position, PlayerTrans.position);//거리저장

        if (SaveDistance <= 1.2f)
        {
            ZombieAni.SetBool("IsCanRun", true);
            AI.speed = 0.0f;
            AI.enabled = false;//몹 충돌을 위한 네브 매쉬 오프
            transform.LookAt(PlayerTrans.position); // 공격 중 플레이어를 쳐다보게하는 부분
            isAttack = true;
            ZombieAni.SetTrigger("Attack");
            ZombieAni.SetInteger("State", 3);
        }

        if (SaveDistance > 1.2f && !isAttack)
        {
            AI.destination = PlayerTrans.position;

            if (ZombieAni.GetBool("IsCanRun"))
            {
                AI.speed = 4.5f;
                ZombieAni.SetInteger("State", 2);
            }
            else if (!ZombieAni.GetBool("IsCanRun"))
            {
                AI.speed = 2.0f;
                ZombieAni.SetInteger("State", 1);
            }
        }
    }

    public void StartAttack()
    {
        //Debug.Log("Start");
    }

    public void AttackHit()
    {
        //Debug.Log("Hit");
        AttackArea.ColliderActive();
    }

    public void AttackEnd()
    {
        //Debug.Log("End");
        AI.enabled = true;
        isAttack = false;
        AttackArea.ColliderInactive();
    }

    public void MobStartDead()
    {
        SphereCollider collider = GetComponentInChildren<SphereCollider>();
        collider.enabled = false;
    }

    public void MobDead()
    {
        KeyManager Key = FindObjectOfType<KeyManager>();
        
        if(Key != null)
        {
            Debug.Log("Key");
            Key.SendMessage("MobDead");
            Destroy(gameObject);
        }
    }
}