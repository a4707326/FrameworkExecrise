using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class BaseData<T> : Singleton<T> where T : new() 
{
    //public void Parse(Cmd cmd,Type type)
    //{



    //    var data = cmd as ;
    //    if (data == null)
    //    {
    //        Debug.LogError($"S_需要{typeof(LoginSuccessCmd)}但收到{cmd.GetType()}");
    //    }
    //    //userID = data.userID;
    //    //name = data.name;
    //    //money = data.money;
    //    //avatarID = data.avatarID;
    //}

}

