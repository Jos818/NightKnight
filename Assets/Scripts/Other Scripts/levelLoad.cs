/* 
    Cristopher Argueta
    MIDTERM
    Filename: levelLoad.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoad : MonoBehaviour
{



    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }
}
