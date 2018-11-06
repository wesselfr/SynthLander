using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void PlayerEvent();

public class Enemy : PlayerScript { }

public class PlayerScript : MonoBehaviour {

    Rigidbody m_Rigidbody;

    [SerializeField]
    private float m_Gravity;

    [SerializeField]
    private float m_Trust = 10;

    [SerializeField]
    private float m_RotationSpeed;

    [SerializeField]
    private GameObject m_DeathObject;

    [SerializeField]
    private ParticleSystem m_Emiter;
    private ParticleSystem.EmissionModule m_Emission;

    [SerializeField]
    private ServiceProvider m_Provider;

    private Vector3 m_StartPosition;
    //private Quaternion m_StartRotation;

    public PlayerEvent OnPlayerDeath;
    public PlayerEvent OnPlayerLand;

    private bool m_Landed;

    private bool m_Playing = true;

    private Vector3 m_Velocity;
    private Vector3 m_AngularVelocity;

	// Use this for initialization
	void Start () {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_StartPosition = transform.position;
        m_Emission = m_Emiter.emission;
        //m_Rigidbody.AddForce(Vector3.down * 2, ForceMode.Force);

        if (m_Provider.GetTimeManager() != null)
        {
            m_Provider.GetTimeManager().OnPlayerRunOutOfTime += Reload;
        }

        PauseScreen.OnPause += PauseGame;
        PauseScreen.OnContinue += ContinueGame;

	}

    // Update is called once per frame
    void Update () {
        if (m_Playing)
        {
            m_Rigidbody.freezeRotation = true;
            m_Rigidbody.AddForce(Vector3.down * m_Gravity, ForceMode.Force);
            m_Emission.enabled = false;
            if (!m_Landed)
            {
                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    m_Rigidbody.AddForce(transform.forward * m_Trust, ForceMode.Acceleration);
                    m_Emission.enabled = true;

                }
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    m_Rigidbody.freezeRotation = false;
                    m_Rigidbody.AddTorque(Vector3.forward * m_RotationSpeed, ForceMode.Acceleration);
                    m_Rigidbody.freezeRotation = true;
                }
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    m_Rigidbody.freezeRotation = false;
                    m_Rigidbody.AddTorque(-Vector3.forward * m_RotationSpeed, ForceMode.Acceleration);
                    m_Rigidbody.freezeRotation = true;
                }

                m_Rigidbody.freezeRotation = true;
                m_Rigidbody.angularVelocity = Vector3.zero;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Application.isEditor && !m_Landed)
            {
                Reload();
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Contains("Ground"))
        {
            if (!m_Landed)
            {
                Reload();
            }
        }
        if (collision.collider.tag.Contains("LandingZone"))
        {
            if (OnPlayerLand != null)
            {
                OnPlayerLand();
            }
            m_Landed = true;
        }
    }

    public void Reload()
    {

        if(OnPlayerDeath != null)
        {
            OnPlayerDeath();
        }

        Instantiate(m_DeathObject, transform.position, transform.rotation);
        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.freezeRotation = true;
        transform.position = m_StartPosition;
        transform.rotation = Quaternion.Euler(new Vector3(-90,0,90));
        m_Rigidbody.freezeRotation = false;

        m_Landed = false;

        //m_Emiter.Clear();
    }

    public bool isLanded
    {
        get { return m_Landed; }
    }

    public void PauseGame()
    {
        m_Playing = false;
        m_Velocity = m_Rigidbody.velocity;
        m_AngularVelocity = m_Rigidbody.angularVelocity;
        m_Rigidbody.isKinematic = true;
    }

    public void ContinueGame()
    {
        m_Playing = true;
        m_Rigidbody.isKinematic = false;
        m_Rigidbody.velocity = m_Velocity;
        m_Rigidbody.angularVelocity = m_AngularVelocity;
        
    }
}
