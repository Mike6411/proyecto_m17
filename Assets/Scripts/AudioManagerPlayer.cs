using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerPlayer : MonoBehaviour
{
    AudioSource audioSource;
    [Header("Sonidos de disparo")]
    [SerializeField]AudioClip[] audiosDisparo;

    [Header("Explosion 1")]
    [SerializeField] AudioClip audioExpl1;

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
        audioSource.PlayOneShot(audioExpl1);
    }
}
