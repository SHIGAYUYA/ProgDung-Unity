using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private Collider2D co2D;

    private int opening = 0;
    private bool stay;
    public bool open_flag = true;

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
}
