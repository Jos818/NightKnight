using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;
    private GameObject attackTarget;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackCooldown;
    private float attackCooldownTimer;
    
    
    [SerializeField] private float spottingRange;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private float moveSpeed;
    private bool facingRight = true;
    private bool fighting;

    private Animator anim;
    
    private void Start(){
        anim = GetComponent<Animator>();
        attackCooldownTimer = attackCooldown;
        attackTarget = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update(){

        if (Vector2.Distance(this.transform.position, attackTarget.transform.position) <= spottingRange){
            attackCooldownTimer -= Time.deltaTime;

            fighting = anim.GetCurrentAnimatorStateInfo(0).IsName("SkeletonHurt") || anim.GetCurrentAnimatorStateInfo(0).IsName("SkeletonAttack");

            if (!fighting && ((facingRight && this.transform.position.x > attackTarget.transform.position.x) || (!facingRight && this.transform.position.x < attackTarget.transform.position.x))){
                Flip();
            }

            if (Vector2.Distance(this.transform.position, attackTarget.transform.position) <= attackRange){
                anim.SetBool("Walking", false);
                if (attackCooldownTimer <= 0){
                    anim.SetTrigger("Attack");
                }
            } else if (!fighting){
                anim.SetBool("Walking", true);
                this.transform.position = Vector2.MoveTowards(this.transform.position, attackTarget.transform.position, moveSpeed * Time.deltaTime);
            }
        } else {
            anim.SetBool("Walking", false);
        }
    }

    public void Attack(){
        Collider2D[] players = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, playerLayer);

        foreach (Collider2D player in players){
            if (player.GetComponent<IDamageable>() != null){
                player.GetComponent<IDamageable>().TakeDamage(1);
            }
        }

        attackCooldownTimer = attackCooldown;
        anim.ResetTrigger("Attack");
    }

    public void TakeDamage(int damage){
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("SkeletonDeath")){
            return;
        }

        health -= damage;

        if (health <= 0){
            Die();
        } else {
            anim.SetTrigger("Hurt");
        }
    }

    private void Die(){
        anim.SetTrigger("Death");
        GetComponent<KillCounter>().Die();
        this.enabled = false;
    }

    private void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }


    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, spottingRange);
    }
}
