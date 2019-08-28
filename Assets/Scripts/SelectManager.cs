using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    UserDataManager user_data;
    
    void Start()
    {
        user_data = GameObject.Find("UserDataManager").GetComponent<UserDataManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickReturnButton()
    {
        this.user_data.logout();
        //画面切り替え
        SceneManager.LoadScene("TitleScene");
    }
}
