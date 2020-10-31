using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUserControl : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private string _powerButton = "space";

    private Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = h * Vector3.right + v * Vector3.forward;
        m_Rigidbody.AddForce(movement * speed);

        //bool power = Input.GetKey(_powerButton);
    }
}
