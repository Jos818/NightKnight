/* 
    Cristopher Argueta
    MIDTERM
    Filename: HAZARDS.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HAZARDS : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (Collider.tag == "Player")
           // collision.GetComponent<Health>().TakeDamage(damage);
    }

}
