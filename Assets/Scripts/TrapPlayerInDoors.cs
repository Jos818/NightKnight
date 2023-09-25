using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlayerInDoors : MonoBehaviour
{
    private bool isTriggered = false;
    [SerializeField] private List<GameObject> enemies;
    private void OnTriggerEnter2D(Collider2D other) {
        if (!isTriggered && other.gameObject.tag == "Player"){
            //gameObject.GetComponent<Animator>().SetBool("Open", false);
            isTriggered = true;
            transform.parent.gameObject.GetComponent<EnemyDoor>().enabled = true;
            if (enemies.Count > 0)
            {
                foreach (GameObject enemy in enemies)
                {
                    enemy.SetActive(true);
                }
            }
        }
    }
}
