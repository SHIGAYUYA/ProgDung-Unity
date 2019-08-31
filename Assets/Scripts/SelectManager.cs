using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    UserDataManager user_data;

    GameObject player;
    GameObject massageCanvas;

    void Start()
    {
        user_data = GameObject.Find("UserDataManager").GetComponent<UserDataManager>();
        DontDestroyOnLoad(user_data);

        player = GameObject.Find("Player");
        DontDestroyOnLoad(player);
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickBiginnerButton()
    {
        player.SetActive(true);
        player.transform.position = new Vector3(19.96f, 1.49f, -2.0f);
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.Direction = 0;

        SceneManager.LoadScene("LobbyScene");
    }

    public void onClickReturnButton()
    {
        this.user_data.logout();
        //画面切り替え

        SceneManager.LoadScene("TitleScene");
    }
}
