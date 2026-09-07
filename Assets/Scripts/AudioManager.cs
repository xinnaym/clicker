using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip _backgroundMusic;
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _purchaseSound;
    private bool _isMuted;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _musicSource.clip = _backgroundMusic;
        _musicSource.loop = true;
        _musicSource.Play();
    }

    public void PlayClick()
    {
        _sfxSource.PlayOneShot(_clickSound);
    }

    public void PlayPurchase()
    {
        _sfxSource.PlayOneShot(_purchaseSound);
    }

    public void ToggleMute()
    {
        _isMuted = !_isMuted;
        AudioListener.volume = _isMuted ? 0f : 1f;
    }
}