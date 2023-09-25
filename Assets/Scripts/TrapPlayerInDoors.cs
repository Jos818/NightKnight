//TrapPlayerInDoors.cs by Joseph Panara for Night Knight
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//When the player enters the trigger, it closes the door behind them and activated any deactivated enemies in "enemies"
public class TrapPlayerInDoors : MonoBehaviour
{
    private bool isTriggered = false;
    [SerializeField] private List<GameObject> enemies;
    private void OnTriggerEnter2D(Collider2D other) {
        if (!isTriggered && other.gameObject.tag == "Player"){
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
