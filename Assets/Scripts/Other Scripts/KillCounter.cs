using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    [SerializeField] private GameObject door;

    public void Die(){
        if (door == null)
            return;
        
        door.GetComponent<EnemyDoor>().DoorCount();
    }
}
