using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _isFXEnabled;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnVolumeChanged(float value)
    {
        _audioSource.volume = value;
    }

    public void OnFXChanged(bool enable)
    {
        _isFXEnabled = enable;
    }

    public void PlayFXClip()
    {
        if (!_isFXEnabled) {
            return;
        }
    }
}