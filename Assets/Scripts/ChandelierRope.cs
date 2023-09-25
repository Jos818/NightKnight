//ChandelierRope.cs by Joseph Panara for Night Knight
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the animations for the Chandelier Ropes
public class ChandelierRope : MonoBehaviour
{
    private Animator ropeanim;
    private Chandelier chandelier;

    void Start()
    {
        ropeanim = GetComponent<Animator>();
    }

    //When the torch interacts with the chandelier, the animation plays
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Torch"))
        {
            ropeanim.enabled = true;
            Destroy(other.gameObject);
        }
    }
}
