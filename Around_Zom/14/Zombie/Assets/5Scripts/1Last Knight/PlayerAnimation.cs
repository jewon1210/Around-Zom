using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public enum State
    {
        Standing = 0,
        Walking,
        BackWalking,
        Running,
        Rolling,
        One_Hand_Attack,
        Death,

        Total
    }

    Animator PlayerAni;
    AttackAreaScript AttackArea;
    CharacterStatus Status;//죽는 모션을 위한 추가
    public GameObject DyingPopUp;//죽고나서 뜨는 팝업
    public GameObject HitArea;
    Collider HitCollider;
    public ParticleSystem QSkill;
    public Knight_Moving KnightMoving;
    float CoolTime = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAni = gameObject.GetComponentInChildren<Animator>();
        AttackArea = GetComponentInChildren<AttackAreaScript>();
        Status = transform.root.GetComponent<CharacterStatus>();
        DyingPopUp.SetActive(false);
        HitCollider = HitArea.GetComponent<Collider>();
        KnightMoving = transform.root.GetComponent<Knight_Moving>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Status.Hp <=0)
        {
            PlayerAni.SetBool("Dead", true);
            return;
        }

        MoveMotion();
    }

    private void MoveMotion()
    {
        CoolTime += Time.deltaTime;

        if(Input.GetButtonDown("Fire1"))
        {
            PlayerAni.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAni.SetTrigger("Roll");
        }

        if (Input.GetKeyDown(KeyCode.Q) && CoolTime >= 7.0f)
        {
            PlayerAni.SetTrigger("QSkill");
            CoolTime = 0;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                PlayerAni.SetTrigger("StartRun");
                PlayerAni.SetInteger("State", (int)State.Running);// 확실하게 찾게!
            }

            else
            {
                PlayerAni.SetInteger("State", (int)State.Walking);
            }
        }

        else if (Input.GetKey(KeyCode.S))
        {
            PlayerAni.SetInteger("State", (int)State.BackWalking);
        }

        else
        {
            PlayerAni.SetInteger("State", (int)State.Standing);
        }
    }

    public void StartAttack()
    {

    }

    public void AttackHit()
    {
        AttackArea.ColliderActive();
    }

    public void AttackEnd()
    {
        AttackArea.ColliderInactive();
    }

    public void PlayerDead()
    {
        DyingPopUp.SetActive(true);
    }

    public void QSkillStart()
    {
        QSkill.Play();
        HitCollider.enabled = false;
    }

    public void QSkillEnd()
    {
        KnightMoving.isQSkillOff();
        Status.Healing();
        HitCollider.enabled = true;
    }

}
