using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    enum State { up, down};

    Text t;
    State s = State.down;
    float newValue;

    [SerializeField]
    float changeRate = 0.01f;

    private void Start()
    {
        t = GetComponent<Text>();
    }

    private void Update()
    {
        if (s == State.up)
        {
            newValue = t.color.a + changeRate;
            if (newValue >= 1)
            {
                s = State.down;
                newValue = 1;
            }
        }
        else
        {
            newValue = t.color.a - changeRate;
            if (newValue <= 0)
            {
                s = State.up;
                newValue = 0;
            }
        }
        t.color = new Color(t.color.r, t.color.g, t.color.b, newValue);
    }
 
}
