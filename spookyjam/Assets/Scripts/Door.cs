using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public enum State { CLOSED, OPEN } //dos estados abierta y cerrada
    public int id_door; //numero identificador de cada puerta
    public string door_open;
    public Animation door_animation;
    public AudioSource door_audio;

    private State door_state = State.CLOSED; //inicialmente esta cerrada


    public State DoorState
    {
        get { return door_state; }
    }

    void OnTriggerActivate(int activateDoor)
    {
        if (DoorState == State.CLOSED)
        {
            if (activateDoor == id_door)//si el numero que recibe al activar es el de esta puerta, se abre
            {
                door_state = State.OPEN;
                door_animation.Play(door_open);
                door_audio.Play();
            }
        }
    }

}
