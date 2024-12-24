using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private PlayerHealth player_Health;
    public float damageTo_Player = 30f;

    // Start is called before the first frame update
    void Start()
    {
        player_Health = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fire") || col.gameObject.CompareTag("FireMid") || col.gameObject.CompareTag("FireBig") ||
           col.gameObject.CompareTag("Heal") || col.gameObject.CompareTag("Lighting") || col.gameObject.CompareTag("LightingMid")
         || col.gameObject.CompareTag("LightingBig") || col.gameObject.CompareTag("Freeze"))
        {
            player_Health.TakeDamage(damageTo_Player);
            Destroy(col.gameObject);
        }
        else
        {
            Destroy(col.gameObject);
        }
    }
}
