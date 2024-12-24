using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public GameObject Effect;
    public GameObject popUp;
    //public Transform _spawnPopUp;
    public float Damage = 20f;

    private PlayerHealth _playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = FindAnyObjectByType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Fire")|| col.gameObject.CompareTag("FireMid")|| col.gameObject.CompareTag("FireBig")|| 
           col.gameObject.CompareTag("Heal")|| col.gameObject.CompareTag("Lighting")|| col.gameObject.CompareTag("LightingMid")
         ||col.gameObject.CompareTag("LightingBig")|| col.gameObject.CompareTag("Freeze"))
        {
            Destroy(col.gameObject);
            _playerHealth.TakeDamage(Damage);

            GameObject popup = Instantiate(popUp, transform.position, Quaternion.identity);
            popup.GetComponentInChildren<TMPro.TMP_Text>().text = Damage.ToString();

            Instantiate(Effect, transform.position, Quaternion.identity);
        }
        
    }
}
