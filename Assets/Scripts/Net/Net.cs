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


    public void Connect(Action successCallback,Action failedCallBack )
    {
        Debug.Log("開始服務器連接");
        //給server附值
        server = Server.instance.Connected(this);

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
                successCallback();
            }
        }
       
    }

    public void Recive(Cmd cmd)
    {
        Debug.Log("客戶端收到消息" + cmd.GetType());
    }

    public void SendCmd(Cmd cmd)
    {
        server.Recive(cmd);
    }

   
}
