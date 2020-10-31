using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasingFloor : MonoBehaviour
{
    [SerializeField] private string m_PhasingType;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterUserControl>().setPhasing(m_PhasingType, true, this.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterUserControl>().setPhasing(m_PhasingType, false, null);
        }
    }
}
