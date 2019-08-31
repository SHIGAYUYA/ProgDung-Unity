using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardArrayManager : MonoBehaviour
{
    private string script = "def operate(ido)\n" +
                            "	#この下の行にソースを入力\n" +
                            "	\n" +
                            "end";
    private string method_name = "operate";
    private string augments_name = "ido";
    private string limit = "10";

    private object[] ruby_argments;

    private ProgramToolsController programTools;

    private PlayerController player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        //カメラ追従用
        player.mainCamObj = Camera.main.gameObject;
        player.setCameraPos();
    }

    // Start is called before the first frame update
    void Start()
    {
        ruby_argments = new object[1];

        ruby_argments[0] = GameObject.Find("ido").GetComponent<ArrayObjectController>();

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
