using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    private List<GameObject> targets;

    public GameObject Target
    {
        get {
            deleatNull();
            if (targets.Count == 0)
            {
                return null;
            }
            return targets[0]; }
    }

    void Start()
    {
        targets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.name.Contains("Tile"))
        {
            targets.Add(collision.gameObject);
            Debug.Log(collision.gameObject);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.name.Contains("Tile"))
        {
            targets.Remove(collision.gameObject);
            Debug.Log(collision.gameObject);
        }
    }

    private void deleatNull()
    {
        foreach (GameObject item in targets.ToArray())
        {
            if (item == null)
            {
                targets.Remove(item);
            }
        }
    }
}
