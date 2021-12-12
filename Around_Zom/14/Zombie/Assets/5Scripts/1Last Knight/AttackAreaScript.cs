using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaScript : MonoBehaviour
{
    public CharacterStatus Status;
    public Collider AttackArea;

    // Start is called before the first frame update
    void Start()
    {
        Status = transform.root.GetComponent<CharacterStatus>();
        AttackArea = gameObject.GetComponent<Collider>();
        AttackArea.enabled = false; //그냥 닿아도 대미지 들어가는 것을 방지
    }

    private void OnTriggerEnter(Collider other)//콜라이더가 어딘가에 닿았을 때 피격대상에게 메시지를 보냄
    {
        other.SendMessage("Hitted", Status.Power);//other는 부딪힌 콜라이더
        Debug.Log("Attack: " + Status.Power);
    }

    public void ColliderActive()
    {
        AttackArea.enabled = true;
    }

    public void ColliderInactive()
    {
        AttackArea.enabled = false;
    }
}