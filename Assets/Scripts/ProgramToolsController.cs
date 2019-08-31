using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramToolsController : MonoBehaviour
{
    private RubyManager rubyManager;

    private ScriptEditorController scriptEditor;

    private GameObject logWindow;
    private GameObject logWindowObj;

    private bool programmingFlag = false;
    private PlayerController player;

    private string _script;
    private string _method_name;
    private string _augments_name;
    private string _limit;
    private System.Object[] _argments;

    private GameObject runBtn;
    private GameObject clearBtn;
    private GameObject closeBtn;

    // Start is called before the first frame update
    void Start()
    {
        rubyManager = GameObject.Find("RubyManager").GetComponent<RubyManager>();

        player = GameObject.Find("Player").GetComponent<PlayerController>();
        scriptEditor = GameObject.Find("ScriptEditor").gameObject.GetComponent<ScriptEditorController>();

        logWindow = GameObject.Find("Content");
        logWindowObj = GameObject.Find("LogWindow");
        logWindowObj.SetActive(false);

        runBtn = GameObject.Find("RunBtn");
        clearBtn = GameObject.Find("ClearBtn");
        closeBtn = GameObject.Find("CloseBtn");
        runBtn.SetActive(false);
        clearBtn.SetActive(false);
        closeBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setProgram(string script, string method_name, string augments_name, string limit, object[] argments)
    {
        this._script = script;
        this._method_name = method_name;
        this._augments_name = augments_name;
        this._limit = limit;
        this._argments = argments;
    }

    public void runScript()
    {
        _script = scriptEditor.Script;
        rubyManager.runRuby(logWindow, _script, _method_name, _augments_name, _limit, _argments);
    }

    public string runScriptExtrn()
    {
        _script = scriptEditor.Script;
        return rubyManager.runRuby(logWindow, _script, _method_name, _augments_name, _limit, _argments);
    }

    public void openEditor()
    {
        if (!programmingFlag)
        {
            player.PoseFlag = true;
            programmingFlag = true;
            scriptEditor.startProgramming(_script);
            logWindowObj.SetActive(true);
            runBtn.SetActive(true);
            clearBtn.SetActive(true);
            closeBtn.SetActive(true);
        }
    }

    public void closeEditor()
    {
        player.PoseFlag = false;
        programmingFlag = false;
        _script = scriptEditor.stopProgramming();
        logWindowObj.SetActive(false);
        runBtn.SetActive(false);
        clearBtn.SetActive(false);
        closeBtn.SetActive(false);
    }

    public void clearLogWindow()
    {
        foreach (Transform n in logWindow.transform)
        {
            GameObject.Destroy(n.gameObject);
        }
    }
}
