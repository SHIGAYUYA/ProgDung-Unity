using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAreaController : MonoBehaviour
{

    private GameObject _parent;
    private DoorController door_controller;
    // Start is called before the first frame update

    void Start()
    {
        //親オブジェクトを取得
        _parent = transform.root.gameObject;
        door_controller = _parent.GetComponent<DoorController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        door_controller.setStay(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        door_controller.setStay(false);
    }
}
