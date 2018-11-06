using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private ServiceProvider m_Provider;

	// Use this for initialization
	void Start () {
        m_Provider.GetPlayer().OnPlayerDeath += PlayerDeath;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlayerDeath()
    {
        
    }
}
