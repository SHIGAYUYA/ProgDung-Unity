using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayManeger : MonoBehaviour
{
    private string script = "def operate(array)\n" +
                            "	#この下の行にソースを入力\n" +
                            "	\n" +
                            "end";
    private string method_name = "operate";
    private string augments_name = "array";
    private string limit = "10";

    private object[] ruby_argments;

    private ProgramToolsController programTools;

    private PlayerController player;

    private int[] array;
    private int[] init_array = new int[] { 100, 200, 300, 400, 500, 5123 };
    private int[] result_array = new int[] { 9, 5, 3, 4, 2, 6 };

    private UserDataManager dataManager;

    public string first_flag;
    public string second_flag;

    private GameObject kirakira;

    private GameObject[] boxes;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        //カメラ追従用
        player.mainCamObj = Camera.main.gameObject;
        player.setCameraPos();

        dataManager = GameObject.Find("UserDataManager").GetComponent<UserDataManager>();

        kirakira = GameObject.Find("Yellow");
        kirakira.SetActive(false);

        boxes = new GameObject[5];
        boxes[0] = GameObject.Find("box");
        boxes[1] = GameObject.Find("box (1)");
        boxes[2] = GameObject.Find("box (2)");
        boxes[3] = GameObject.Find("box (3)");
        boxes[4] = GameObject.Find("box (4)");
        if (dataManager.getFlag(second_flag))
        {
            for(int i = 0; i < boxes.Length; i++)
            {
                boxes[i].SetActive(false);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ruby_argments = new object[1];
        array = new int[6];
        System.Array.Copy(init_array, array, init_array.Length);
        ruby_argments[0] = array;

        programTools = GameObject.Find("ProgramTools").GetComponent<ProgramToolsController>();
        programTools.setProgram(script, method_name, augments_name, limit, ruby_argments);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            programTools.closeEditor();
        }
    }

    public void runScript()
    {
        System.Array.Copy(init_array, array, init_array.Length);

        programTools.runScript();

        if (!dataManager.getFlag(first_flag))
        {
            if (array[0] == init_array[init_array.Length - 1])
            {
                kirakira.SetActive(true);
            }
        }
        else
        {
            bool flag = true;
            for (int i = 0; i < result_array.Length; i++)
            {
                if (result_array[i] != array[i])
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                dataManager.setFlag(second_flag);

                for (int i = 0; i < boxes.Length; i++)
                {
                    boxes[i].SetActive(false);
                }                
            }
        }
    }
}
