/*
 * Cristopher Argueta
 * Final, Night-Knight
 * Torchlight.cs
 * adjusts light intensity based on player movement
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torchlight : MonoBehaviour
{
    public float intensity = 1f;
    public float range = 5f;

    //private Light torchLight;

    [SerializeField]
    private GameObject player;

    void Start()
    {
        //torchLight = GetComponent<Light>();
        //torchLight.intensity = intensity;
        //torchLight.range = range;
    }

    void Update()
    {
        // Set torch position to player position
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        // Update torch rotation to follow player rotation
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, player.transform.eulerAngles.z));

        // Update torchlight intensity based on player movement speed
        float movementSpeed = player.GetComponent<PlayerMovement>().runSpeed;
        //torchLight.intensity = intensity + movementSpeed;

        // Update torchlight range based on player movement speed
        //torchLight.range = range + movementSpeed;
    }
}

