using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public delegate void HighScoreEvent();
public class HighScoreManager : MonoBehaviour
{
    [SerializeField]
    private ServiceProvider m_ServiceProvider;

    private TimeData[] m_TimeData;

    private string m_FileDirection;

    public HighScoreEvent OnNewHighScore;

    // Use this for initialization
    void Start()
    {
        m_ServiceProvider = ServiceProvider.instance;
        m_TimeData = new TimeData[SceneManager.sceneCountInBuildSettings];
        m_FileDirection = Application.persistentDataPath + "/Data.dat";
        LoadFromFile();
    }

    public void checkAndChange(int level, TimeData dataToTest)
    {
        if(m_TimeData[level].seconds < dataToTest.seconds)
        {
            m_TimeData[level] = dataToTest;
            if(OnNewHighScore != null)
            {
                OnNewHighScore();
            }
        }

        if(m_TimeData[level].seconds == dataToTest.seconds)
        {
            if(m_TimeData[level].miliseconds < dataToTest.miliseconds)
            {
                m_TimeData[level] = dataToTest;
                if(OnNewHighScore != null)
                {
                    OnNewHighScore();
                }
            }
        }
        SaveToFile();
    }

    public TimeData GetHighScore(int level)
    {
        return m_TimeData[level];
    }

    public void SaveToFile()
    {
        XmlSerializer serial = new XmlSerializer(typeof(TimeData[]));

        using (StreamWriter writer = new StreamWriter(m_FileDirection,false, System.Text.Encoding.UTF8))
        {
            serial.Serialize(writer, m_TimeData);
            writer.Close();
        }

        Debug.Log("File saved to: " + m_FileDirection);
    }

    public void LoadFromFile()
    {
        if (File.Exists(m_FileDirection))
        {
            XmlSerializer serial = new XmlSerializer(typeof(TimeData[]));
            using (StreamReader reader = new StreamReader(m_FileDirection, System.Text.Encoding.UTF8))
            {
                m_TimeData = (TimeData[])serial.Deserialize(reader);
                reader.Close();
            }
        }
    }
}

