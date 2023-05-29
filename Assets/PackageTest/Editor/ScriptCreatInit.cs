//===================================================
//备    注：替换代码注释
//===================================================
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class ScriptCreatInit : UnityEditor.AssetModificationProcessor
{
    public static void OnWillCreateAsset(string path)
    {
        path = path.Replace(".meta", "");
        if (path.EndsWith(".cs"))
        {
            ////Debug.Log("strContent"+strContent);
            string allText = "//===============================\r\n" +
                                        "//  功能 ：备注 \r\n" +
                                        "//  作者 ：上中野辅亚瑟王 \r\n" +
                                        "//  创建时间 ：#CreateTime# \r\n" +
                                        "//  Unity版本  ：#UnityVersion# \r\n" +
                                        "//  变更时间 :  #LastSaveTime# \r\n" +
                                        "//===============================\r\n" + "\r\n" + "\r\n" + "\r\n" + "\r\n" + "\r\n";
            allText += File.ReadAllText(path);

            allText = allText.Replace("#CreateTime#", DateTime.Now.ToString("yyyy-MM-dd  HH-mm-ss")).Replace("#UnityVersion#", Application.unityVersion).
                Replace("#LastSaveTime#", DateTime.Now.ToString("yyyy-MM-dd  HH-mm-ss"));

            File.WriteAllText(path, allText);
            AssetDatabase.Refresh();
        }
    }
}