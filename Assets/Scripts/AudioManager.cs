using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _wallSFX;
    [SerializeField] private AudioClip _paddleSFX;
    [SerializeField] private AudioClip _scoreSFX;

    public AudioClip WallSFX { get => _wallSFX; private set => _wallSFX = value; }
    public AudioClip PaddleSFX { get => _paddleSFX; private set => _paddleSFX = value; }
    public AudioClip ScoreSFX { get => _scoreSFX; private set => _scoreSFX = value; }

    private void Awake()
    {
         _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audioSFX)
    {
        _audioSource.PlayOneShot(audioSFX);
    }
}
