using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;


public class UserData : BaseData<UserData>
{

    public string userID;
    public string name;
    public int money;
    public int avatarID;


    //public void UserDataParse(Cmd cmd)
    //{
    //    Net.CheckCmd(cmd,)
    //    LoginSuccessCmd data = cmd as LoginSuccessCmd;
    //    userID = data.userID;
    //    name = data.name;
    //    money = data.money;
    //    avatarID = data.avatarID;
    //}

    ////public static List<UserData> userDataList = new ();
    //public UserData userData = new ();

    //public UserDataMgr()
    //{
    //    userData.userID = "0001";
    //    userData.name = "玩家1";
    //    userData.money = 5000;
    //    userData.avatarID = 0;
    //}
}

