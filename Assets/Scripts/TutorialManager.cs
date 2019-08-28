using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

    private string script = "def run(tori, robe)\n"+
                            "	#この下の行にソースを入力\n"+
                            "	p tori\n" +
                            "end";
    private string method_name = "run";
    private string augments_name = "tori, robe";
    private string limit = "10";

    private Object[] ruby_argments;


    private ProgramToolsController programTools;

    // Start is called before the first frame update
    void Start()
    {
        ruby_argments = new Object[2];
        ruby_argments[0] = GameObject.Find("Tori").GetComponent<StatueController>();
        ruby_argments[1] = GameObject.Find("Robe").GetComponent<StatueController>();

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
