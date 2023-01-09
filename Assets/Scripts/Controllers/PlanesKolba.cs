using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanesKolba : MonoBehaviour
{
    public bool activPut;
    public InstantianeObj instantianeObj;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            activPut = true;
        }
        if(collision.gameObject.layer == 7)
        {
            activPut = false;
        }
    }
    private void Update()
    {
        if (activPut == true)
        {
            Debug.Log("Не ставится!");
        }
        else
        {
            Debug.Log("Cтавится!");
        }

    }
}
