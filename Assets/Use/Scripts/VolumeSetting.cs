using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] Slider BgmSlider;
    [SerializeField] Slider EffectSlider;

    [SerializeField] string Bgm = "BGM";
    [SerializeField] string Effect = "Effect";

    private void Awake()
    {
        BgmSlider.onValueChanged.AddListener(BgmSound);
        EffectSlider.onValueChanged.AddListener(EffectSound);

    }

    void BgmSound(float value)
    {
    
        if (Mathf.Log10(value) * 20 <= -50)
        {
            masterMixer.SetFloat(Bgm, -80);
        }
        else
        {
            masterMixer.SetFloat(Bgm, Mathf.Log10(value) * 20);
        }
        Debug.Log(Mathf.Log10(value) * 20);
    }

    void EffectSound(float value)
    {
        if (Mathf.Log10(value) * 20 <= -50)
        {
            masterMixer.SetFloat(Effect, -80);
        }
        else
        {
            masterMixer.SetFloat(Effect, Mathf.Log10(value) * 20);
        }
       
    }

}
