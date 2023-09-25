using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineResume : MonoBehaviour
{

    public TimelineController timelinecontroller;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnEnable()
    {
        timelinecontroller.Resume();
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
