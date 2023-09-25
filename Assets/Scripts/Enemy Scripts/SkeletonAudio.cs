using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAudio : MonoBehaviour
{
    private Animator anim;
    private AudioSource audio;
    [SerializeField] private AudioClip step;
    [Range(0, 1)]
    public float stepvolume = 1;
    [SerializeField] private AudioClip attack;
    [Range(0, 1)]
    public float attackvolume = 1;
    [SerializeField] private AudioClip hiss;
    [Range(0, 1)]
    public float hissvolume = 1;
    [SerializeField] private AudioClip thud;
    [Range(0, 1)]
    public float thudvolume = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    public void StepAud()
    {
        audio.Stop();
        audio.clip = step;
        audio.volume = stepvolume;
        audio.Play();
    }
    public void AttackAud()
    {
        audio.Stop();
        audio.clip = attack;
        audio.volume = attackvolume;
        audio.Play();
    }
    public void HissAud()
    {
        audio.Stop();
        audio.clip = hiss;
        audio.volume = hissvolume;
        audio.Play();
    }
    public void ThudAud()
    {
        audio.Stop();
        audio.clip = thud;
        audio.volume = thudvolume;
        audio.Play();
    }
}
