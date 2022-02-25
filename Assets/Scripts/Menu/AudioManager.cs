using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource audioSource;

    public AudioClip[] audioClips;
    public AudioClip[] audioMusics;
    public static AudioManager Instance;



    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        SetLevel(m_sliderValue);
    }

    public float m_sliderValue = 0.3f;

    public void SetLevel(float sliderValue)
    {
        m_sliderValue = sliderValue;
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);

        Debug.Log(sliderValue);
    }
    public void PlaySound(string name)
    {
        AudioClip clip = GetClip(name);
        audioSource.PlayOneShot(clip);
    }

    AudioClip GetClip( string name)
    {
        foreach (var item in audioClips)
        {
            if (item.name == name)
                return item;
        }
        return null;
    }

}
