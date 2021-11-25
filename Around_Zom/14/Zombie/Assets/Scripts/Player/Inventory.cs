using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int HealthCount=0;//item개수 세는 변수
    public int AmmoCount=0;//item개수 세는 변수
    public LivingEntity Health;
    public float health = 50;
    public Text HealthPackCountTxT;
    public Image HealthPackImg;
    public Text GrenadaCounttxt;
    public Image GrenadaImg;
    public Gun gun;


    private void Start()
    {
        Health = gameObject.GetComponent<LivingEntity>();
        HealthCount = Scene_Manager.control.KnowingHpPackCount();
        CountHealthPack();
        GetCountGrenada();
    }

    public void UsingHealthPack()
    {
        Health.RestoreHealth(health);
        DecreaseHealthCount();
        Scene_Manager.control.UserDB_HealthPack(HealthCount);
    }

    private void Update()
    {
        if(HealthCount > 0)
        {
            if(Input.GetKeyDown(KeyCode.Q)) //헬스팩이 0개보다 많을때, 큐 누르면 사용되는 함수
            {
                UsingHealthPack();
                CountHealthPack();
            }
        }
        if(HealthCount <= 0)
        {
            HealthPackImg.color = Color.black;
        }
        if(HealthCount >= 1)
        {
            HealthPackImg.color = Color.red;
        }

        if (gun.GetCountGrenadaNum() <= 0)
        {
            GrenadaImg.color = Color.black;
        }
        if (gun.GetCountGrenadaNum() >= 1)
        {
            GrenadaImg.color = Color.white;
        }
        GetCountGrenada();
    }


    public void IncreaseHealthCount()
    {
        HealthCount++;
        Scene_Manager.control.UserDB_HealthPack(HealthCount);
    }

    public void IncreaseAmmoCount()
    {
        AmmoCount++;
    }

    public void DecreaseHealthCount()
    {
        HealthCount--;
        Scene_Manager.control.UserDB_HealthPack(HealthCount);
    }

    public void DecreaseAmmoCount()
    {
        AmmoCount--;
    }

    public void CountHealthPack()
    {
        HealthPackCountTxT.text = 'x' + HealthCount.ToString();
    }

    public void GetCountGrenada()
    {
        GrenadaCounttxt.text = 'x' + gun.GetCountGrenadaNum().ToString();
    }


}