using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private Collider2D co2D;

    private int opening = 0;
    private bool stay;
    public bool open_flag = true;

    public string scene_name;
    public float next_x;
    public float next_y;
    public int next_direction;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        co2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (open_flag)
        {
            if (stay == true && opening < 40)
            {
                opening += 1;
            }
            else if (stay == false && opening > 0)
            {
                opening -= 1;
            }
        }

        if (opening > 39)
        {
            co2D.isTrigger = true;
        }
        else
        {
            co2D.isTrigger = false;
        }
        

        animator.SetInteger("Opening", opening);
    }

    public void setStay(bool flag)
    {
        stay = flag;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (opening > 39)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                Vector3 pos = collision.gameObject.transform.position;
                pos.x = next_x;
                pos.y = next_y;
                collision.gameObject.transform.position = pos;
                PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
                playerController.Direction = next_direction;

                SceneManager.LoadScene(scene_name);
            }
        }
    }
}
