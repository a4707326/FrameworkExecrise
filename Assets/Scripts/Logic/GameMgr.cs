using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameMgr : Singleton<GameMgr>
{
    internal void Init()
    {
        SceneManager.LoadScene("Login");
    }
}

