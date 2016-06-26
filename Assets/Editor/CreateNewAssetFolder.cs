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
        String path;

        String resourcesDir = Application.dataPath + "/xResources";
        resourcesDir = resourcesDir.Replace("/", "\\");
        String[] resourcesDirFolfers = Directory.GetDirectories(resourcesDir);

        String tempDir = "\\__Template";
        String[] tempDirFolders = Directory.GetDirectories(resourcesDir + tempDir);

        foreach (var d in resourcesDirFolfers)
        {
            
            if (Path.GetFileName(d).StartsWith("_") && Path.GetFileName(d) != "__Template")
            {
                foreach (var dd in tempDirFolders)
                {
                    path = d + "\\" + Path.GetFileName(dd);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path.ToString());
                        UnityEngine.Debug.Log(path);
                    }

                    String[] dddirFolfers = Directory.GetDirectories(dd);
                    foreach (var ddd in dddirFolfers)
                    {
                        path = d + "\\" + Path.GetFileName(dd) + "\\" + Path.GetFileName(ddd);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path.ToString());
                            UnityEngine.Debug.Log(path);
                        }
                    }
                }
                
            }
        }
    }
        //String newFolder = "_new";
        //String path;
        //String tempDir = "\\__Template";
        //String[] dir = Directory.GetDirectories(resourcesDir + tempDir);
        //path = resourcesDir + "\\" + newFolder;
        //Directory.CreateDirectory(path.ToString());
        //foreach (var d in dir)
        //{
        //    String[] ddir = Directory.GetDirectories(d);
        //    path = resourcesDir + "\\" + newFolder + "\\" + Path.GetFileName(d);
        //    UnityEngine.Debug.Log(path.ToString());
        //    Directory.CreateDirectory(path.ToString());

        //    foreach (var dd in ddir)
        //    {
        //        path = resourcesDir + "\\" + newFolder + "\\" + Path.GetFileName(d) + "\\" + Path.GetFileName(dd);
        //        UnityEngine.Debug.Log(path.ToString());
        //        Directory.CreateDirectory(path.ToString());
        //    }
        //}

}

