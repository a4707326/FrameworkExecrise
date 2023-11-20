using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.U2D;


//資源管理器，加載方式和使用邏輯分離
//以便於支持 : 熱更新與對象池
public class ResMgr : Singleton<ResMgr>
{
    public GameObject GetInstance(string resPath)
    {
        return GameObject.Instantiate(GetRes<GameObject>(resPath));
    }

    public T GetRes<T>(string resPath) where T : UnityEngine.Object
    {
        return Resources.Load<T>(resPath);
    }

    public Sprite GetSprite(string atlasName, string name)
    {
        return GetRes<SpriteAtlas>("Atlas/" + atlasName).GetSprite(name);
    }
}

