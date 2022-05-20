using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static AudioSource _audioSource;
    public bool sourceExists = false;
    private static BackgroundMusic instance = null;
    public static BackgroundMusic Instance {
        get {return instance;}
    }
    
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        initMusic();
    }
    
    public void initMusic() {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }
 
    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
