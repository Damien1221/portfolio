using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSelect : MonoBehaviour
{
    public GameObject HighLight;

    private GameObject newSelection;

    public bool is_Selection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        
    }

    private void OnMouseEnter()
    {
        if (newSelection == null)
        {
            newSelection = Instantiate(HighLight, transform.position, Quaternion.identity);
            newSelection.transform.SetParent(gameObject.transform);
            newSelection.SetActive(false);
        }

        is_Selection = !is_Selection;

        if (is_Selection)
        {
            newSelection.SetActive(true);
        }
        else
        {
            newSelection.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        is_Selection = !is_Selection;

        if (is_Selection)
        {
            newSelection.SetActive(true);
        }
        else
        {
            newSelection.SetActive(false);
        }
    }
}
