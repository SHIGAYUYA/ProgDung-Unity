using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptEditorController : MonoBehaviour
{
    InputField input;
    Text script_text;

    public string Script
    {
        get { return script_text.text; }
    }

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputField>();
        script_text = transform.Find("Script").gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startProgramming(string script)
    {
        GetComponent<Image>().enabled = true;
        var input = GetComponent<InputField>();
        input.enabled = true;
        script_text.enabled = true;
        input.text = script;
    }

    public string stopProgramming()
    {
        GetComponent<Image>().enabled = false;
        var input = GetComponent<InputField>();
        input.enabled = false;
        script_text.enabled = false;
        return input.text;
    }
}
