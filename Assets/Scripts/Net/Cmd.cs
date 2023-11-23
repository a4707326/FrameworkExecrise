using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//消息基類
public class Cmd
{
}

//C to S
public class LoginCmd : Cmd
{
    public string account;
    public string password;
}
//S to C
public class LoginSuccessCmd : Cmd
{
    public string userID;
    public string name;
    public int money;
    public int avatarID;
}
//S to C
public class LoginFaildCmd : Cmd
{
}

//public class DoFaild : Cmd
//{

//}

