using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    //Editor variables
    [SerializeField]
    int timerSeconds = 300;
    [SerializeField]
    Text timerText;

    //Private variables
    int tenths, seconds, minutes;

    // Start is called before the first frame update
    void Start()
    {
        tenths = 0;
        minutes = timerSeconds / 60;
        seconds = timerSeconds % 60;
        StartCoroutine(CountDownTimer());
    }

    IEnumerator CountDownTimer()
    {
        while (true)
        {
            UpdateUI();
            yield return new WaitForSeconds(0.1f);
            tenths--;
            if(tenths < 0)
            {
                tenths = 9;
                seconds--;
                if(seconds < 0)
                {
                    seconds = 59;
                    minutes--;
                    if(minutes < 0)
                    {
                        GameManager.instance.GameOver();
                    }
                }
            }
        }
    }

    void UpdateUI()
    {
        timerText.text = "";
        timerText.text += minutes.ToString();
        timerText.text += ":";
        timerText.text += seconds.ToString("D2");
        timerText.text += ".";
        timerText.text += tenths.ToString();
    }
}
