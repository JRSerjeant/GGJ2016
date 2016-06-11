using UnityEngine;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEditor;
using System;
using System.IO;

public class CreateNewAssetFolder : MonoBehaviour
{

    [MenuItem("MyTools/Create New Asset Folder")]
    public static void CreateFolders()
    {
        String resourcesDir = Application.dataPath + "/Resources";
        resourcesDir = resourcesDir.Replace("/", "\\");

        String newFolder = "_new";
        String path;
        String tempDir = "\\__Template";
        String[] dir = Directory.GetDirectories(resourcesDir + tempDir);
        path = resourcesDir + "\\" + newFolder;
        Directory.CreateDirectory(path.ToString());
        foreach (var d in dir)
        {
            String[] ddir = Directory.GetDirectories(d);
            path = resourcesDir + "\\" + newFolder + "\\" + Path.GetFileName(d);
            UnityEngine.Debug.Log(path.ToString());
            Directory.CreateDirectory(path.ToString());

            foreach (var dd in ddir)
            {
                path = resourcesDir + "\\" + newFolder + "\\" + Path.GetFileName(d) + "\\" + Path.GetFileName(dd);
                UnityEngine.Debug.Log(path.ToString());
                Directory.CreateDirectory(path.ToString());
            }
        }

    }
}
