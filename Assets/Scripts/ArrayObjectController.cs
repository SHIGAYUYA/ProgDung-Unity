using IronRuby;
using IronRuby.Builtins;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrayObjectController : MonoBehaviour
{
    public string set_flag_name;

    public GameObject messageBox;
    public Text message_text;
    [TextArea]
    public string success_mesasge;
    [TextArea]
    public string failed_mesasge;
    public int line_num;
    public int line_char_num;

    private string[] message_lines;

    private bool massage_flag = false;
    private int current_line = 0;
    private int update_interval = 0;

    private PlayerController player;

    private UserDataManager dataManager;

    private int[] playerArray = { 0, 0, 0, 0, 0, 0, 0, 0 };
    private int[] answerArray = { 0, 1, 1, 0, 1, 0, 0, 1 };

    private GameObject mahouzin;

    private GameObject[] shields;

    public Sprite on_img;
    public Sprite off_img;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        dataManager = GameObject.Find("UserDataManager").GetComponent<UserDataManager>();

        mahouzin = GameObject.Find("mahouzin");

        if (!dataManager.getFlag(set_flag_name))
        {
            mahouzin.SetActive(false);
        }

        shields = new GameObject[8];
        shields[0] = GameObject.Find("tate_off");
        shields[1] = GameObject.Find("tate_off (1)");
        shields[2] = GameObject.Find("tate_off (2)");
        shields[3] = GameObject.Find("tate_off (3)");
        shields[4] = GameObject.Find("tate_off (4)");
        shields[5] = GameObject.Find("tate_off (5)");
        shields[6] = GameObject.Find("tate_off (6)");
        shields[7] = GameObject.Find("tate_off (7)");
    }

    // Update is called once per frame
    void Update()
    {
        if (massage_flag)
        {
            if (Input.anyKey && !Input.GetKey("c"))
            {
                update_interval++;
            }
            else
            {
                update_interval = 0;
            }
            if (update_interval > 5)
            {
                current_line++;
                update_interval = 0;
            }

            if (current_line >= message_lines.Length)
            {
                massage_flag = false;
                messageBox.SetActive(false);
                player.PoseFlag = false;

                //フラグをセットしたか & 正解チェック
                if (!dataManager.getFlag(set_flag_name) && this.checkResult())
                {
                    //フラグ立てる
                    dataManager.setFlag(set_flag_name);
                }

                return;
            }

            int head = 0;
            if (current_line >= line_num)
            {
                head = current_line - line_num + 1;
            }

            message_text.text = "";

            //Debug.Log(current_line);
            for (int i = head; i <= current_line; i++)
            {
                Debug.Log(message_text);
                message_text.text += message_lines[i];
            }
        }


    }

    public void openMassage()
    {
        massage_flag = true;
        current_line = 0;
        messageBox.SetActive(true);
        player.PoseFlag = true;

        // チェック
        if (this.checkResult())
        {
            mahouzin.SetActive(true);
            message_parse(success_mesasge);
        }
        else
        {
            message_parse(failed_mesasge);
        }
    }

    private void message_parse(string mesasge)
    {
        string line = "";
        var message_lines_list = new List<string>();

        foreach (char c in mesasge)
        {
            line += c;
            if (c == '\n')
            {
                message_lines_list.Add(line);
                line = "";
            }

            if (line.Length >= line_char_num)
            {
                line += "\n";
                message_lines_list.Add(line);
                line = "";
            }
        }
        //Debug.Log(line);
        message_lines_list.Add(line);

        message_lines = message_lines_list.ToArray();
    }

    public RubyArray getArray()
    {
        RubyArray a = new RubyArray();
        
        for (int i = 0; i < answerArray.Length; i++)
        {
            a.Add(answerArray[i]);
        }

        return a;
    }

    public void setResult(RubyArray array)
    {
        int length = array.Count;
        if (length > answerArray.Length)
        {
            return;
        }
        for (int i = 0; i < length; i++)
        {
            if (array[i].GetType() == typeof(MutableString))
            {
                MutableString value = (MutableString)array[i];
                if (value.ToString() == "on")
                {
                    playerArray[i] = 1;
                }
                else if (value.ToString() == "off")
                {
                    playerArray[i] = 0;
                }
            }
        }

        //画像差し替え
        for(int i = 0; i < shields.Length; i++)
        {
            Debug.Log(i);
            if (playerArray[i] == 1)
            {
                shields[i].GetComponent<SpriteRenderer>().sprite = on_img;
            }
            else
            {
                shields[i].GetComponent<SpriteRenderer>().sprite = off_img;
            }
        }
    }

    private bool checkResult()
    {
        for(int i = 0; i < answerArray.Length; i++)
        {
            if(playerArray[i] != answerArray[i])
            {
                return false;
            }
        }

        return true;
    }
}
