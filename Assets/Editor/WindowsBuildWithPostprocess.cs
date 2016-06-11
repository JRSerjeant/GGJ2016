using UnityEngine;
using System.Diagnostics;
using UnityEditor;
using System;
using System.IO;

public class WindowsBuildWithPostprocess
{
    [MenuItem("MyTools/Windows Build With Postprocess")]
    public static void BuildGame()
    {
        // Get filename.
        string path = "C:/builds/";
        string date = DateTime.Now.ToString("HHmm_dd_MM_yyyy");
        string fullpath = path + date;
        Directory.CreateDirectory(fullpath);

        //string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
        string[] levels = new string[] { "Assets/Scenes/main.unity" };




        // Build player.
        //Debug.Log("Starting Build");
        BuildPipeline.BuildPlayer(levels, fullpath + "/build.exe", BuildTarget.StandaloneWindows, BuildOptions.None);

        // Copy a file from the project folder to the build folder, alongside the built game.
        //FileUtil.CopyFileOrDirectory("Assets/WebPlayerTemplates/Readme.txt", path + "Readme.txt");

        // Run the game (Process class from System.Diagnostics).
        Process proc = new Process();
        proc.StartInfo.FileName = fullpath + "/build.exe";
        proc.Start();
    }
}
