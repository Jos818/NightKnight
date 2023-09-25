//TorchCodePuzzle.cs by Joseph Panara for Night Knight
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the puzzle door at the end of Level 2
//The puzzle is composed of 2 sets of torches and a door
//The script takes the number of torches in the "lights" list, and generates a code, where some of the torches will need to be lit to open the door
//The number of torches that need to be lit is equal to codesize
//The puzzle also has the list "examples" list, which should have an equal number of objects as "lights"
//Each torch in "lights" has an equivalent torch in "examples". If the torch in "lights" is part of the code, the corresponding light in "examples" will be lit
//The remaining torches in "examples" will be unlit, and if lit by the player will deactivate autoamtically
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

    //Closes the door and generates a random code
    void Start()
    {
        GetComponent<Animator>().SetBool("Open", false);
        CodeGen();
    }

    void Update()
    {
        //Lights the example torches in the earlier part of the level
        foreach (LightableObj example in examples)
        {
            if (code.Contains(examples.IndexOf(example)) && example.lit == false)
            {
                example.Light();
            }
        }
        if (wrong == false && right == false)
        {
        
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
        //If the player lights one of the unlit example torches, it unlights it so the player can go back and see the correct code
        foreach (LightableObj example in examples)
        {
            if (!code.Contains(examples.IndexOf(example)) && example.lit == true)
            {
                StartCoroutine(PreserveExample(example));
            }
        }
        //All lights are lit once the puzzle is solved
        if (wrong == false && right == true)
        {
            foreach (LightableObj light in lights)
            {
                if (light.lit == false)
                {
                    light.Light();
                }
            }
            //Set whatever happens when the puzzle is solved here
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
        //Creates the example pattern with a separate set of lights that is used as the solution to the puzzle
        foreach (LightableObj example in examples)
        {
            if (code.Contains(examples.IndexOf(example)))
            {
                example.Light();
            }
        }
       
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
