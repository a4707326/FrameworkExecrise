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
public class IsLoginSuccess : Cmd
{
}
public class IsLoginFaild : Cmd
{
}

//public class DoFaild : Cmd
//{

//}

