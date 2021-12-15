using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public int Hp = 100;
    public int MaxHp = 100;
    public int Power = 10;
    bool Died = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        Debug.Log("Damaged!");
        Hp -= damage;
        if(Hp<=0)
        {
            Hp = 0;
            Died = true;
        }
    }

    public void Healing()
    {
        Hp += (int)(MaxHp * 0.3f);

        if(Hp >= MaxHp)
        {
            Hp = MaxHp;
        }
    }
}