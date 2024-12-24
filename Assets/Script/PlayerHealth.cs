using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    public float currentHealth;
    public float lerpSpeed;
    public Image _healthBarFill;
    public GameObject losePanel;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        lerpSpeed = 3f * Time.deltaTime;

        UpdateHealthBar();

        if(currentHealth == 0)
        {
            losePanel.SetActive(true);
        }
    }

    public void UpdateHealthBar()
    {
        float targetFillAmount = currentHealth / MaxHealth;
        _healthBarFill.fillAmount = Mathf.Lerp(_healthBarFill.fillAmount, targetFillAmount, lerpSpeed);
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }

        UpdateHealthBar();
    }

    public void Healing(float heal)
    {
        if (currentHealth <= 100)
        {
            currentHealth += heal;
        }

        UpdateHealthBar();
    }


}
