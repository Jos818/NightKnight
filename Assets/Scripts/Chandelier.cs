//Chandelier.cs by Joseph Panara for Night Knight

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the Chandelier object's behavior
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

    //Gets the necessary rope components
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rope = gameObject.transform.GetChild(0).gameObject;
        ropeanim = rope.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    //Once the rope animation has finished, the rope is destroyed and the Chandelier falls
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

    //The rope animation starts when the Chandelier is hit by a thrown torch object
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Torch"))
        {
            ropeanim.enabled = true;
            Destroy(other.gameObject);
        }
    }
    //When the Chandelier hits thr ground, it is no longer movable by the player or gravity
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
    //If the Chandelier hits the player or an enemy while falling it deals damage, but also disables colliders so the Chandelier doesn't bounce off of them
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
