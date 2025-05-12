using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    [SerializeField] AudioSource music, soundEffects;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Reproduce un efecto de sonido sin interrumpir los dem�s
    public void PlaySFX(AudioClip sound)
    {
        soundEffects.PlayOneShot(sound);
    }
    //Reproduce una canci�n sin repetirla
    public void PlayEndMusic(AudioClip song)
    {
        music.Stop();
        music.clip = song;
        music.Play();
        music.loop = false; 
    }
    //Reproduce una canci�n repitiendola
    public void PlayMusic(AudioClip song)
    {
        music.Stop();       
        music.clip = song;  
        music.Play();       
        music.loop = true;  
    }

}

