using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public interface IServer
{
    IServer Connected(IClinet clinet);
    void SendCmd(Cmd cmd);
    void Recive(Cmd cmd);
}

public class Server : Singleton<Server>, IServer
{
    IClinet clinet;
    public IServer Connected(IClinet clinet)
    {
        Debug.Log("服務器收到連接");
        this.clinet = clinet;
        return this;

    }

    public void Recive(Cmd cmd)
    {
        Debug.Log("服務器收到消息" + cmd.GetType());
    }

    public void SendCmd(Cmd cmd)
    {
        clinet.Recive(cmd);
    }
}
