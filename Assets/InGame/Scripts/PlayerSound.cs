using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] AudioClip shotAudioSource;
    BallController _ballController;
    AudioSource _audioSource;
    InGameManager _inGameManager;

    private void Awake()
    {
        _inGameManager = InGameManager.Instance;
        _inGameManager.playerSound = this;
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
        _ballController = _inGameManager.ballController;
        _inGameManager.OnBallShot += PlayShotSound;
    }
    void PlayShotSound()
    {
        _audioSource.PlayOneShot(shotAudioSource);
    }
}
