using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public enum State { CLOSED, OPEN } //dos estados abierta y cerrada
    public AudioSource door_audio;
    public GameObject lever;
    public Sprite newSprite;

    private State door_state = State.CLOSED; //inicialmente esta cerrada
    private bool playerRange = false;
    Animator door_animator;


    public State DoorState
    {
        get { return door_state; }
    }

    void Start()
    {
        door_animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
            playerRange = true;

    }

    void removeCollider()
    {
        BoxCollider2D[] colliders = this.GetComponents<BoxCollider2D>();
        for (int i = 0;i < colliders.Length; i++)
        {
            colliders[i].enabled = false;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (DoorState == State.CLOSED)
        {
            if (playerRange)
            {
                door_state = State.OPEN;
                door_animator.SetTrigger("Open");
                door_audio.Play();
                lever.GetComponent<SpriteRenderer>().sprite = newSprite;

            }
        }
    }

}
