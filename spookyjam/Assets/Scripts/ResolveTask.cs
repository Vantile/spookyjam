using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolveTask : MonoBehaviour
{
    public enum State { UNDONE, DONE } //dos estados abierta y cerrada
    public GameObject task_object;
    public Sprite newSprite;

    private State task_state = State.UNDONE; //inicialmente esta cerrada
    private bool playerRange = false;


    public State TaskState
    {
        get { return task_state; }
    }


    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
            playerRange = true;

    }


    private void Update()
    {
        if (TaskState == State.UNDONE)
        {
            if (playerRange)
            {
                task_state = State.DONE;
                task_object.GetComponent<SpriteRenderer>().sprite = newSprite;

            }
        }
    }
}
