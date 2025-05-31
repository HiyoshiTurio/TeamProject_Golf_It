using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] AudioClip shotAudioSource;
    [SerializeField] BallController ballController;
    AudioSource _audioSource;

    private void Start()
    {
        ballController.OnBallShot += PlayShotSound;
        _audioSource = GetComponent<AudioSource>();
    }
    void PlayShotSound()
    {
        _audioSource.PlayOneShot(shotAudioSource);
    }
}
