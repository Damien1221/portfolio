using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject Monster;
    public GameObject DeadEffect;
    public GameObject WinPanel;
    public float MaxHealth = 100;
    public float currentHealth;
    public float lerpSpeed;
    public Image _healthBarFill;
    public float damageTo_Player = 20f;

    private CameraShake DamageEffect;
    private CameraShake player_Hurt;
    private PlayerHealth player_Health;


    // Start is called before the first frame update
    void Start()
    {
        player_Health = FindObjectOfType<PlayerHealth>();
        player_Hurt = FindObjectOfType<CameraShake>();

        currentHealth = MaxHealth;

        DamageEffect = FindObjectOfType<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        lerpSpeed = 3f * Time.deltaTime;

        UpdateHealthBar();

        if(currentHealth <= 0)
        {
            EnemyDead();
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            player_Health.TakeDamage(damageTo_Player);
            player_Hurt.PlayerHurting();
        }

    }

    public void UpdateHealthBar()
    {
        float targetFillAmount = currentHealth / MaxHealth;
        _healthBarFill.fillAmount = Mathf.Lerp(_healthBarFill.fillAmount, targetFillAmount, lerpSpeed);
    }

    public void TakeDamage(float damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;
        }
        DamageEffect.MrStarsDamaging();
        UpdateHealthBar();
        //healthbar.SetHealth(currentHealth);
    }

    public void EnemyDead()
    {
        Destroy(Monster);
        Instantiate(DeadEffect, transform.position, Quaternion.identity);
        WinPanel.SetActive(true);
    }




   
}
