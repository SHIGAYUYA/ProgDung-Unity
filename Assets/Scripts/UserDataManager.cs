using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    string user_name;
    
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool login(string u, string password)
    {
        if(password == "" || password == "")
        {
            return false;
        }


        this.user_name = u;

        return true;
        //TODO サーバーとの通信
    }

    public void logout()
    {
        this.user_name = "";
        
        //TODO サーバーとの通信??
    }
}
