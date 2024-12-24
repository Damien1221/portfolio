using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float SpawnInterval = 1f;

    private float _spawnTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _spawnTimer = SpawnInterval;

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 randomSpawnPosition = new Vector3(Random.Range(-7.5f, 6.5f), 4f, 0);

        //if (_spawnTimer > 0)
        //{
        //    _spawnTimer -= Time.deltaTime;
        //}
        //else
        //{
        //    //GameObject.Instantiate(Enemy, randomSpawnPosition, Quaternion.identity);
        //    //_spawnTimer = SpawnInterval;
        //}
    }

    public void SpawnAttack()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-7.2f, -2.7f), 1.5f, 0);
        GameObject.Instantiate(Enemy, randomSpawnPosition, Quaternion.identity);
    }
}
