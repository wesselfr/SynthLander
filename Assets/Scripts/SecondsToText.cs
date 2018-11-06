using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondsToText : MonoBehaviour {

    [SerializeField]
    private ServiceProvider m_Provider;

    [SerializeField]
    private Text m_TimeText;

    private TimerManager m_Timer;

	// Use this for initialization
	void Start () {
        m_Timer = m_Provider.GetTimeManager();
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Timer != null)
        {
            float sec = m_Timer.currentTime.seconds;
            if (sec <= 3)
            {
                m_TimeText.text = "" + m_Timer.currentTime.seconds;
                if(sec <= 0)
                {
                    m_TimeText.text = "# ! #";
                }
            }
           
            else
            {
                m_TimeText.text = "";
            }
        }
	}
}
