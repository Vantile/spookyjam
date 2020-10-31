using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUserControl : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private string _powerButton = "space";

    private Rigidbody2D m_Rigidbody;
    Animator m_Animator;
    private string powerName;
    private bool powerEnabled = false;
    private GameObject phasingZone = null;
    private Dictionary<string, bool> powerReady;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        powerReady["Fire"] = false;
        powerReady["Ice"] = false;
        powerReady["Rock"] = false;
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 movement = h * Vector2.right + v * Vector2.up;
        m_Rigidbody.velocity = (movement * speed);
        m_Animator.SetFloat("XSpeed", m_Rigidbody.velocity.x);
        m_Animator.SetFloat("YSpeed", m_Rigidbody.velocity.y);

        if (Input.GetKey(_powerButton) && powerEnabled && powerReady[powerName] && phasingZone != null)
            phasingZone.SetActive(false);
    }

    public void setPhasing(string power, bool enabled, GameObject zone)
    {
        powerName = power;
        powerEnabled = enabled;

        if (!enabled)
        {
            // TODO Activar cooldown del poder
        }

        if (zone != null)
        {
            Transform parentZone = zone.transform.parent;
            for (int i = 0; i < parentZone.childCount; i++)
            {
                if (parentZone.GetChild(i).tag == powerName + "Zone")
                {
                    GameObject phasingZone = parentZone.GetChild(i).gameObject;
                }
            }
        }
    }
}
