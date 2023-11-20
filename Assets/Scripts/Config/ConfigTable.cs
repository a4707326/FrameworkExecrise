using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



public class TableDB
{
    public string dateID;
}


//Table 的基類
public class ConfigTable<TDB,T> : Singleton<T> 
    where TDB : TableDB, new()
    where T :new()
{
    //ID ，泛型TDB(資料)
    Dictionary<string, TDB> _cache = new();



    protected void Load(string path) 
    {
        MemoryStream tableStream;
        //string path;

        //開發期
#if UNITY_EDITOR
        //path = $"Config/{tableName}";
        tableStream = new MemoryStream(File.ReadAllBytes( $"{Application.dataPath}/../{path}"));
#else
        //發布後
        //path = $"Config/{tableName}";
        var table = Resources.Load<TextAsset>(path);
        tableStream = new MemoryStream(table.bytes);
#endif

        using (var reader = new StreamReader(tableStream, Encoding.UTF8))
        {
            //欄位(字段)名
            var fieldNameStr = reader.ReadLine();

            var fieldNameArray = fieldNameStr.Split(',');
            List<FieldInfo> fieldList = new();

            //取字段的型別加進List
            foreach (var fieldName in fieldNameArray)
            {
                fieldList.Add(typeof(TDB).GetField(fieldName));
            }

            var lineStr = reader.ReadLine();

            while (lineStr != null)
            {
                //讀到內存
                var itemStrArray = lineStr.Split(',');

                var userDB = new TDB();

                //依型別填入DB
                for (int i = 0; i < fieldList.Count; i++)
                {
                    if (fieldList[i].FieldType == typeof(string))
                    {
                        fieldList[i].SetValue(userDB, itemStrArray[i]);
                    }
                    else if(fieldList[i].FieldType == typeof(int))
                    {
                        fieldList[i].SetValue(userDB, int.Parse(itemStrArray[i]));
                    }
                    else if (fieldList[i].FieldType == typeof(float))
                    {
                        fieldList[i].SetValue(userDB, float.Parse(itemStrArray[i]));
                    }
                    else if (fieldList[i].FieldType == typeof(bool))
                    {
                        fieldList[i].SetValue(userDB, bool.Parse(itemStrArray[i]));
                    }
                }


                //userDB.dateID = itemStrArray[0];
                //PraserItem(userDB, itemStrArray);

                _cache[userDB.dateID] = userDB;

                lineStr = reader.ReadLine();
            }
        }
    }

    ////由子類自行解析欄位
    //protected virtual void PraserItem(TDB db, string[] itemStrArray)
    //{ 
    //}


    protected ConfigTable()
    {

    }



    public TDB this[string index]
    {
        get
        {
            if (!_cache.TryGetValue(index, out TDB db))
            {
                Debug.LogError($"讀取資料失敗{typeof(TDB)}{db}{index}");
            }
            return db;
        }
    }

    public Dictionary<string, TDB> GetAll()
    {
        return _cache;
    }

}



