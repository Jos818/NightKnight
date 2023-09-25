using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private PlayerAudio audio;
    [SerializeField] private bool playaud;

    public bool isGrounded;

    private void OnTriggerStay2D(Collider2D other) {
        isGrounded = other != null && (((1 << other.gameObject.layer) & groundLayer) != 0);
        if (playaud == true)
        {
            audio.LandAud();
            playaud = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        isGrounded = false;
        playaud = true;
    }
}
