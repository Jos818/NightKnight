using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;


    private void Update(){
        transform.position += new Vector3(0f, scrollSpeed * Time.deltaTime, 0f);

        if (transform.position.y > 5800){
            SceneManager.LoadScene("Main Menu");
        }
    }
}
