//DialogueAutoAdvance.cs by Joseph Panara for Night Knight
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Advances dialogue without player input during the intro cutscene
public class DialogueAutoAdvance : MonoBehaviour
{
    [SerializeField] private DialogueManager manager;

    void OnEnable()
    {
        manager.AdvanceDialogue();
    }
}
