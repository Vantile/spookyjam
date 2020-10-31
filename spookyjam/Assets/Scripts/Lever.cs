using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public enum State { ACTIVATED, DISABLED } //dos estados activado y desactivado
    public int id_lever; //id que coincide con la puerta que abre
    public string lever_activate;
    public Animation lever_animation;

    private State lever_state = State.DISABLED;

    public State LeverState
    {
        get { return lever_state; }
    }
    void OnTriggerActivate(int activateLever)
    {
        if (LeverState == State.DISABLED)
        {
            if (activateLever == id_lever)
            {
                lever_state = State.ACTIVATED;
                lever_animation.Play(lever_activate);
                //lanzar interfaz de que se ha abierto una puerta
            }
        }
    }
}
