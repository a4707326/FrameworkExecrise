using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class UserDB : TableDB
{
    public string userID;
    public string name;
    public int money;
    public int avatarID;
}


public class UserTable : ConfigTable<UserDB, UserTable>
{

    public UserTable()
    {
        Load("Config/UserTable.csv");

    }

    //protected override void PraserItem(UserData db, string[] itemStrArray)
    //{
    //    db.userID = itemStrArray[1];
    //    db.name = itemStrArray[2];
    //    db.money = int.Parse(itemStrArray[3]);
    //}



}
