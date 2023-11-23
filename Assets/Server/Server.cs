using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public interface IServer
{
    void Connected(IClinet clinet);
    void SendCmd(Cmd cmd);
    void Recive(Cmd cmd);
}

public class Server : Singleton<Server>, IServer
{
    IClinet clinet;

    //分發解析器
    Dictionary<Type,Action<Cmd>> parserDict = new ();

    //暫時只保留一個玩家
    public Player curPlayer;


    public Server()
    {
        //註冊要分發的消息
        parserDict.Add(typeof(LoginCmd), CmdParser.OnLogin);
    }


    public void Connected(IClinet clinet)
    {
        Debug.Log("S_服務器收到連接");
        this.clinet = clinet;
        //return this;

    }

    public void Recive(Cmd cmd)
    {
        Debug.Log("S_服務器收到消息" + cmd.GetType());

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
        clinet.Recive(cmd);
    }


}
