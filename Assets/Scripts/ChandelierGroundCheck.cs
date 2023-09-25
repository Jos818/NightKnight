//ChandelierGroundCheck.cs by Joseph Panara for Night Knight
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks if the Chandelier has hit the ground
public class ChandelierGroundCheck : MonoBehaviour
{
    [SerializeField] private Chandelier chandelier;
    public bool isGrounded;

    void Start()
    {
        chandelier = transform.parent.GetComponent<Chandelier>();
    }
    //When something on the ground layer hits the chandelier, the Chandelier's Land function runs
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            chandelier.Land();
            isGrounded = true;
        }

        //While the Chandelier is falling, if a player or enemy is hit, it will deal damage
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
