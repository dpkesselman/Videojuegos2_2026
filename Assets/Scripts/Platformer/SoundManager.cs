using UnityEngine;


public class SoundManager : MonoBehaviour
{
    //Variable para mantener el manager entre escenas
    public static SoundManager instance;
    //El static permite referenciar a la misma clase, en este caso SoundManager
   
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSrc;
    [SerializeField] AudioSource sfxSrc;


    [Header("Audio Clips")]
    public AudioClip music;
    public AudioClip jump;
    public AudioClip fire;


    void Awake()
    {
        //Código para que la instancia del Sound Manager no se repita por error
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
    void Start()
    {
        musicSrc.clip = music;
        musicSrc.Play();
    }


    public void PlaySFX(AudioClip clip)
    {
        sfxSrc.PlayOneShot(clip);
    }
}

