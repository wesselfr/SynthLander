using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System.IO;

public class CreateDefaultFoldersScript : MonoBehaviour {

    [MenuItem("Workspace/Create Default Workspace", priority = 1)]
    public static void MakeFolder()
    {
        string path = GetMainDirectory();
        Debug.Log("Creating Folders in: " + path);
        Directory.CreateDirectory(Path.Combine(path, "Scripts"));
        Directory.CreateDirectory(Path.Combine(path, "Editor"));
        Directory.CreateDirectory(Path.Combine(path, "Prefabs"));
        Directory.CreateDirectory(Path.Combine(path, "Materials"));
        Directory.CreateDirectory(Path.Combine(path, "Models"));
        Directory.CreateDirectory(Path.Combine(path, "Scenes"));
        Directory.CreateDirectory(Path.Combine(path, "Resources"));
        Directory.CreateDirectory(Path.Combine(path, "Sprites"));
        Directory.CreateDirectory(Path.Combine(path, "Textures"));
        Directory.CreateDirectory(Path.Combine(path, "Animations"));
        Directory.CreateDirectory(Path.Combine(path, "Plugins"));

        Debug.Log("Folders Generated");
        //Directory.CreateDirectory();

        AssetDatabase.Refresh();
    }


    private static string GetMainDirectory()
    {
        string path = Directory.GetCurrentDirectory();
        path = Path.Combine(path, "Assets");
        return path;
    }

    [MenuItem("Workspace/Create Workspace/Custom")]
    public static void CreateWindow()
    {
        string path = GetMainDirectory();
        path = Path.Combine(path, "Editor");
        Directory.CreateDirectory(path);
        //AssetDatabase.CreateAsset()
    }

}
