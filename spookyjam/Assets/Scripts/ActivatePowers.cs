using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePowers : MonoBehaviour
{
    public GameObject poderUI;
    private GameObject player;
    public enum POWER { FIRE, ICE, GROUND };
    [SerializeField]
    private POWER power;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            poderUI.SetActive(true);
            CooldownRadial cr = poderUI.GetComponent<CooldownRadial>();
            if (cr)
            {
                cr.activated = true;
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            
            ShowAdvice advice = this.gameObject.GetComponent<ShowAdvice>();
            if (advice != null) {
                string message = "";
                switch(power)
                {
                    case POWER.FIRE:
                        message = "Technology upgraded! You can now put out fires!";
                        break;
                    case POWER.ICE:
                        message = "Technology upgraded! You can now freeze water!";
                        break;
                    case POWER.GROUND:
                        message = "Technology upgraded! You can now break rocks!";
                        break;
                }
                advice.showAdvice(message);
                Debug.Log(message);
            }
        }
    }
}
