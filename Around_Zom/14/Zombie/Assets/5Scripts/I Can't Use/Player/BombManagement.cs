using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManagement : MonoBehaviour
{
    public GameObject BombMeshObj;
    public Rigidbody rigidbody;
    public GameObject EffectBomb;
    public AudioSource BombSound;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BoomDelay());
        BombSound.gameObject.GetComponent<AudioSource>();
        BombSound.volume = GoSound.SoundController.EffectSendSound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator BoomDelay()
    {
        yield return new WaitForSeconds(2.0f);
        BombSound.Play();

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        BombMeshObj.SetActive(false);
        EffectBomb.SetActive(true);
        RaycastHit[] RayHit = Physics.SphereCastAll(transform.position,7.5f, Vector3.up, 0f, LayerMask.GetMask("Zombie"));

        foreach (RaycastHit BombHitObj in RayHit)
        {
            BombHitObj.transform.GetComponent<Enemy>().OnDamage(50f,BombHitObj.transform.GetComponent<Transform>().position, BombHitObj.transform.GetComponent<Transform>().position);
            BombHitObj.transform.GetComponent<Enemy>().BombAttackedSkinColor();
        }
    }
}
