using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour {

    [SerializeField]
    TimerManager m_Timer;

    [SerializeField]
    private ServiceProvider m_Provider;

    [SerializeField]
    private Text m_HighScore, m_Score, m_NewHighScoreText;

    private TimeData m_Time, m_HighScoreTime;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
        m_NewHighScoreText.text = "";
        m_Provider.GetPlayer().OnPlayerLand += Activate;
        m_Provider.GetHighScoreManager().OnNewHighScore += OnNewHigh;
        m_Timer = m_Provider.GetTimeManager();
        Time.timeScale = 1;
	}

    private void Activate()
    {
        gameObject.SetActive(true);
        m_Timer = m_Provider.GetTimeManager();
        if (m_Timer != null)
        {
            m_Timer.Stop();
            m_Time = m_Timer.currentTime;
        }
        Time.timeScale = 0.33f;
        UpdateHighScore();
        ActivateUI();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UpdateHighScore()
    {
        m_Provider.GetHighScoreManager().checkAndChange(SceneManager.GetActiveScene().buildIndex, m_Time);
        m_HighScoreTime = m_Provider.GetHighScoreManager().GetHighScore(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnNewHigh()
    {
        m_NewHighScoreText.text = "New Highscore!";
    }

    public void ActivateUI()
    {
        if(m_Timer != null)
        {
            m_Score.text = "00:" + m_Time.seconds + ":" + Mathf.Round(m_Time.miliseconds);
            m_HighScore.text = "HighScore: 00:" + m_HighScoreTime.seconds + ":" + Mathf.Round(m_HighScoreTime.miliseconds);
        }
        else if(m_Timer == null)
        {
            m_Score.text = "Amazing!";
            m_HighScore.text = "";
        }
    }

}
