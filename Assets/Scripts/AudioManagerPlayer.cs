using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
        //int rand = Random.Range(0, audiosDisparo.Length);
      
        audioSource.PlayOneShot(audioLauncher);
    }
    public void PlayExplosionGrande()
    {
        audioSource.PlayOneShot(audioGranade);
    }

    public void PlayExplosionC4()
    {
        audioSource.PlayOneShot(audioC4);
    }
    public void PlayExplosionMine()
    {
        audioSource.PlayOneShot(audioMine);
    }
}
