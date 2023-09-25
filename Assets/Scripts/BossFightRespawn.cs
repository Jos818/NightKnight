using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightRespawn : MonoBehaviour
{
    private GameObject Player;
    private Transform respawnLocation;
    private static bool madeItToBossFight = false;
    private static bool isInitialized = false;
    
    private void Start(){
        Player = GameObject.FindGameObjectWithTag("Player");
        respawnLocation = transform.GetChild(0).transform;

        if (madeItToBossFight){
            Player.transform.position = respawnLocation.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!madeItToBossFight && other.gameObject.tag == "Player"){
            madeItToBossFight = true;
        }
    }

    void OnDestroy() {
        PlayerPrefs.SetInt("madeItToBossFight", madeItToBossFight ? 1 : 0);
    }

    void Awake() {
        if (!isInitialized) {
            PlayerPrefs.SetInt("madeItToBossFight", 0);
            isInitialized = true;
        }
        madeItToBossFight = PlayerPrefs.GetInt("madeItToBossFight", 0) == 1;
    }
}
