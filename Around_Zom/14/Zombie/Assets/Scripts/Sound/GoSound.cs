using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoSound : MonoBehaviour
{
    static GoSound instance;//반장역할<오브젝트 찾아준다>
    public static GoSound SoundController { get { return instance; } }//반장보호

    public float SaveBgm;
    public float SaveEffect;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
        SaveEffect = 0;
        SaveBgm = 0;
    }


    public void BGMSoundSave(float BGM) //사운드 볼륨값을 저장
    {
        SaveBgm = BGM;
    }


    public void ShootingSoundSave(float Shoot)
    {
        SaveEffect = Shoot;
    }

    public float BGMSendSound()
    {
        return SaveBgm;
    }

    public float EffectSendSound()
    {
        return SaveEffect;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}