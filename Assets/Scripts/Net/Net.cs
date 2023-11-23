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

    //���o�ѪR��
    public Dictionary<Type, Action<Cmd>> parserDict = new();

    public Net()
    {
        //���U�n���o������
        //parserDict.Add(typeof(IsLoginSuccess), Login.instance.LoginSuccess);
    }


    public void Connect(Action successCallback,Action failedCallBack )
    {
        Debug.Log("�}�l�A�Ⱦ��s��");

        //��server����
        server = Server.instance;
        server.Connected(this);


        //�o�̶}�o���q�u�P�w���\
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
        Debug.Log("�Ȥ�ݦ������" + cmd.GetType());

        //�ή����ѪR���h���o����
        if (parserDict.ContainsKey(cmd.GetType()))
        {
            parserDict[cmd.GetType()](cmd);
        }
        else
        {
            Debug.Log($"S_�����o���� {cmd.GetType()}");
        }

    }

    public void SendCmd(Cmd cmd)
    {
        server.Recive(cmd);
    }

   
}
