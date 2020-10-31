using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class CharacterUserControl : MonoBehaviour
{
    [SerializeField] private float m_Speed = 1;
    [SerializeField] private string m_PowerButton = "space";
    [SerializeField] private GameObject m_CanvasMessage;
    [SerializeField] private bool m_GodMode = false;

    private Rigidbody2D m_Rigidbody;
    private Animator m_Animator;
    private string powerName;
    private bool powerEnabled = false;
    private GameObject phasingZone = null;
    private Dictionary<string, bool> powerReady;

    public GameObject fuegoUI;
    public GameObject waterUI;
    public GameObject rockUI;

    public AudioSource aparecerFuego;
    public AudioSource desaparecerFuego;
    public AudioSource derrumbar;
    public AudioSource agua;
    public AudioSource hielo;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        powerReady = new Dictionary<string, bool>();
        powerReady["Fire"] = m_GodMode;
        powerReady["Ice"] = m_GodMode;
        powerReady["Rock"] = m_GodMode;
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 movement = h * Vector2.right + v * Vector2.up;
        m_Rigidbody.velocity = (movement * m_Speed);
        m_Animator.SetFloat("XSpeed", m_Rigidbody.velocity.x);
        m_Animator.SetFloat("YSpeed", m_Rigidbody.velocity.y);



        switch (powerName)
        {
            case "Fire":
                CooldownRadial crf = fuegoUI.GetComponent<CooldownRadial>();
                if (crf)
                {
                    if (crf.activated && crf.ready)
                    {
                        if (m_CanvasMessage != null)
                            m_CanvasMessage.SetActive(powerEnabled && powerReady[powerName]);
                    }
                }
                break;

            case "Ice":
                CooldownRadial crw = waterUI.GetComponent<CooldownRadial>();
                if (crw)
                {
                    if (crw.activated && crw.ready)
                    {
                        if (m_CanvasMessage != null)
                            m_CanvasMessage.SetActive(powerEnabled && powerReady[powerName]);
                    }
                }
                break;

            case "Rock":
                CooldownRadial cr = rockUI.GetComponent<CooldownRadial>();
                if (cr)
                {
                    if (cr.activated && cr.ready)
                    {
                        if (m_CanvasMessage != null)
                            m_CanvasMessage.SetActive(powerEnabled && powerReady[powerName]);
                    }
                }
                break;
        }




        if (Input.GetKey(m_PowerButton) && powerEnabled && powerReady[powerName] && phasingZone != null)
        {
            switch (powerName)
            {
                case "Fire":
                    CooldownRadial crf = fuegoUI.GetComponent<CooldownRadial>();
                    if (crf)
                    {
                        if (crf.activated &&crf.ready)
                        {
                            phasingZone.SetActive(false);
                            m_CanvasMessage.SetActive(false);
                            crf.StartCooldown(5);
                            desaparecerFuego.Play();
                        }
                    }
                    break;

                case "Ice":
                    CooldownRadial crw = waterUI.GetComponent<CooldownRadial>();
                    if (crw)
                    {
                        if (crw.activated && crw.ready)
                        {
                            phasingZone.SetActive(false);
                            m_CanvasMessage.SetActive(false);
                            crw.StartCooldown(5);
                            hielo.Play();
                        }
                    }
                    break;

                case "Rock":
                    CooldownRadial cr = rockUI.GetComponent<CooldownRadial>();
                    if (cr)
                    {
                        if (cr.activated && cr.ready)
                        {
                            phasingZone.SetActive(false);
                            m_CanvasMessage.SetActive(false);
                            cr.StartCooldown(5);
                            derrumbar.Play();
                        }
                    }
                    break;
            }
            
        }
    }

    public void setPhasing(string power, bool enabled, GameObject zone)
    {
        powerName = power;
        powerEnabled = enabled;




        if (zone != null)
        {
            Transform parentZone = zone.transform.parent;
            for (int i = 0; i < parentZone.childCount; i++)
            {
                if (parentZone.GetChild(i).tag == powerName + "Zone")
                {
                    phasingZone = parentZone.GetChild(i).gameObject;
                }
            }
        }
    }
}
