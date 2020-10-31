using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasingFloor : MonoBehaviour
{
    [SerializeField] private string m_PhasingType;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterUserControl>().setPhasing(m_PhasingType, true, this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterUserControl>().setPhasing(m_PhasingType, false, null);

            Transform parentZone = this.gameObject.transform.parent;
            for (int i = 0; i < parentZone.childCount; i++)
            {
                if (parentZone.GetChild(i).tag == m_PhasingType + "Zone")
                {
                    parentZone.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }
}
