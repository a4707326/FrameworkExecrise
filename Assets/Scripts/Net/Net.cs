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



//�Ȥ�ݳX�ݪA�Ⱦ�
public class Net : Singleton<Net>, IClinet
{
    IServer server;


    public void Connect(Action successCallback,Action failedCallBack )
    {
        Debug.Log("�}�l�A�Ⱦ��s��");
        //��server����
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
        Debug.Log("�Ȥ�ݦ������" + cmd.GetType());
    }

    public void SendCmd(Cmd cmd)
    {
        server.Recive(cmd);
    }

   
}
