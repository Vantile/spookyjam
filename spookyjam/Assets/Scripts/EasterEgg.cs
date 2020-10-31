using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    [SerializeField] private AudioSource m_Sound;


    private bool found = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!found && other.tag == "Player")
        {
            found = true;
            m_Sound.Play();
        }
    }
}
