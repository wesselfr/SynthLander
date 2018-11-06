using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeIndicator : MonoBehaviour {

    [SerializeField]
    private Image m_Indicator;

    public void UpdateTime(float sec, float ms)
    {
        sec += (ms / 1000);

        m_Indicator.fillAmount = (sec / 10);
    }
}
