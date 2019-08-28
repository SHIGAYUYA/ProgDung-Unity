using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    GameObject logo;
    GameObject user_field;
    GameObject password_field;

    UserDataManager user_data;

    Sprite title_img;
    Sprite select_img;

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクト取得
        logo = GameObject.Find("Logo");
        user_field = GameObject.Find("UserField");
        password_field = GameObject.Find("PasswordField");
        user_data = GameObject.Find("UserDataManager").GetComponent<UserDataManager>();

        //初期画面配置
        //GameObject image_object = GameObject.Find("BackGround");
        //background = image_object.GetComponent<Image>();
        //background.sprite = title_img;

        //Button button = new GameObject().AddComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void onClickLoginButton()
    {
        //仮で画面切り替えのみ(空値処理のみ)
        if (this.user_data.login(((InputField)(user_field.GetComponent<InputField>())).text, ((InputField)(password_field.GetComponent<InputField>())).text))
        {
            SceneManager.LoadScene("SelectScene");
        }

        //ログイン処理
        //if (pCallback.login(lUserField.getText(), lPassField.getPassword()))
        //{
        //    try
        //    {
        //        Thread.sleep(500);
        //    }
        //    catch (InterruptedException e1)
        //    {
        //    }
        //    pCallback.loadUserData();
        //    pCallback.showSelect(pCallback);
        //}
        //else
        //{
        //    JOptionPane.showMessageDialog(TitlePanel.this, "ログインできません", "", JOptionPane.ERROR_MESSAGE);
        //}
    }


}
