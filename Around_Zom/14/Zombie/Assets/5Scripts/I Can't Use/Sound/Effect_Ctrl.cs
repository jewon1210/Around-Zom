using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Effect_Ctrl : MonoBehaviour
{
    AudioSource EFFECT;
    Slider EffectSlider;
    float Effect_Volume;

    void Awake()
    {
        GameObject s_obj = GameObject.Find("Shooting_Sound");
        EffectSlider = s_obj.GetComponent<Slider>();
        EFFECT = s_obj.GetComponent<AudioSource>();
        Effect_Volume = GoSound.SoundController.EffectSendSound();
    }


    void Update()
    {
        EffectAudioControl();
        GoSound.SoundController.ShootingSoundSave(Effect_Volume);
    }

    public void EffectAudioControl()
    {
        float sound = EffectSlider.value;
        EFFECT.volume = sound;       
        Effect_Volume = EffectSlider.value;
    }
}