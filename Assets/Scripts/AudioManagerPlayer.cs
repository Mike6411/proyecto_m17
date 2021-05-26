using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerPlayer : MonoBehaviour
{
    AudioSource audioSource;
    [Header("Sonidos de disparo")]
    [SerializeField]AudioClip[] audiosDisparo;

    [Header("Launcher Explosion")]
    [SerializeField] AudioClip audioLauncher;

    [Header("Granade Explosion")]
    [SerializeField] AudioClip audioGranade;

    [Header("C4 Explosion")]
    [SerializeField] AudioClip audioC4;

    [Header("Mine Explosion")]
    [SerializeField] AudioClip audioMine;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayAudioDisparo()
    {
        int rand = Random.Range(0, audiosDisparo.Length);
        audioSource.PlayOneShot(audiosDisparo[rand]);
    }
    public void PlayExplosion1()
    {
        audioSource.PlayOneShot(audioLauncher);
    }
}
