using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public GameObject box;
    public Transform _Spawnpos;
    public float speed = 5f;

    private float timer;
    private float stopDistance = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            timer = 0;
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            // Get the enemy's current position
            Vector2 enemyPosition = transform.position;

            // Check the distance between the enemy and the player
            float distanceToPlayer = Mathf.Abs(player.position.x - enemyPosition.x);

            // Move the enemy only if it's farther than the stopDistance
            if (distanceToPlayer > stopDistance)
            {
                // Move the enemy along the X-axis towards the player
                float newX = Mathf.MoveTowards(enemyPosition.x, player.position.x, speed * Time.fixedDeltaTime);

                // Update the enemy's position (only the X-axis)
                transform.position = new Vector3(newX, enemyPosition.y, transform.position.z);
            }
        }
    }

    public void Shoot()
    {
        Instantiate(box, _Spawnpos.position, Quaternion.identity);
    }
}
