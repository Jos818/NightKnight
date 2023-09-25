using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallToDeath : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<IDamageable>().TakeDamage(1);
            other.gameObject.transform.position = respawnPoint.position;
        }
    }
}
