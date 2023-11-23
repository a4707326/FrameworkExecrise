using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IClinet
{
    //void Connect();
    void SendCmd(Cmd cmd);
    void Recive(Cmd cmd);
}



//客戶端訪問服務器
public class Net : Singleton<Net>, IClinet
{
    IServer server;

    //分發解析器
    public Dictionary<Type, Action<Cmd>> parserDict = new();

    public Net()
    {
        //註冊要分發的消息
        //parserDict.Add(typeof(IsLoginSuccess), Login.instance.LoginSuccess);
    }


    public void Connect(Action successCallback,Action failedCallBack )
    {
        Debug.Log("開始服務器連接");

        //給server附值
        server = Server.instance;
        server.Connected(this);


        //這裡開發階段只判定成功
        if ( true )
        {
            if (successCallback != null)
            {
                successCallback();
            }
        }
        else
        {
            if (failedCallBack != null)
            {
                failedCallBack();
            }
        }
       
    }

    public void Recive(Cmd cmd)
    {
        Debug.Log("客戶端收到消息" + cmd.GetType());

        //用消息解析器去分發任務
        if (parserDict.ContainsKey(cmd.GetType()))
        {
            parserDict[cmd.GetType()](cmd);
        }
        else
        {
            Debug.Log($"S_未分發消息 {cmd.GetType()}");
        }

    }

    public void SendCmd(Cmd cmd)
    {
        server.Recive(cmd);
    }

   
}
