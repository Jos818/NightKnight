using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour, IDamageable
{
    public float delay;
    [SerializeField] private float delayMultiplier;
    [SerializeField] private float maxSpeed;
    private float currentSpeed;
    [SerializeField] private float acceleration;
    private Transform playerTransform;
    private Vector3 direction;
    [SerializeField] private float spottingRange;
    private bool spotted = false;

    private Animator anim;

    private void Start(){
        anim = GetComponent<Animator>();
        delay *= delayMultiplier;
    }

    private void Update(){
        if (!spotted && Vector2.Distance(this.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < spottingRange){
            spotted = true;
        }

        if (spotted){
            if (delay > 0){
                delay -= Time.deltaTime;
                return;
            }

            if (direction == Vector3.zero){
                playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
                direction = (playerTransform.position - this.transform.position + new Vector3(0f, 0.2f, 0f)).normalized;
            }

            if (currentSpeed < maxSpeed){
                currentSpeed += acceleration * Time.deltaTime;
            }

            transform.position += direction * currentSpeed * Time.deltaTime;
        }
    }

    public void TakeDamage(int damage){
        Die();
    }

    private void Die(){
        Debug.Log("I'm dying!");
        anim.SetTrigger("Death");
        GetComponent<CircleCollider2D>().enabled = false;
        Destroy(this.gameObject, 0.4f);
        this.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<IDamageable>().TakeDamage(1);
            Debug.Log("I collided with the player");
        } else {
            Debug.Log("I collided with something other than the player");
        }
        Die();
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, spottingRange);
    }
}
