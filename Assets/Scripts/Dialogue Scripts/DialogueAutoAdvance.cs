using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAutoAdvance : MonoBehaviour
{
    [SerializeField] private DialogueManager manager;

    void OnEnable()
    {
        manager.AdvanceDialogue();
    }
}
