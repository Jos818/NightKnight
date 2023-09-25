//LightableObj.cs by Joseph Panara for Night Knight
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the behavior for objects that can be lit by the throwable torch
public class LightableObj : MonoBehaviour
{
    private GameObject _light;
    private SpriteRenderer spriterend;
    private Animator animator;
    public bool lit;
    private Collider2D trigger;
    private Sprite normalsprite;
    private AudioSource audio;

    //Gets the light components and disables them
    void Start()
    {

        trigger = GetComponent<Collider2D>();
        spriterend = GetComponent<SpriteRenderer>();
        normalsprite = spriterend.sprite;
        _light = gameObject.transform.GetChild(0).gameObject;
        _light.SetActive(false);
        animator = GetComponent<Animator>();
        animator.enabled = false;
        lit = false;
        audio = GetComponent<AudioSource>();
    }

    //Lights the object when a throwable torch interacts with it
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Torch"))
        {
            Light();
            Destroy(other.gameObject);
        }
    }
    //Enabled the light components and plays any animations
    public void Light()
    {
        _light.SetActive(true);
        animator.enabled = true;
        audio.Play();
        lit = true;
        trigger.enabled = false;
    }
    //Reverts the object to its unlit state
    public void Unlight()
    {
        lit = false;
        _light.SetActive(false);
        animator.enabled = false;
        audio.Stop();
        spriterend.sprite = normalsprite;
        trigger.enabled = true;
    }
}
