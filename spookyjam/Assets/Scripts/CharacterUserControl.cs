using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUserControl : MonoBehaviour
{
    [SerializeField] private float speed = 50000;
    [SerializeField] private string _powerButton = "space";

    private Rigidbody2D m_Rigidbody;
    Animator m_anim;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 movement = h * Vector2.right + v * Vector2.up;
        m_Rigidbody.velocity = (movement * speed);
        m_anim.SetFloat("XSpeed", m_Rigidbody.velocity.x);
        m_anim.SetFloat("YSpeed", m_Rigidbody.velocity.y);

        //bool power = Input.GetKey(_powerButton);
    }
}
