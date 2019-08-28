using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    private HitCheck top;
    private HitCheck right;
    private HitCheck bottom;
    private HitCheck left;

    GameObject mainCamObj;

    public float speed = 0.1f;
    public int direction = 1;

    public bool poseFlag = false;

    public bool PoseFlag { set { poseFlag = value; } }

    // Start is called before the first frame update
    void Start()
    {
        //カメラ追従用
        mainCamObj = Camera.main.gameObject;
        setCameraPos();

        //アニメーション用
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        animator.SetInteger("Direction", direction);


        top = transform.Find("TopBox").GetComponent<HitCheck>();
        right = transform.Find("RightBox").GetComponent<HitCheck>();
        bottom = transform.Find("BottomBox").GetComponent<HitCheck>();
        left = transform.Find("LeftBox").GetComponent<HitCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (poseFlag)
        {
            return;
        }

        // 移動
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetInteger("Direction", 0);
            transform.Translate(0, speed, 0);
            direction = 0;
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetInteger("Direction", 1);
            transform.Translate(speed, 0, 0);
            direction = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetInteger("Direction", 2);
            transform.Translate(0, -speed, 0);
            direction = 2;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetInteger("Direction", 3);
            transform.Translate(-speed, 0, 0);
            direction = 3;
        }

        if (Input.GetKey("c"))
        {
            if (direction == 0)
            {
                checkObject(top.Target);
            }
            else if (direction == 1)
            {
                checkObject(right.Target);
            }
            else if (direction == 2)
            {
                checkObject(bottom.Target);
            }
            else if (direction == 3)
            {
                checkObject(left.Target);
            }
        }

        //カメラ位置更新
        setCameraPos();
    }

    private void setCameraPos()
    {
        Vector3 playerPos = transform.position;
        Vector3 cameraPos = mainCamObj.transform.position;

        cameraPos.x = playerPos.x;
        cameraPos.y = playerPos.y;

        mainCamObj.transform.position = cameraPos;
    }

    private void checkObject(GameObject target)
    {
        // PCの場合
        PCController pc = target.GetComponent<PCController>();
        if(pc != null)
        {
            pc.openEditer();
            return;
        }

        // 本棚の場合
        MessageController mes = target.GetComponent<MessageController>();
        if (mes != null)
        {
            mes.openMassage();
            return;
        }
    }
}
