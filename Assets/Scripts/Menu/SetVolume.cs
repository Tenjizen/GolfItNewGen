using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    float m_sliderValue = 0.3f;
    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        SetLevel(m_sliderValue);
    }

    public void SetLevel(float sliderValue)
    {
        
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);

        Debug.Log(sliderValue);
        sliderValue = m_sliderValue;
    }
}
