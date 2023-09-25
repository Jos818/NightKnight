/*
    Cristopher Argueta
    Final, Night-Knight
    CameraFollow
    Targets the player and sets the camera to follow player.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5.0f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}


