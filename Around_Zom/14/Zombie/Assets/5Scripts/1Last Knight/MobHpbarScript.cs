using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. UI;

public class MobHpbarScript : MonoBehaviour
{
    public Image HpFiller;
    public CharacterStatus Status;
    Transform Cam;
    public Transform HpbarBackGround;


    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main.transform;

        Status = transform.root.GetComponent<CharacterStatus>();
        HpFiller = gameObject.GetComponent<Image>();
        HpFiller.fillAmount = (float)Status.Hp / Status.MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        HpFiller.fillAmount = (float)Status.Hp / Status.MaxHp;
        transform.LookAt(transform.position + Cam.rotation * Vector3.forward, Cam.rotation * Vector3.up); //Hp bar가 정면 쳐다보게끔 해준다.(빨간색) 1
        HpbarBackGround.LookAt(transform.position + Cam.rotation * Vector3.forward, Cam.rotation * Vector3.up); //Hp bar가 정면 쳐다보게끔 해준다.(백그라운드) 2
    }
}
