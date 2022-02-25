using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource audioSource;
    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip)
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
