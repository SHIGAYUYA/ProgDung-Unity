using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasiccalcManager : MonoBehaviour
{
    private string script = "def run(calc, oke, hako, tubo_covered)\n" +
                            "	#この下の行にソースを入力\n" +
                            "	\n" +
                            "end";
    private string method_name = "calc";
    private string augments_name = "tubo, oke, hako, tubo_covered";
    private string limit = "10";

    private Object[] ruby_argments;

    private ProgramToolsController programTools;

    private PlayerController player;

    private void Awake()
    {
        //GameObject player_pre = (GameObject)Resources.Load("Maps/Player/Player");

        player = GameObject.Find("Player").GetComponent<PlayerController>();
        //カメラ追従用
        player.mainCamObj = Camera.main.gameObject;
        player.setCameraPos();
    }

    // Start is called before the first frame update
    void Start()
    {
        ruby_argments = new Object[4];
        ruby_argments[0] = GameObject.Find("tubo").GetComponent<ContainerContorller>();
        ruby_argments[1] = GameObject.Find("oke").GetComponent<ContainerContorller>();
        ruby_argments[2] = GameObject.Find("hako").GetComponent<ContainerContorller>();
        ruby_argments[3] = GameObject.Find("tubo_covered").GetComponent<ContainerContorller>();

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
}
