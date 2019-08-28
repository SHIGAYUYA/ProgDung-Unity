using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    private GameObject target;

    public GameObject Target
    {
        get { return target; }
    }

    void Start()
    {
        target = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.name.Contains("Tile"))
        {
            target = collision.gameObject;
            //Debug.Log(target);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.name.Contains("Tile"))
        {
            target = null;
            //Debug.Log(target);
        }
    }

    
}
