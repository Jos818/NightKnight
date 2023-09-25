//EnemyDoor.cs by Joseph Panara for Night Knight
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A script used for doors that open once the player has defeated a set number of enemies
public class EnemyDoor : MonoBehaviour
{
    public int enemeynum;

    void Update()
    {
        if (enemeynum <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Open", true);
        }
         else
        {
            gameObject.GetComponent<Animator>().SetBool("Open", false);
        }

    }
    public void DoorCount()
    {
        enemeynum--;
    }
}
