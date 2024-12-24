using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Vector3 pos;
    public float speed = 2f;
    
    //public GameObject objectToSpawn;
    [SerializeField] GameObject[] ObjPrefab;

    protected GameObject currentObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SpawnObject()
    {
        //Instantiate(objectToSpawn, transform.position, transform.rotation);
        currentObj = Instantiate(ObjPrefab[Random.Range(0, ObjPrefab.Length)], transform.position , Quaternion.identity);

        currentObj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public void Drop()
    {
        currentObj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    // Update is called once per frame
    void Update()
    {
        
        pos = Input.mousePosition;
        pos.z = speed;
        transform.position = Camera.main.ScreenToWorldPoint(pos);

        if(currentObj != null)
        {
            currentObj.transform.position = pos;
        }
    }

   
}
