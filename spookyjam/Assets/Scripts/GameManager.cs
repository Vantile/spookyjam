using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    int numTasks = 2;

    int currentTasks = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            print("Exiting");
        }
    }

    //Singleton
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void UpdateTasks()
    {
        currentTasks++;
        if(currentTasks == numTasks)
        {
            Win();
        }
    }

    void Win()
    {
        currentTasks = 0;
        SceneManager.LoadScene("GameFinishScene");
    }

    //Function called when the player loses
    public void GameOver()
    {
        currentTasks = 0;
        SceneManager.LoadScene("GameOverScene");
    }


}
