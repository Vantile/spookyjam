using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject CooldownFire;
    public GameObject CooldownFreeze;
    public GameObject CooldownRock;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() { 

    }


    //Function called when the player loses
    public void GameOver()
    {
        //TODO: Implement this
        SceneManager.LoadScene(3);
        print("The player has lost the game.");
    }


}
