using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public GameObject timeline;
    float pausespeed = 0;
    float resumespeed = 1;
    public PlayableDirector director;
    // Start is called before the first frame update
    void Start()
    {
        director = timeline.GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  Pause()
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(pausespeed);
    }

    public void Resume()
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(resumespeed);
    }
}
