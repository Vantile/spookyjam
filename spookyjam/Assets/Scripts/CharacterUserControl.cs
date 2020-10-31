using System.Collections;
using System.Collections.Generic;
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

        if (Input.GetKey(m_PowerButton) && powerEnabled && powerReady[powerName] && phasingZone != null)
        {
            phasingZone.SetActive(false);
            m_CanvasMessage.SetActive(false);
        }
    }

    public void setPhasing(string power, bool enabled, GameObject zone)
    {
        powerName = power;
        powerEnabled = enabled;

        if (m_CanvasMessage != null)
            m_CanvasMessage.SetActive(powerEnabled && powerReady[powerName]);

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
