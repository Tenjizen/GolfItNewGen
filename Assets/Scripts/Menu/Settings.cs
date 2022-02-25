using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider Slider;

    private void Awake()
    {
        AudioManager volume = FindObjectOfType<AudioManager>();
        Slider.value = volume.m_sliderValue;
    }

    public void OnVolumeChanged( float value )
    {
        AudioManager volume = FindObjectOfType<AudioManager>();
        if ( volume != null)
            volume.SetLevel(value);
    }

}
