using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private Animator anim;
    private AudioSource audio;
    private bool isPlaying;
    [SerializeField] private AudioClip run;
    [Range(0, 1)]
    public float runvolume = 1;
    [SerializeField] private AudioClip jump;
    [Range(0, 1)]
    public float jumpvolume = 1;
    [SerializeField] private AudioClip land;
    [Range(0, 1)]
    public float landvolume = 1;
    [SerializeField] private AudioClip attack1;
    [Range(0, 1)]
    public float attackvolume1 = 1;
    [SerializeField] private AudioClip attack2;
    [Range(0, 1)]
    public float attackvolume2 = 1;
    [SerializeField] private AudioClip toss;
    [Range(0, 1)]
    public float tossvolume = 1;
    [SerializeField] private AudioClip hurt;
    [Range(0, 1)]
    public float hurtvolume = 1;
    [SerializeField] private AudioClip die;
    [Range(0, 1)]
    public float dievolume = 1;

    [HideInInspector] public AudioSource runsource;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        GameObject RunGameObject = new GameObject("RunAudioSource");
        RunGameObject.transform.parent = transform;
        runsource = RunGameObject.AddComponent<AudioSource>();
        runsource.clip = run;
        runsource.volume = runvolume;
        runsource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun"))
        {
            RunAud();
        }
        else
        {
                runsource.Stop();
                isPlaying = false;
            
        }
    }

    public void RunAud()
    {
        
        if (isPlaying == false)
        {
            runsource.Play();
            isPlaying = true;
        }
        
    }
    public void JumpAud()
    {
        audio.Stop();
        audio.volume = jumpvolume;
        audio.clip = jump;
        audio.Play();
    }
    public void LandAud()
    {
        audio.Stop();
        audio.volume = landvolume;
        audio.clip = land;
        audio.Play();
    }
    public void Attack1Aud()
    {
        audio.Stop();
        audio.volume = attackvolume1;
        audio.clip = attack1;
        audio.Play();
    }
    public void Attack2Aud()
    {
        audio.Stop();
        audio.volume = attackvolume2;
        audio.clip = attack2;
        audio.Play();
    }
    public void TossAud()
    {
        audio.loop = false;
        audio.clip = toss;
        audio.volume = tossvolume;
        audio.Play();
    }
    public void HurtAud()
    {
        audio.Stop();
        audio.volume = hurtvolume;
        audio.clip = hurt;
        audio.Play();
    }
    public void DieAud()
    {
        audio.Stop();
        audio.volume = dievolume;
        audio.clip = die;
        audio.Play();
    }
}
