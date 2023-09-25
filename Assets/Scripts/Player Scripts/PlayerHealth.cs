using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHearts = 5; // Maximum number of hearts
    private int currentHearts; // Current number of hearts
    [SerializeField] private Image[] hearts; // Array of TextMeshProUGUI objects for hearts
    [SerializeField] private Sprite fullHeart; // Sprite for a full heart
    [SerializeField] private Sprite emptyHeart; // Sprite for an empty heart


    [SerializeField] private float shakeForce;

    private CinemachineImpulseSource camImpulseSource;
    private Animator anim;
    [SerializeField] private DeathText deathText;

    private void Start()
    {
        anim = GetComponent<Animator>();
        camImpulseSource = GetComponent<CinemachineImpulseSource>();
        currentHearts = maxHearts;
        UpdateHeartsUI();
    }

    public void TakeDamage(int damage)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerDeath"))
            return;

        currentHearts -= damage;

        if (currentHearts >= 0)
        {
            hearts[currentHearts].sprite = emptyHeart;
            anim.SetTrigger("Hurt");
            camImpulseSource.GenerateImpulseWithForce(shakeForce);
            hearts[currentHearts].GetComponent<HeartShake>().Shake();
        }

        if (currentHearts <= 0)
        {
            Die();
        }
    }

    private void Die(){
        Debug.Log("You Died");
        anim.SetTrigger("Death");
        this.enabled = false;
        GetComponent<PlayerAnimations>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
        GetComponent<TorchThrow>().enabled = false;

        deathText.StartGrowingText();

        Invoke("RestartScene", 3.0f);
    }

    private void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHearts)
            {
                hearts[i].sprite = fullHeart;
            }
            else if (i < maxHearts)
            {
                hearts[i].sprite = emptyHeart;
            } else {
                hearts[i].GetComponent<Image>().enabled = false;
            }
        }
    }

    private void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
