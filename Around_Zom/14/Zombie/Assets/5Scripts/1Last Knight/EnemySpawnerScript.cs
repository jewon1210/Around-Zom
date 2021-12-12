using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    KeyManager Manager;
    public GameObject EnemyObj; //소환할 오브젝트
    public Transform SpawnPos;// 소환할 위치
    public int SpawnCount = 3; // 소환할 횟수
    public Transform PlayerTrans;

    bool once = false;

    // Start is called before the first frame update
    void Start()
    {
        Manager = FindObjectOfType<KeyManager>();
        PlayerTrans = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(PlayerTrans.position, gameObject.transform.position) <= 1.5f && Input.GetKeyDown(KeyCode.T) && !once)
        {
            once = true;
            Spawn();
        }
    }

    public void Spawn()
    {
        for(int i = 0; i < SpawnCount; i++)
        {
            Instantiate(EnemyObj, SpawnPos.position, SpawnPos.rotation);//카운트 만큼 좀비 스폰
        }
        Manager.updateKeySpawnPos(SpawnPos);
        Manager.Activated();
    }
}