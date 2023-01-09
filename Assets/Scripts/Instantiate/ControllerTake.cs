using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControllerTake : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    [Header ("Цвет объекта и его слой") ]
    public Color col;
    public LayerMask layerMask;
    [Header("Объекты")]
    public GameObject obj;

    public InstantianeObj inst;
    public AddingLiquid addingLiquid;

    [Header("Активатор")]
    public bool OffClickTake = false;
    private void LateUpdate()
    {
        RayInstantiate();
    }
    void RayInstantiate()
    {
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, 5, layerMask) && inst.objTakeOn && addingLiquid.timer == 1.5f)
        {
            OffClickTake = true;
            obj.SetActive(true);
            obj.transform.position = ray.GetPoint(hit.distance);
            obj.GetComponent<Renderer>().material.color = col;
                
        }
        else
        {
            obj.SetActive(false);
            OffClickTake = false;
        }
    }
    
}