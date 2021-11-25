using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Audio;
using UnityEngine.UI;

public class Sound_Manager : MonoBehaviour
{
    AudioMixer masterMixer;
    Slider BGMSlider;
    Slider EffectSlider;

    float BGM_Volume;
    float Effect_Volume;

    public float BGMSound_Send()
    {
        BGM_Volume = BGMSlider.value;
        return BGM_Volume;
    }

    public float EffectSound_Send()
    {
        Effect_Volume = EffectSlider.value;
        return Effect_Volume;
    }


    public void BGMAudioControl()
    {
        float sound = BGMSlider.value;
        if(sound == -40f)
        {
            masterMixer.SetFloat("BGM", -80);
        }
        else
        {
            masterMixer.SetFloat("BGM", sound);
        }
    }

    public void EffectAudioControl()
    {
        float sound = EffectSlider.value;

        if (sound == -40f)
        {
            masterMixer.SetFloat("Shooting", -80);
        }
        else
        {
            masterMixer.SetFloat("Shooting", sound);
        }
    }
    
}
