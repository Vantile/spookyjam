using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskItem : MonoBehaviour
{
    //Nombre de la tarea, ej "Número de puertas por abrir"
    [SerializeField]
    string nameTask = "";

    //Numero de items necesarios para completar la tarea
    [SerializeField]
    int maxItems = 0;

    Text textUI;

    int currentItems = -1;

    void Start()
    {
        textUI = GetComponent<Text>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        currentItems++;
        if(currentItems == maxItems)
        {
            TaskFinished();
            //Cambiar el color del texto al completar la tarea si se quiere
            textUI.color = Color.green;
        }
        textUI.text = nameTask + ": " + currentItems + "/" + maxItems;
    }


    //TODO: Informar a algún script de que se ha finalizado la tarea
    void TaskFinished()
    {
        GameManager.instance.UpdateTasks();
    }

    //Testeo
    /*void Update()
    {
        if (Input.anyKeyDown)
        {
            currentItems++;
            UpdateUI();
        }
    }*/
}
