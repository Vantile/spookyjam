using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterToResetScript : MonoBehaviour
{
    [SerializeField]
    private int mainGameSceneIndex = 0;
    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene(mainGameSceneIndex);
        }
    }
}
