//AutomaticSceneChange.cs by Joseph Panara for Night Knight
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Loads the next scene after the conclusion of the intro cutscene
public class AutomaticSceneChange : MonoBehaviour
{
    [SerializeField] private string nextScene;
    private void OnEnable()
    {
                SceneManager.LoadScene(nextScene);
    }
}
