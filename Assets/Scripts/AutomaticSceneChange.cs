using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutomaticSceneChange : MonoBehaviour
{
    [SerializeField] private string nextScene;
    private void OnEnable()
    {
                SceneManager.LoadScene(nextScene);
    }
}
