using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolveTask : MonoBehaviour
{
    public enum State { UNDONE, DONE } //dos estados abierta y cerrada
    public GameObject task_object, taskText;
    public Sprite newSprite;

    private State task_state = State.UNDONE; //inicialmente esta cerrada


    public State TaskState
    {
        get { return task_state; }
    }


    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player" && task_state == State.UNDONE)
        {
            task_state = State.DONE;
            task_object.GetComponent<SpriteRenderer>().sprite = newSprite;
            taskText.GetComponent<TaskItem>().UpdateUI();
        }

    }
}
