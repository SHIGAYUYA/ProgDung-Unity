using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;
using IronRuby;
using Microsoft.Scripting.Hosting;
using System.IO;

public class PCController : MonoBehaviour
{
    private ProgramToolsController programTools;

    // Start is called before the first frame update
    void Start()
    {
        programTools = GameObject.Find("ProgramTools").GetComponent<ProgramToolsController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openEditer()
    {
        programTools.openEditor();
    }
}
