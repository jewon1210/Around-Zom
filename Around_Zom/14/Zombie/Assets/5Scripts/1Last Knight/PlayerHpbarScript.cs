using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpbarScript : MonoBehaviour
{
    public CharacterStatus Status;
    public Image Filler;

    // Start is called before the first frame update
    void Start()
    {
        Filler = gameObject.GetComponent<Image>();
        Status = GameObject.FindWithTag("Player").GetComponent<CharacterStatus>();
        Filler.fillAmount = (float)Status.Hp / Status.MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        Filler.fillAmount = (float)Status.Hp / Status.MaxHp;
    }
}
