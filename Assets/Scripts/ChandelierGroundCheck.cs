using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChandelierGroundCheck : MonoBehaviour
{
    //[SerializeField] private LayerMask groundLayer;
    [SerializeField] private Chandelier chandelier;
    //[SerializeField] private bool playaud;

    public bool isGrounded;

    void Start()
    {
        chandelier = transform.parent.GetComponent<Chandelier>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //isGrounded = other != null && (((1 << other.gameObject.layer) & groundLayer) != 0);
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            chandelier.Land();
            isGrounded = true;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (chandelier.rope == null && isGrounded == false)
            {
                chandelier.Damage();
                other.gameObject.GetComponent<IDamageable>().TakeDamage(6);
            }

        }


    }
}
