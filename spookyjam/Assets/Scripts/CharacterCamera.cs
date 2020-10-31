using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    [SerializeField] private float _height = 0.0f;
    [SerializeField] private Transform _character = null;

    // Update is called once per frame
    void Update()
    {
        transform.position = _character.position + new Vector3(0.0f, 0.0f, _height);
    }
}
