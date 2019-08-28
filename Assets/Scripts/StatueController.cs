using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueController : MonoBehaviour
{
    private int current_state = -1;
    Queue<int> state_queue;
    private float speed = 0.1f;

    void Start()
    {
        state_queue = new Queue<int>();
    }

    void Update()
    {
        if(current_state == -1 && state_queue.Count != 0)
        {
            current_state = state_queue.Dequeue();
        }

        switch (current_state)
        {
            case 0:
                transform.Translate(0, speed, 0);
                break;
            case 1:
                transform.Translate(speed, 0, 0);
                break;
            case 2:
                transform.Translate(0, -speed, 0);
                break;
            case 3:
                transform.Translate(-speed, 0, 0);
                break;
            default:
                break;
        }
    }

    public void moveUp()
    {
        state_queue.Enqueue(0);
    }
    public void moveRight()
    {
        state_queue.Enqueue(1);
    }
    public void moveDown()
    {
        state_queue.Enqueue(2);
    }
    public void moveLeft()
    {
        state_queue.Enqueue(3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        current_state = -1;
    }
}
