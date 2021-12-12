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

    // Start is called before the first frame update
    void Start()
    {
        Spawner = FindObjectsOfType<EnemySpawnerScript>();
        ActiveCount = Random.Range(1, 5); //Spawn포인트가 5개이므로
    }

    // Update is called once per frame
    void Update()
    {
        if (!once && ActiveCount == curActiveCount)
        {
            once = true;
            Instantiate(Key, KeySpawnPos.position, KeySpawnPos.rotation); //키 소환 위치와 방향
        }
    }

    public void updateKeySpawnPos(Transform pos)
    {
        KeySpawnPos = pos;
    }

    public void Activated() // 활성화된 스포너 개수 체크 함수
    {
        curActiveCount++;
    }
}
