using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRoomScript : MonoBehaviour
{
    public Transform PlayerSpawnPos;
    public GameObject Enemy;
    public Transform[] SpawnerPos;
    public int SpawnCount = 3;
    bool Entered;
    public int MobCount = 0;
    public GameObject ExitPotal;


    // Start is called before the first frame update
    void Start()
    {
        PlayerSpawnPos = gameObject.GetComponent<Transform>();
        ExitPotal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Entered)
        {
            Spawn();
            Entered = false;
        }

        if (MobCount > 0)
            ExitPotal.SetActive(false);
        else
            ExitPotal.SetActive(true);
    }

    public Transform Position()
    {
        return PlayerSpawnPos;
    }

    public void Spawn()
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            Instantiate(Enemy, SpawnerPos[0].position, SpawnerPos[0].rotation);
            Instantiate(Enemy, SpawnerPos[1].position, SpawnerPos[1].rotation);
        }
        Zombie_Moving[] Mobs = FindObjectsOfType<Zombie_Moving>();
        foreach (Zombie_Moving Mob in Mobs)
        {
            MobCount++;
        }
    }

    public void PlayerEntered()
    {
        Entered = true;
    }

    public void MobDied()
    {
        MobCount--;
    }
}