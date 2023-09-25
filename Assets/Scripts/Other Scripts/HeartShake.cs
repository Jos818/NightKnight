using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartShake : MonoBehaviour
{
    [SerializeField] private float shakeAmplitude;
    [SerializeField] private float shakeFrequency;
    [SerializeField] private float shakeDuration;
    private float shakeTimer;
    private Vector2 initialPosition;

    private void Start(){
        initialPosition = this.transform.position;
    }

    private void Update(){
        shakeTimer -= Time.deltaTime;

        if (shakeTimer >= 0) {
            // Calculate new position based on time left and shake power using a sine wave
            float t = (shakeTimer) * Mathf.PI * 2 / (shakeDuration / shakeFrequency);
            float yOffset = Mathf.Sin(t) * shakeAmplitude;
            transform.position = initialPosition + new Vector2(0, yOffset);
        } else {
            // Shake is over, reset heart image position
            transform.position = initialPosition;
        }
    }

    public void Shake(){
        shakeTimer = shakeDuration;
    }
}
