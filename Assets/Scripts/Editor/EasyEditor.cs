using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.VersionControl;
using UnityEngine;

using UnityEngine.UI;

public class EasyEditor : Editor
{
    //快速返回啟動介面
    [MenuItem("Custom/GoToInit")]
    public static void GoToInit()
    {
        EditorSceneManager.OpenScene(Application.dataPath + "/Scenes/Init.unity");
    }


    //把配置文件放進Resources內
    [MenuItem("Custom/ConfigToResources")]
    public static void ConfigToResources()
    {
        //Debug.Log("ConfigToResources");
        var srcPath = Application.dataPath + "/../Config/";
        var detPath = Application.dataPath + "/Resources/Config/";

        //清空目錄重建
        if (File.Exists(srcPath))
        {
            Directory.Delete(detPath, true);
            Directory.CreateDirectory(detPath);
        }


        //複製檔案
        foreach (var filePath in Directory.GetFiles(srcPath))
        {
            string fileName = Path.GetFileName(filePath);

            File.Copy(filePath, detPath + fileName + ".bytes", true);
        }
        Debug.Log("配置文件複製完畢");
    }

}
