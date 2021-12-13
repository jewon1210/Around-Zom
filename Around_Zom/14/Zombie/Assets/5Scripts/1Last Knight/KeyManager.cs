using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public EnemySpawnerScript[] Spawner;
    public GameObject Key;
    public Transform KeySpawnPos;
    public int ActiveCount;
    public int curActiveCount = 0;
    bool once = false;

    public int MobCount = 0;//몬스터수 초기화
    public GameObject Potal;//포탈나타나게

    // Start is called before the first frame update
    void Start()
    {
        Spawner = FindObjectsOfType<EnemySpawnerScript>();
        ActiveCount = Random.Range(1, 5); //Spawn포인트가 5개이므로

        Potal.SetActive(false);
        Key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!once && ActiveCount <= curActiveCount && MobCount == 0)
        {
            once = true;

            Key.SetActive(true);
            Key.transform.position = KeySpawnPos.position; //키 소환 위치와 방향
        }
    }

    public void updateKeySpawnPos(Transform pos)
    {
        KeySpawnPos = pos;
        Key.transform.position = KeySpawnPos.position;
    }

    public void Activated() // 활성화된 스포너 개수 체크 함수
    {
        curActiveCount++;
        int SaveMobCounts = MobCount;//몹 카운트를 저장할 변수
        Zombie_Moving[] Mobs = FindObjectsOfType<Zombie_Moving>();//몹의 개수 찾기

        foreach(Zombie_Moving Mob in Mobs)//찾은만큼 카운트하기
        {
            MobCount++;
        }
        MobCount -= SaveMobCounts;
    }

    public void MobDead()
    {
        MobCount--;
    }

    public void PotalOpen()
    {
        Potal.SetActive(true);
    }
}
