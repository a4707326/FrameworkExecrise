using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    private InputField _account_IF;
    private InputField _password_IF;
    private Button _start_Btn;

    private void Awake()
    {
        _account_IF = transform.Find<InputField>("Account_IF");
        _password_IF = transform.Find<InputField>("Password_IF");
        _start_Btn = transform.Find<Button>("Start_Btn");
        _start_Btn.onClick.AddListener(OnStartClick);
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
        }
        else
        {
            Net.instance.Connect(DoSuccess,null);

        }


    }

    private void DoSuccess()
    {
        string account = _account_IF.text;
        string password = _password_IF.text;
        Net.instance.SendCmd(new LoginCmd() { account = account, password = password });
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
