//DIG3878 Night Knight Final Chandelier.cs by Torchlight Co.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chandelier : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject rope;
    private Animator ropeanim;
    private AudioSource audio;
    [SerializeField] private AudioClip ropesnap;
    [Range(0, 1)]
    public float ropevolume = 1;
    [SerializeField] private AudioClip thud;
    [Range(0, 1)]
    public float thudvolume = 1;
    public List<Collider2D> colliders;
    // Start is called before the first frame update
    void Start()
    {
        //colliders.Add(gameObject.FindObjectsOfType(Collider));
        rb = GetComponent<Rigidbody2D>();
        rope = gameObject.transform.GetChild(0).gameObject;
        ropeanim = rope.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        //ropetrigger = rope.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rope && ropeanim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Destroy(rope);
            audio.clip = ropesnap;
            audio.volume = ropevolume;
            rb.isKinematic = false;
            audio.Play();
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Torch"))
        {
            ropeanim.enabled = true;
            Destroy(other.gameObject);
        }
    }*/
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Torch"))
        {
            ropeanim.enabled = true;
            Destroy(other.gameObject);
        }
       
        /*if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            audio.clip = thud;
            audio.volume = thudvolume;
            audio.Play();
            foreach (Collider2D col in colliders)
            {
                if (col.enabled == false)
                {
                    col.enabled = false;
                }
            }
            rb.isKinematic = true;
            rb.velocity = new Vector2(0,0);
        }*/
    }
    public void Land()
    {
        audio.clip = thud;
        audio.volume = thudvolume;
        audio.Play();
        foreach (Collider2D col in colliders)
        {
            if (col.enabled == false)
            {
                col.enabled = true;
            }
        }
        rb.isKinematic = true;
        rb.velocity = new Vector2(0, 0);
    }
    public void Damage()
    {
        audio.clip = thud;
        audio.volume = thudvolume;
        audio.Play();
        
        foreach (Collider2D col in colliders)
        {
            col.enabled = false;
        }
    }
}
