﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePowers : MonoBehaviour
{
    public GameObject poderUI;
    private GameObject player;

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
            }
        }
    }
}
