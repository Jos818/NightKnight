//DIG3878 Night Knight Final Boss.cs by Torchlight Co.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;
    private int currentHealth;
    private bool enraged = false;
    private GameObject attackTarget;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float enragedAttackCooldown;
    private float attackCooldownTimer;
    [SerializeField] private float summonCooldown;
    private float summonCooldownTimer;
    [SerializeField] private Transform[] summonSpawnPoints;
    [SerializeField] private GameObject summonPrefab;
    
    
    [SerializeField] private float spottingRange;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float enragedMoveSpeed;
    private bool facingRight = true;
    private bool immobile;

    private Animator anim;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private Slider healthBarSlider;
    
    private void Start(){
        anim = GetComponent<Animator>();
        attackCooldownTimer = attackCooldown;
        attackTarget = GameObject.FindGameObjectWithTag("Player");
        currentHealth = health;
        healthBarSlider.maxValue = health;
        healthBarSlider.value = currentHealth;
        summonCooldownTimer = summonCooldown;
    }

    private void Update(){

        if (Vector2.Distance(this.transform.position, attackTarget.transform.position) <= spottingRange){
            healthBar.SetActive(true);

            attackCooldownTimer -= Time.deltaTime;
            summonCooldownTimer -= Time.deltaTime;

            immobile = anim.GetCurrentAnimatorStateInfo(0).IsName("BossSkill") || anim.GetCurrentAnimatorStateInfo(0).IsName("BossAttack") || anim.GetCurrentAnimatorStateInfo(0).IsName("BossSummon");

            if (!immobile && ((facingRight && this.transform.position.x > attackTarget.transform.position.x) || (!facingRight && this.transform.position.x < attackTarget.transform.position.x))){
                Flip();
            }

            if (Vector2.Distance(this.transform.position, attackTarget.transform.position) <= attackRange){
                if (attackCooldownTimer <= 0){
                    anim.SetTrigger("Attack");
                }
            } else if (!immobile){
                if (summonCooldownTimer <= 0){
                    Summon();
                } else {
                    this.transform.position = Vector2.MoveTowards(this.transform.position, attackTarget.transform.position, moveSpeed * Time.deltaTime);
                }
            }
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

    private void Summon(){
        anim.SetTrigger("Summon");
        summonCooldownTimer = summonCooldown;

        int spawnAmount = 2;
        if (enraged){
            spawnAmount = 4;
        }

        for (int i = 0; i < spawnAmount; i++)
        {
            Instantiate(summonPrefab, summonSpawnPoints[i].position, summonSpawnPoints[i].rotation)
                .GetComponent<Summon>().delay = i;
        }
    }

    public void TakeDamage(int damage){
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("BossDeath") || anim.GetCurrentAnimatorStateInfo(0).IsName("BossSkill")){
            return;
        }

        currentHealth -= damage;
        healthBarSlider.value = currentHealth;

        if (currentHealth <= 0){
            if (enraged){
                Die();
            } else {
                Enrage();
            }
        }
    }

    private void Enrage(){
        enraged = true;
        anim.SetBool("Enraged", true);
    }

    public void EnrageAnimFinished(){
        anim.SetBool("EnragedAnimPlayed", true);
        currentHealth = health;
        healthBarSlider.value = currentHealth;
        attackCooldown = enragedAttackCooldown;
        moveSpeed = enragedMoveSpeed;
    }

    private void Die(){
        anim.SetTrigger("Death");
        GetComponent<KillCounter>().Die();
        Destroy(this.gameObject, 1.75f);
        healthBar.SetActive(false);
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
