using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] AudioClip shotAudioSource;
    BallController _ballController;
    AudioSource _audioSource;
    InGameManager _inGameManager;


    void Start()
    {
        _inGameManager = InGameManager.Instance;
        _audioSource = GetComponent<AudioSource>();
        _ballController = _inGameManager.BallController;
    }
    void PlayShotSound()
    {
        _audioSource.PlayOneShot(shotAudioSource);
    }
}
