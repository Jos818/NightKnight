/*
  Cristopher Argueta
  Finals, Night-Knight
  Doors.cs
  Teleports player when key is pressed
 */
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Transform teleportTarget; // This will be the target location to teleport the player to.
    public Transform Player;


    private void OnTriggerStay2D(Collider2D other)
    {

            if(other.tag == "Player")
        {
            print("teleported player");
            if (Input.GetKey(KeyCode.E))
            {

                Player.transform.position = teleportTarget.position;
                print("teleported player");
            }
        }

    }
}
