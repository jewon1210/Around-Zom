using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Ani : MonoBehaviour
{
    public GameObject Player;
    public GameObject NPC;
    private float Dist;
    Animator NpcMov;
    bool YesOrNo; 

    // Start is called before the first frame update
    void Start()
    {
        NpcMov = NPC.GetComponent<Animator>();
        YesOrNo = false;
    }

    public float Distance()
    {
        return Dist;
    }

    // Update is called once per frame
    void Update()
    {
        Dist = Vector3.Distance(Player.transform.position, NPC.transform.position);
        
        if(Dist<=2.0f && YesOrNo==false)
        {
            YesOrNo = true;
            NpcMov.SetBool("BowOrNo", true);                      
        }
        else
        {
            NpcMov.SetBool("BowOrNo", false);
        }
    }
}
