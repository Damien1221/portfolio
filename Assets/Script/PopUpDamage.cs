using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDamage : MonoBehaviour
{
    public Vector2 InitialVelocity;
    public Rigidbody2D rb;
    public float lifetime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(Random.Range(5f, -2.7f), 2f, 0);
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
