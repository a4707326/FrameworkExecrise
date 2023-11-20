using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//繼承用單例
public class Singleton<T> where T : new()
{
    public static T instance;
    static Singleton() 
    {
        instance = new T();
    }
}

