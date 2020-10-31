using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAdditive : MonoBehaviour
{
    [SerializeField] private int m_SceneIndex = 0;
    [SerializeField] private string m_ChangeKey = "return";

    private bool loaded = false;

    // Update is called once per frame
    void Update()
    {
        if (!loaded && Input.GetKeyDown(m_ChangeKey))
        {
            loaded = true;
            SceneManager.LoadScene(m_SceneIndex, LoadSceneMode.Additive);
        }
    }
}
