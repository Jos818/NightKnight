//SummonAudio.cs by Joseph Panara for Night Knight
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles audio for all "Summon Enemy" behaviors
public class SummonAudio : MonoBehaviour
{
    private Animator anim;
    private AudioSource audio;
    [SerializeField] private AudioClip death;
    [Range(0, 1)]
    public float deathvolume = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    public void DeathAud()
    {
        audio.Stop();
        audio.clip = death;
        audio.volume = deathvolume;
        audio.Play();
    }
}
