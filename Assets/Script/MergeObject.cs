using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeObject : MonoBehaviour
{
    int ID;

    private EnemyHealth enemyHealth;
    private PlayerHealth playerHealth;
    private CameraShake cameraShake;
    private PlayerUltimate _ultimate;
    public AudioClip clip;

    public GameObject MergeTo;
    public GameObject Effect;
    public GameObject Line;
    public GameObject popUp;
    public Transform _spawnPopUp;
    public float Distance;
    public float MergeSpeed;
    public float offset;
    public float _minaddMana = 2f;
    public float _MaxaddMana = 5f;

    private Transform Obj1;
    private Transform Obj2;
    private bool CanMerge;
    private float Lighting_Score = 50f;
    private float LightingMid_Score = 150f;
    private float LightingBig_Score = 250f;

    private float Fire_Score = 50f;
    private float FireMid_Score = 150;
    private float FireBig_Score = 250f;

    private float Heal_Score = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        ID = GetInstanceID();

        enemyHealth = FindObjectOfType<EnemyHealth>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        cameraShake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();
        _ultimate = FindObjectOfType<PlayerUltimate>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Transition();
    }

    public void Transition()
    {
        if (CanMerge)
        {
            transform.position = Vector2.MoveTowards(Obj1.position, Obj2.position, MergeSpeed);
            if (Vector2.Distance(Obj1.position, Obj2.position) < Distance)
            {
                if (ID < Obj2.gameObject.GetComponent<MergeObject>().ID) { return; }
                GameObject Obj = Instantiate(MergeTo, transform.position, Quaternion.identity) as GameObject;
                Destroy(Obj2.gameObject);
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(clip, this.gameObject.transform.position);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        bool isBelowLine = col.transform.position.y <= Line.transform.position.y + offset || transform.position.y <= Line.transform.position.y + offset;

        if (isBelowLine)
        {
            if (col.gameObject.CompareTag("Lighting") && col.gameObject.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
            {
                Merging(col);
                
                enemyHealth.TakeDamage(Lighting_Score);

                GameObject popup = Instantiate(popUp, _spawnPopUp.transform.position, Quaternion.identity);
                popup.GetComponentInChildren<TMPro.TMP_Text>().text = Lighting_Score.ToString();

                cameraShake.CanShake();
                _ultimate.AddMana(_minaddMana);
            }
            else if (col.gameObject.CompareTag("Fire") && col.gameObject.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
            {
                Merging(col);
                
                enemyHealth.TakeDamage(Fire_Score);

                GameObject popup = Instantiate(popUp, _spawnPopUp.transform.position, Quaternion.identity);
                popup.GetComponentInChildren<TMPro.TMP_Text>().text = Fire_Score.ToString();

                cameraShake.CanShake();
                _ultimate.AddMana(_minaddMana);
            }
            else if (col.gameObject.CompareTag("FireMid") && col.gameObject.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
            {
                Merging(col);
                
                enemyHealth.TakeDamage(FireMid_Score);

                GameObject popup = Instantiate(popUp, _spawnPopUp.transform.position, Quaternion.identity);
                popup.GetComponentInChildren<TMPro.TMP_Text>().text = FireMid_Score.ToString();

                cameraShake.CanShake();
                _ultimate.AddMana(_minaddMana);
            }
            else if (col.gameObject.CompareTag("FireBig") && col.gameObject.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
            {
                Merging(col);
                
                enemyHealth.TakeDamage(FireBig_Score);

                GameObject popup = Instantiate(popUp, _spawnPopUp.transform.position, Quaternion.identity);
                popup.GetComponentInChildren<TMPro.TMP_Text>().text = FireBig_Score.ToString();

                cameraShake.CanShake();
                _ultimate.AddMana(_MaxaddMana);
            }

            else if (col.gameObject.CompareTag("LightingMid") && col.gameObject.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
            {
                Merging(col);
                
                enemyHealth.TakeDamage(LightingMid_Score);

                GameObject popup = Instantiate(popUp, _spawnPopUp.transform.position, Quaternion.identity);
                popup.GetComponentInChildren<TMPro.TMP_Text>().text = LightingMid_Score.ToString();

                cameraShake.CanShake();
                _ultimate.AddMana(_minaddMana);
            }

            else if (col.gameObject.CompareTag("LightingBig") && col.gameObject.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
            {
                Merging(col);
                
                enemyHealth.TakeDamage(LightingBig_Score);

                GameObject popup = Instantiate(popUp, _spawnPopUp.transform.position, Quaternion.identity);
                popup.GetComponentInChildren<TMPro.TMP_Text>().text = LightingBig_Score.ToString();

                cameraShake.CanShake();
                _ultimate.AddMana(_MaxaddMana);
            }

            else if (col.gameObject.CompareTag("Heal") && col.gameObject.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
            {
                Merging(col);
                playerHealth.Healing(Heal_Score);
                cameraShake.CanShake();
                Destroy(gameObject);
            }

            else if (col.gameObject.CompareTag("Freeze") && col.gameObject.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
            {
                Merging(col);
                Timer timer = FindAnyObjectByType<Timer>();
                timer.PauseTimer();
                cameraShake.CanShake();
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(clip, this.gameObject.transform.position);
            }
        }
    }

    private void Merging(Collision2D col)
    {
        Obj1 = transform;
        Obj2 = col.transform;
        CanMerge = true;
        Instantiate(Effect, transform.position, Quaternion.identity);
        Destroy(col.gameObject.GetComponent<Rigidbody2D>());
        Destroy(GetComponent<Rigidbody2D>());
    }
}
