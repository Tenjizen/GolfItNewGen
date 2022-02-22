using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider Slider;

    private void Awake()
    {
        SetVolume volume = FindObjectOfType<SetVolume>();
        Slider.value = volume.m_sliderValue;
    }

    public void OnVolumeChanged( float value )
    {
        SetVolume volume = FindObjectOfType<SetVolume>();
        if ( volume != null)
            volume.SetLevel(value);
    }

}
