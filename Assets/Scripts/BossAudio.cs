using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAudio : MonoBehaviour
{
    private Animator anim;
    private AudioSource audio;
    [SerializeField] private AudioClip scythe1;
    [Range(0, 1)]
    public float scythe1volume = 1;
    [SerializeField] private AudioClip scythe2;
    [Range(0, 1)]
    public float scythe2volume = 1;
    [SerializeField] private AudioClip summon;
    [Range(0, 1)]
    public float summonvolume = 1;
    [SerializeField] private AudioClip rage;
    [Range(0, 1)]
    public float ragevolume = 1;
    [SerializeField] private AudioClip die;
    [Range(0, 1)]
    public float dievolume = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Scythe1Aud()
    {
        audio.Stop();
        audio.clip = scythe1;
        audio.volume = scythe1volume;
        audio.Play();
    }
    public void Scythe2Aud()
    {
        audio.Stop();
        audio.clip = scythe2;
        audio.volume = scythe2volume;
        audio.Play();
    }
    public void SummonAud()
    {
        audio.Stop();
        audio.clip = summon;
        audio.volume = summonvolume;
        audio.Play();
    }
    public void RageAud()
    {
        audio.Stop();
        audio.clip = rage;
        audio.volume = ragevolume;
        audio.Play();
    }
    public void DieAud()
    {
        audio.Stop();
        audio.clip = die;
        audio.volume = dievolume;
        audio.Play();
    }
}
