using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

//未分模塊的消息解析器
public class CmdParser
{
    public static void OnLogin(Cmd cmd)
    {
        Debug.Log("S_OnLogin");

        LoginCmd loginCmd = cmd as LoginCmd;
        if (loginCmd == null) 
        {
            Debug.LogError($"S_需要{typeof(LoginCmd)}但收到{cmd.GetType()}");
        }

        //驗證
        //找到玩家的資料
        Server.instance.curPlayer = new Player();
        var player = Server.instance.curPlayer;

        //向客戶端發送消息
        Server.instance.SendCmd(new IsLoginSuccess() {});
    }


}

