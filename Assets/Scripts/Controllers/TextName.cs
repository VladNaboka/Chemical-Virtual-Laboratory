using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextName : MonoBehaviour
{
    //Скрипт показывает при наведении на определенные объекты их имена
    public TextMeshPro textName;
    public GameObject textNamePill;
    public GameObject player;
    public InstantianeObj inst;
    private void Update()
    {
        NameBottleActivator();
        if (inst.ACselectable && inst.ACselectable.CompareTag("Pill"))
        {
            textNamePill.transform.LookAt(player.transform.position);
            textNamePill.transform.rotation = player.transform.rotation;
            textNamePill.SetActive(true);
        }
        else
            textNamePill.SetActive(false);
    }
    void NameBottleActivator()
    {
        if (inst.ACselectable && inst.ACselectable.CompareTag("NameBottle"))
        {
            textName.text = inst.ACselectable.name;
            //textName.transform.SetParent(inst.ACselectable.transform);
            textName.transform.position = inst.ACselectable.transform.position + new Vector3(0, 1, 0);
            textName.transform.LookAt(player.transform.position);
            textName.transform.rotation = player.transform.rotation;
            //textName.transform.position = inst.ACselectable.transform.position + new Vector3(0, 0.2f, 0);

        }
        else
            textName.text = null;
    }
}
