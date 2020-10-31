using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Vector3 m_RotationSpeed = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(m_RotationSpeed * Time.deltaTime);
    }
}
