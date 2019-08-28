using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IronRuby;
using Microsoft.Scripting.Hosting;
using System.IO;
using System.Text;
using UnityEngine.UI;
using System;

public class RubyManager : MonoBehaviour
{
    public GUIStyle style;

    // Start is called before the first frame update
    void Start()
    {
        // Rubyスクリプト・エンジンの作成
        

        

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    private GameObject textPrefab;

    public void runRuby(GameObject logWindow, string script, string method_name, string augments_name, string limit, object[] argments)
    {
        // Rubyスクリプトを実行
        var runtime = Ruby.CreateRuntime();
        var engine = runtime.GetEngine("Ruby");

        var outputStream = new MemoryStream();
        var errorStream = new MemoryStream();

        engine.Runtime.IO.SetOutput(outputStream, Encoding.UTF8);
        engine.Runtime.IO.SetErrorOutput(errorStream, Encoding.UTF8);

        ScriptScope scope = engine.CreateScope();
        var source = engine.CreateScriptSourceFromString(script);
        source.Execute(scope);

        // 無限ループ対策
        TextAsset textasset = new TextAsset(); //テキストファイルのデータを取得するインスタンスを作成
        textasset = Resources.Load("timeout", typeof(TextAsset)) as TextAsset;
        source = engine.CreateScriptSourceFromString(textasset.text);
        source.Execute(scope);

        source = engine.CreateScriptSourceFromString(setTimeout(method_name, augments_name, limit));
        source.Execute(scope);
        
        string error_log = "";
        try
        {
            engine.Operations.InvokeMember(scope, "rwrapper", argments);
        }
        catch (Exception e)
        {
            error_log = e.Message;
        }

        outputStream.Flush();
        errorStream.Flush();

        var logs = new Queue<String>();

        string output_log = Encoding.UTF8.GetString(outputStream.ToArray());
        error_log += Encoding.UTF8.GetString(errorStream.ToArray());

        StringReader strReader = new StringReader(output_log);

        string line;

        while((line = strReader.ReadLine()) != null)
        {
            textPrefab = (GameObject)Resources.Load("Prefabs/Log");
            GameObject _text_obj = Instantiate(textPrefab, logWindow.transform);
            Text _text = _text_obj.GetComponent<Text>();
            _text.text = line;
            _text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }

        strReader = new StringReader(error_log);

        Debug.Log(error_log);

        while ((line = strReader.ReadLine()) != null)
        {
            textPrefab = (GameObject)Resources.Load("Prefabs/Log");
            GameObject _text_obj = Instantiate(textPrefab, logWindow.transform);
            Text _text = _text_obj.GetComponent<Text>();
            _text.text = line;
            _text.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public string setTimeout(string method_name, string augments_name, string limit)
    {
        string rwrapper = "def rwrapper(" + augments_name + ")\n"
                + ""
                + "Timeout.timeout(" + limit + "){\n"
                + method_name + "(" + augments_name + ")\n"
                + "}\n"
                + "end";
        return rwrapper;
    }

    private async void ReadLineAsync(ScriptEngine engine)
    {
        using (MemoryStream outputStream = new MemoryStream())
        {
            engine.Runtime.IO.SetOutput(outputStream, Encoding.UTF8);
            StreamReader reader = new StreamReader(outputStream, Encoding.UTF8);

            string line;
            int count = 1;
            while ((line = await reader.ReadLineAsync()) != null)
                Debug.Log($"{count++}行目：{line}"); // 読み込んだ内容をコンソールに出力する
        }

    }
}
