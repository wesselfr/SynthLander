using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialArrows : MonoBehaviour {

    [SerializeField]
    private int m_Index;

    [SerializeField]
    private GameObject[] m_Objects;

    [SerializeField]
    private float m_SwitchTime;

    private float m_Time;

	// Use this for initialization
	void Start () {
        for (int i = 0; i <  m_Objects.Length; i++)
        {
            m_Objects[i].SetActive(false);
        }
        m_Time = m_SwitchTime;
	}
	
	// Update is called once per frame
	void Update () {
        m_Time += Time.deltaTime;

        if(m_Time >= m_SwitchTime)
        {
            m_Time = 0;
            m_Index++;
            if(m_Index > m_Objects.Length)
            {
                m_Index = 0;
            }
        }

        for (int i = 0; i < m_Objects.Length; i++)
        {
            m_Objects[i].SetActive(false);
            if(i == m_Index)
            {
                m_Objects[i].SetActive(true);
            }
        }

    }
}
