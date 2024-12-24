using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{
    [SerializeField] GameObject[] ObjPrefab;

    public float Movespeed = 5.0f;
    public Transform newposition;
    private Rigidbody2D rb;

    public float x, y;

    // Start is called before the first frame update
    void Start()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > x)
        {
            rb.velocity = new Vector2(-Movespeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < y)
        {
            rb.velocity = new Vector2(Movespeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Spawning();
        }

    }

    public void Spawning()
    {
        GameObject gameobject = Instantiate(ObjPrefab[Random.Range(0, ObjPrefab.Length)], newposition.transform.position, Quaternion.identity);
    }
}
