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

    // Start is called before the first frame update
    void Start()
    {
        PlayerAni = gameObject.GetComponentInChildren<Animator>();
        AttackArea = GetComponentInChildren<AttackAreaScript>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveMotion();
    }

    private void MoveMotion()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            PlayerAni.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAni.SetTrigger("Roll");
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
}
