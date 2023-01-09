using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContrlForCamera : MonoBehaviour
{
    public GameObject hand;
    public GameObject table;
    void Start()
    {
        hand = GameObject.Find("Hand");
        table = GameObject.Find("Table");
    }
    void Update()
    {
        transform.position = Camera.main.transform.position;
        //gameObject.transform.LookAt(table.transform.position);
    }
}
