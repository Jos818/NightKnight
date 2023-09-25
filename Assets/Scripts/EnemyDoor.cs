using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoor : MonoBehaviour
{
    public int enemeynum;
    //public List<GameObject> enemies;
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
