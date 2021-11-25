using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingBgm : MonoBehaviour
{
    public AudioSource EndingSound;
    // Start is called before the first frame update
    void Start()
    {
        EndingSound.volume = GoSound.SoundController.BGMSendSound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
