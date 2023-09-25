using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void Play(string levelName){
        SceneManager.LoadScene(levelName);
    }

    public void Quit(){
        Application.Quit();
    }
}
