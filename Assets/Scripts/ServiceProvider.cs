using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceProvider : MonoBehaviour {

    public static ServiceProvider instance;

    [SerializeField]
    private PlayerScript m_Player;

    [SerializeField]
    private TimerManager m_Timer;

    [SerializeField]
    private GameManager m_GameManager;

    [SerializeField]
    private WinPanel m_WinPanel;

    [SerializeField]
    private HighScoreManager m_HighScoreManager;

    private void Start()
    {
        instance = this;
    }

    /// <summary>
    /// Get the active player.
    /// </summary>
    /// <returns>Active Player</returns>
    public PlayerScript GetPlayer()
    {
        return m_Player;
    }

    /// <summary>
    /// Get the time manager.
    /// </summary>
    /// <returns>Timer/TimeManager</returns>
    public TimerManager GetTimeManager()
    {
        return m_Timer;
    }

    /// <summary>
    /// Returns the GameManager.
    /// </summary>
    /// <returns></returns>
    public GameManager GetGameManager()
    {
        return m_GameManager;
    }

    /// <summary>
    /// Returns the win panel.
    /// </summary>
    /// <returns></returns>
    public WinPanel GetWinPanel()
    {
        return m_WinPanel;
    }

    /// <summary>
    /// Returns the HighScoreManager.
    /// </summary>
    /// <returns></returns>
    public HighScoreManager GetHighScoreManager()
    {
        return m_HighScoreManager;
    }
}
