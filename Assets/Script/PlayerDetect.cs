using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    FollowMouse followMouse;

    // Start is called before the first frame update
    void Start()
    {
        followMouse = FindObjectOfType<FollowMouse>();

        followMouse.SpawnObject();
    }

    public void OnMouseOver()
    {
        Debug.Log("Mouse Entering");
        
        if (Input.GetButtonDown("Fire1"))
        {
            followMouse.Drop();
        }
    }

    public void OnMouseExit()
    {
        Debug.Log("Mouse Exit liao");
    }
}
