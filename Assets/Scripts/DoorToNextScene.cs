using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextScene : MonoBehaviour
{
    [SerializeField] private string nextScene;
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player") {
            if (Input.GetKey(KeyCode.E)) {
                SceneManager.LoadScene(nextScene);
            }
        }

    }
}
