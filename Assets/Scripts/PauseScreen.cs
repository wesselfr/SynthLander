using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnPauseEvent();
public class PauseScreen : MonoBehaviour {

    [SerializeField]
    private bool m_CanPause = true;

    [SerializeField]
    private ServiceProvider m_Provider;

    [SerializeField]
    private GameObject m_Panel;

    private bool m_State = false;

    public static OnPauseEvent OnPause;
    public static OnPauseEvent OnContinue;

	// Use this for initialization
	void Start () {
        m_Provider.GetPlayer().OnPlayerLand += PreventScreen;
        m_Panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (m_CanPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                m_State = !m_State;
                Time.timeScale = 1f;
                if(m_State == true)
                {
                    if (OnPause != null)
                    {
                        OnPause();
                    }
                }
                if (m_State == false)
                {
                    if (OnContinue != null)
                    {
                        OnContinue();
                    }
                }
            }
        }
        m_Panel.SetActive(m_State);

        //When Panel is active
        if (m_State == true)
        {
            Time.timeScale = 0f;
        }


	}

    public void HideScreen()
    {
        m_State = false;
        Time.timeScale = 1f;
        if(OnContinue != null)
        {
            OnContinue();
        }
    }

    void PreventScreen()
    {
        m_CanPause = false;
    }
}
