/* 
    Cristopher Argueta
    Final group project
    Filename: MovingPlatform.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Moves the platform by moving between two points that the player creates

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public float xVelocity;
    private float previousPositionX;
    public int startingPoint;
    public Transform[] points;
    public float testValue;

    private int i;

    private void Start()
    {
        transform.position = points[startingPoint].position;
        previousPositionX = transform.position.x;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);

        xVelocity = Mathf.Round((transform.position.x - previousPositionX) / Time.deltaTime * 10.0f) * 0.1f;
        if (xVelocity != 0){
            if (xVelocity < 0){
                xVelocity -= testValue;
            } else {
                xVelocity += testValue;
            }
        }
        previousPositionX = transform.position.x;
    }
    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<PlayerMovement>().platform = this;
            return;
        }

        if(collision.transform.position.y > transform.position.y) {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<PlayerMovement>().platform = null;
            return;
        }

        collision.transform.SetParent(null);
    }
}
