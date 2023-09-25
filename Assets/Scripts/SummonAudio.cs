using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAudio : MonoBehaviour
{
    private Animator anim;
    private AudioSource audio;
    [SerializeField] private AudioClip death;
    [Range(0, 1)]
    public float deathvolume = 1;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeathAud()
    {
        audio.Stop();
        audio.clip = death;
        audio.volume = deathvolume;
        audio.Play();
    }
}
