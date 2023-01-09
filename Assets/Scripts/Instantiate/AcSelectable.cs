using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AcSelectable : MonoBehaviour
{
    [Header("Цвет объекта")]
    public Color col;
    public Color yellowCol;

    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Select()
    {
        //controllerTake.obj.SetActive(false);
        GetComponent<Renderer>().material.color = yellowCol;
    }
    public void Deselect()
    {
        GetComponent<Renderer>().material.color = col;
    }
}
