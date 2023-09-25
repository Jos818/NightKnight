//DIG3878 Night Knight Final TorchCodePuzzle.cs by Torchlight Co.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchCodePuzzle : MonoBehaviour
{
    [Tooltip("Put all possible lights used for the puzzle here.")]
    public List<LightableObj> lights;
    public List<LightableObj> examples;
    //wronglights is used if you want the code to reset immediately on any incorrect input.
    //public List<LightableObj> wronglights;
    [Tooltip("The number of lights you want in the code")]
    public int codesize;
    [Tooltip("The index numbers of the correct lights to activate. Generates on Start.")]
    public List<int> code;
    [Tooltip("The index numbers of the lights the player has activated.")]
    public List<int> codecheck;
    bool wrong = false;
    bool right = false;
    [Header("Set to true if you want the code to change on a wrong answer.")]
    public bool randomizewrong;

    void Start()
    {
        GetComponent<Animator>().SetBool("Open", false);
        CodeGen();
    }
    void Update()
    {
        foreach (LightableObj example in examples)
        {
            if (code.Contains(examples.IndexOf(example)) && example.lit == false)
            {
                example.Light();
            }
        }
        if (wrong == false && right == false)
        {
            /*foreach (LightableObj light in wronglights)
            {
                if (light.lit == true)
                {
                    wrong = true;
                    StartCoroutine(WrongCode());
                }
            }*/
            foreach (LightableObj light in lights)
            {
                //Adds light index to codecheck if not already present
                if (light.lit == true && !codecheck.Contains(lights.IndexOf(light)))
                {
                    //Debug.Log(lights.IndexOf(light));
                    codecheck.Add(lights.IndexOf(light));

                }
            }
            //Checks if the player input (codecheck) is the same as the code
            if (codecheck.Count == code.Count)
            {
                for (int i = 0; i < codecheck.Count; i++)
                {
                    if (!codecheck.Contains(code[i]))
                    {
                        wrong = true;
                        StartCoroutine(WrongCode());
                        break;
                    }
                }
                if (codecheck.Count == code.Count && wrong == false)
                {
                    right = true;
                }
            }

        }
        foreach (LightableObj example in examples)
        {
            if (!code.Contains(examples.IndexOf(example)) && example.lit == true)
            {
                StartCoroutine(PreserveExample(example));
            }
        }
        if (wrong == false && right == true)
        {
            foreach (LightableObj light in lights)
            {
                if (light.lit == false)
                {
                    light.Light();
                }
            }
            //Set whatever happens when the puzzle is solved here.
            gameObject.GetComponent<Animator>().SetBool("Open", true);
        }
    }
    void CodeGen()
    {
        //Randomizes the items used in the code, while preventing duplicates
        code.Clear();
        //wronglights.Clear();
        for (int i = 0; i < codesize; i++)
        {
            int randomnum;
            do
            {
                randomnum = Random.Range(0, lights.Count);
            }
            while (code.Contains(randomnum));
            code.Add(randomnum);
            //codeText.text += randomnum.ToString();
            //Debug.Log(randomnum);
        }
        foreach (LightableObj example in examples)
        {
            if (code.Contains(examples.IndexOf(example)))
            {
                example.Light();
            }
        }
        /*foreach (LightableObj light in lights)
        {
            if (!code.Contains(lights.IndexOf(light)))
            {
                wronglights.Add(light);
            }
        }*/
    }
    //Resets puzzle on wrong answer
    IEnumerator WrongCode()
    {
        //audioSource.Play();
        foreach (LightableObj light in lights)
        {
            light.Unlight();
        }
        yield return new WaitForSeconds(0);
        codecheck.Clear();
        if (randomizewrong == true)
        {
            CodeGen();
        }
        wrong = false;
    }
    //Makes sure the player can't accidentally erase the code example for themselves
    IEnumerator PreserveExample(LightableObj example)
    {
        yield return new WaitForSeconds(2);
        example.Unlight();
    }
}
