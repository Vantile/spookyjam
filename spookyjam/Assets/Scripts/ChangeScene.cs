using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private int m_SceneIndex = 0;
    [SerializeField] private string m_ChangeKey = "return";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(m_ChangeKey))
        {
            SceneManager.LoadScene(m_SceneIndex);
        }
    }
}
