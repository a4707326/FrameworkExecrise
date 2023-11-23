using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    private InputField _account_IF;
    private InputField _password_IF;
    private Button _start_Btn;

    //public static Login instance;

    private void Awake()
    {
        //instance = this;
        //註冊分發
        Net.instance.parserDict.Add(typeof(LoginSuccessCmd), LoginSuccess);
        Net.instance.parserDict.Add(typeof(LoginFaildCmd), LoginSuccess);

        //元件初始化
        _account_IF = transform.Find<InputField>("Account_IF");
        _password_IF = transform.Find<InputField>("Password_IF");
        _start_Btn = transform.Find<Button>("Start_Btn");
        _start_Btn.onClick.AddListener(OnStartClick);
    }
    void Start()
    {

    }

    private void OnStartClick()
    {
        Debug.Log("OnStartClick");

        //判斷格式
        string account = _account_IF.text;
        string password = _password_IF.text;
        if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
        {
            Debug.Log("格式錯誤");
            return;
        }

        //鎖UI
        _account_IF.enabled = false;
        _password_IF.enabled = false;
        _start_Btn.enabled = false;

        //連接服務器
        Net.instance.Connect(DoSuccess, DoFaild);
    }

    private void DoSuccess()
    {
        Debug.Log("連接成功");
        string account = _account_IF.text;
        string password = _password_IF.text;
        //發送登入
        Net.instance.SendCmd(new LoginCmd() { account = account, password = password });

    }

    private void DoFaild()
    {
        Debug.Log("連接失敗");
        //解鎖還原
        _account_IF.enabled = true;
        _password_IF.enabled = true;
        _start_Btn.enabled = true;
    }

    public void LoginSuccess(Cmd cmd)
    {
        Debug.Log("登入成功");

        //LoginSuccessCmd data = cmd as LoginSuccessCmd;
        //if (data == null)
        //{
        //    Debug.LogError($"S_需要{typeof(LoginSuccessCmd)}但收到{cmd.GetType()}");
        //}

        //檢查協議正確性
        if (!Net.CheckCmd(cmd, typeof(LoginSuccessCmd))) return;


        LoginSuccessCmd data = cmd as LoginSuccessCmd;
        UserData.instance.userID = data.userID;
        UserData.instance.name = data.name;
        UserData.instance.money = data.money;
        UserData.instance.avatarID = data.avatarID;

        //UserData.instance.UserDataParse(cmd);


        SceneManager.LoadScene("Lobby");


    }
    public void IsLoginFaild(Cmd cmd)
    {
        Debug.Log("登入失敗");
        //解鎖還原
        _account_IF.enabled = true;
        _password_IF.enabled = true;
        _start_Btn.enabled = true;
    }


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
