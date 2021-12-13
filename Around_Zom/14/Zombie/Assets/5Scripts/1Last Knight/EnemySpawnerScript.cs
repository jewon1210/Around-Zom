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
    public GameObject InteractionButton;
    public Material[] render;//스폰 무덤위 큐브 색
    public GameObject MiniMapCube;//미니맵 큐브

    bool once = false;

    // Start is called before the first frame update
    void Start()
    {
        Manager = FindObjectOfType<KeyManager>();
        PlayerTrans = GameObject.FindWithTag("Player").GetComponent<Transform>();
        InteractionButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Vector3.Distance(PlayerTrans.position, gameObject.transform.position) <= 1.5f && !once)
            InteractionButton.SetActive(true);
        else
            InteractionButton.SetActive(false);
    }

    public void Spawn()
    {
        if (!once)
        {
            once = true;

            for (int i = 0; i < SpawnCount; i++)
            {
                Instantiate(EnemyObj, SpawnPos.position, SpawnPos.rotation);//카운트 만큼 좀비 스폰
            }

            Manager.updateKeySpawnPos(SpawnPos);
            Manager.Activated();
            MeshRenderer material = MiniMapCube.GetComponent<MeshRenderer>();//큐브 안의 MeshRenderer를 변수 지정 후 호출
            material.materials = render; //0번째의 엘리먼트를 render(또다른 Material) 로 바꾸겠다.
        }
    }

}