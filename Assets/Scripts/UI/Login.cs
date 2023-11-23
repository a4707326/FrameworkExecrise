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
        //���U���o
        Net.instance.parserDict.Add(typeof(LoginSuccessCmd), LoginSuccess);
        Net.instance.parserDict.Add(typeof(LoginFaildCmd), LoginSuccess);

        //�����l��
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

        //�P�_�榡
        string account = _account_IF.text;
        string password = _password_IF.text;
        if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
        {
            Debug.Log("�榡���~");
            return;
        }

        //��UI
        _account_IF.enabled = false;
        _password_IF.enabled = false;
        _start_Btn.enabled = false;

        //�s���A�Ⱦ�
        Net.instance.Connect(DoSuccess, DoFaild);
    }

    private void DoSuccess()
    {
        Debug.Log("�s�����\");
        string account = _account_IF.text;
        string password = _password_IF.text;
        //�o�e�n�J
        Net.instance.SendCmd(new LoginCmd() { account = account, password = password });

    }

    private void DoFaild()
    {
        Debug.Log("�s������");
        //�����٭�
        _account_IF.enabled = true;
        _password_IF.enabled = true;
        _start_Btn.enabled = true;
    }

    public void LoginSuccess(Cmd cmd)
    {
        Debug.Log("�n�J���\");

        //LoginSuccessCmd data = cmd as LoginSuccessCmd;
        //if (data == null)
        //{
        //    Debug.LogError($"S_�ݭn{typeof(LoginSuccessCmd)}������{cmd.GetType()}");
        //}

        //�ˬd��ĳ���T��
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
        Debug.Log("�n�J����");
        //�����٭�
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
