using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    [MenuItem("Playmode/Restart")]
    public static void Reset()
    {
        if (EditorApplication.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    [MenuItem("Playmode/Force Quit")]
    public static void ForceQuit()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
    }

    [MenuItem("Playmode/Emergency Quit")]
    public static void EmergencyQuit()
    {
        EditorSceneManager.SaveScene(SceneManager.GetActiveScene(), "LastScene");
        EditorApplication.Exit(0);
    }
}
