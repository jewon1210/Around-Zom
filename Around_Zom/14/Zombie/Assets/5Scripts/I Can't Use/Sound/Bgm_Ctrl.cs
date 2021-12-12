using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Bgm_Ctrl : MonoBehaviour
{
    AudioSource BGM;
    Slider BGMSlider;
    float BGM_Volume;

    void Awake()
    {
        GameObject s_obj=GameObject.Find("BGM_Sound");
        BGMSlider = s_obj.GetComponent<Slider>();
        BGM = s_obj.GetComponent<AudioSource>();
        BGM_Volume = GoSound.SoundController.BGMSendSound();
    }

    void Update()
    {
        BGMAudioControl();
        GoSound.SoundController.BGMSoundSave(BGM_Volume);
    }

    public void BGMAudioControl()
    {
        float sound = BGMSlider.value;
        BGM.volume = sound;
        BGM_Volume = BGMSlider.value;
    }
}