using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOff : MonoBehaviour
{
    public bool useTrigger;
    private bool isTriggered = false;
    [SerializeField] private GameObject music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
