using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

    [SerializeField]
    private Text m_TimerText;

    [SerializeField]
    private TimeIndicator m_Indicator;

    private float m_Seconds = 10;
    private float m_Miliseconds;

    [SerializeField]
    private bool m_Running = false;

    [SerializeField]
    private PlayerScript m_Player;

    public PlayerEvent OnPlayerRunOutOfTime;

	// Use this for initialization
	void Start () {
        m_Player.OnPlayerDeath += Reset;
	}

    public void Reset()
    {
        m_Seconds = 10;
        m_Miliseconds = 0;
    }

    public void StartTimer()
    {
        m_Running = true;
    }

    public bool isRunning
    {
        get { return m_Running; }
    }

    public void Stop()
    {
        m_Running = false;
    }

    public TimeData currentTime { get { return new TimeData(m_Seconds, m_Miliseconds); } }

    public void CheckInput()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            StartTimer();
        }
        else
        {
            m_TimerText.text = "00:10"  + "<size=120>." + "000" + " </size>";
        }
    }

    // Update is called once per frame
    void Update () {

        string sec = m_Seconds.ToString();

        if (m_Running)
        {
            m_Miliseconds -= Time.deltaTime * 1000;
        }

        float milisec = Mathf.Round(m_Miliseconds);

        if (m_Miliseconds <= 0)
        {
            m_Seconds--;
            m_Miliseconds = 1000;
        }

        if(m_Seconds < 10)
        {
            sec = "0" + sec;
        }

        string ms = milisec.ToString();
        if(milisec >= 1000) { ms = "999"; }
        if(milisec < 100)
        {
            ms = "0" + ms;
            if (milisec < 10)
            {
                if (milisec >= 1)
                {
                    ms = "00" + ms;
                }
            }
        }
        if(milisec <= 0)
        {
            ms = "000";
        }

        m_TimerText.text = "00:" + sec + "<size=120> ." + ms + "</size>";
        
        if(m_Seconds < 0)
        {
            if(OnPlayerRunOutOfTime!= null)
            {
                OnPlayerRunOutOfTime();
            }
        }

        //Check if player gave input.
        if (m_Running == false && !m_Player.isLanded)
        {
            CheckInput();
        }

        m_Indicator.UpdateTime(m_Seconds, milisec);
    }
}
