using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour {

    [SerializeField]
    private int m_BuildIndex;

    public void LoadScene()
    {
        SceneManager.LoadScene(m_BuildIndex);
    }
}
