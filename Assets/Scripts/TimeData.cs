using UnityEngine;
using System.Collections;
using System;

[Serializable]
public struct TimeData
{
    public float m_Seconds;
    public float m_Miliseconds;

    public TimeData(float sec, float ms)
    {
        m_Seconds = sec;
        m_Miliseconds = ms;
    }

    public float seconds { get { return m_Seconds; } }
    public float miliseconds { get { return m_Miliseconds; } }
}
