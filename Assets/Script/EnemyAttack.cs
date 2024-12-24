using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;
    public float dash_Speed = 5f;
    public float dash_Duration = 0.2f;
    public float detectionRadius = 5f;
    public float cooldownTime = 2f;

    private bool isDashing = false;
    private float dashTimeLeft;
    private float cooldownTimer;
    private Vector2 dashDirection;
    
    private CameraShake Enemy_Attack;


    // Start is called before the first frame update
    void Start()
    {
        Enemy_Attack = FindObjectOfType<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldownTimer <= 0.7f)
        {
            Enemy_Attack.MrStarsReady();
        }

        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (!isDashing && cooldownTimer <= 0)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRadius)
            {
                StartDash();
                Enemy_Attack.MrStarsAttacking();
            }
        }
        if (isDashing)
        {
            Dash();
        }
    }

    private void StartDash()
    {
        isDashing = true;
        dashTimeLeft = dash_Duration;

        // Calculate the direction toward the player
        dashDirection = (player.position - transform.position).normalized;

        // Reset cooldown timer
        cooldownTimer = cooldownTime;
    }

    private void Dash()
    {
        // Move the enemy in the dash direction
        transform.position += (Vector3)dashDirection * dash_Speed * Time.deltaTime;

        // Reduce dash time left
        dashTimeLeft -= Time.deltaTime;

        // End the dash when time is up
        if (dashTimeLeft <= 0)
        {
            isDashing = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
