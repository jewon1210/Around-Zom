using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. UI;

public class MobHpbarScript : MonoBehaviour
{
    public Image HpFiller;
    public CharacterStatus Status;

    // Start is called before the first frame update
    void Start()
    {
        Status = transform.root.GetComponent<CharacterStatus>();
        HpFiller = gameObject.GetComponent<Image>();
        HpFiller.fillAmount = (float)Status.Hp / Status.MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        HpFiller.fillAmount = (float)Status.Hp / Status.MaxHp;
    }
}
