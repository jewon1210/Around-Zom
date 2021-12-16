using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public TrapRoomScript PlayerSpawnPos;
    public Knight_Moving player;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSpawnPos = FindObjectOfType<TrapRoomScript>();
        player = FindObjectOfType<Knight_Moving>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.SendMessage("Warp", PlayerSpawnPos.Position().position);
            PlayerSpawnPos.PlayerEntered();
        }
    }
}
