//MusicOff.cs by Joseph Panara for Night Knight
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Turns off the background music when the player enters the trigger. Used for the tower before the final boss in Level 3
public class MusicOff : MonoBehaviour
{
    public bool useTrigger;
    private bool isTriggered = false;
    [SerializeField] private GameObject music;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTriggered && useTrigger == true && other.gameObject.tag == "Player")
        {
            TurnMusicOff();
        }
    }
    public void TurnMusicOff()
    {
        music.SetActive(false);
    }
}
