using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGodDestroyScript : MonoBehaviour
{
    CharacterStatus Status;
    public GameObject TreasureBox;

    // Start is called before the first frame update
    void Start()
    {
        Status = gameObject.GetComponent<CharacterStatus>();
        TreasureBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Status.Hp <=0)
        {
            TreasureBox.SetActive(true);
            Destroy(gameObject);
        }
    }
}
