using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAreaScript : MonoBehaviour
{
    void Hitted(int Damage)//AttackArea로부터 메시지를 받고 그 값은 대미지 값이야라고 알려주며, 실행
    {
        transform.root.SendMessage("Damage", Damage);
        Debug.Log("Hitted: " + Damage);
    }
}
