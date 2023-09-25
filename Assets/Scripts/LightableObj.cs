using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightableObj : MonoBehaviour
{
    private GameObject _light;
    private SpriteRenderer spriterend;
    private Animator animator;
    public bool lit;
    private Collider2D trigger;
    private Sprite normalsprite;
    private AudioSource audio;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Torch"))
        {
            Light();
            Destroy(other.gameObject);
        }
    }
    public void Light()
    {
        _light.SetActive(true);
        animator.enabled = true;
        audio.Play();
        lit = true;
        trigger.enabled = false;
    }
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
