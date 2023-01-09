using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeMouse : MonoBehaviour
{
    //Ray ray;
    //RaycastHit hit;

    //public AcSelectable selectable;

    //public AcSelectable ACselectable;

    //public GameObject pointer;
    //void LateUpdate()
    //{
    //    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    Debug.DrawRay(transform.position, transform.forward * 10, Color.black);

    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        pointer.transform.position = hit.point;

    //        selectable = hit.collider.gameObject.GetComponent<AcSelectable>();
    //        if (selectable == true)
    //        {
    //            if (ACselectable && ACselectable != selectable)
    //            {
    //                ACselectable.Deselect();
    //            }
    //            ACselectable = selectable;
    //            ACselectable.Select();
    //        }
    //        else
    //        {
    //            if (ACselectable)
    //            {
    //                ACselectable.Deselect();
    //                ACselectable = null;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        if (ACselectable)
    //        {
    //            ACselectable.Deselect();
    //            ACselectable = null;
    //        }
    //    } 
    
    //}
    public ControllerTake controllerTake;

    [Header("Камера и луч")]
    public Camera cam;
    protected Ray ray;
    protected RaycastHit hit;

    [Header("Рука")]
    public GameObject objHand;

    [Header("Объекты взаимодействия")]
    public AcSelectable objTakeOn;

    public AcSelectable selectable;

    public AcSelectable ACselectable;

    [Header("Текст ПКМ")]
    public GameObject textPour;

    GameObject objAn;
    GameObject objPillAn;

    [Header("Слой")]
    public LayerMask layerMask;
    public LayerMask lMask;

    [Header("Анимация")]
    public Animator anim;
    public Animator animPill;

    [Header("Таймер")]
    public bool animTimerActiv = false;
    public float timer = 1.5f;

    [Header("Аудио")]
    public AudioSource audioSource;

    public bool activPill = false;
    void Start()
    {
        textPour.SetActive(false);
        objPillAn = GameObject.Find("AnPill");
        objAn = GameObject.Find("An");
    }
    void LateUpdate()
    {
        //ray = new Ray(transform.position, transform.forward);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.black);

        if (Physics.Raycast(ray, out hit, 5, layerMask))
        {
            selectable = hit.collider.gameObject.GetComponent<AcSelectable>();
            if (selectable == true)
            {
                if (ACselectable && ACselectable != selectable)
                {
                    ACselectable.Deselect();
                }
                ACselectable = selectable;
                ACselectable.Select();
            }
            else
            {
                if (ACselectable)
                {
                    ACselectable.Deselect();
                    ACselectable = null;
                }
            }
        }
        else
        {
            if (ACselectable)
            {
                ACselectable.Deselect();
                ACselectable = null;
            }
        }
        TakingAnObject();
        TimerActivator();
    }
    void TimerActivator()
    {
        if (animTimerActiv == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.1f)
            {
                anim.SetBool("Zaliv", false);
                objTakeOn.transform.SetParent(objHand.GetComponent<Transform>());
                Instruments.ConnectPosRot(objTakeOn.gameObject, objHand);
                timer = 1.5f;
                animTimerActiv = false;
            }
        }
    }
    void TakingAnObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ACselectable && !controllerTake.OffClickTake)
            {
                objTakeOn = ACselectable;
                objTakeOn.rb.isKinematic = true;
                Instruments.ConnectPosRot(objTakeOn.gameObject, objHand);
                objTakeOn.transform.SetParent(objHand.GetComponent<Transform>());
            }
            if (objTakeOn && controllerTake.OffClickTake)
            {
                objTakeOn.rb.isKinematic = false;
                objTakeOn.transform.parent = null;
                objTakeOn.transform.position = controllerTake.obj.transform.position + new Vector3(0, 0.2f, 0);
                objTakeOn = null;
            }
        }
        if (objTakeOn != null && ACselectable != null && ACselectable.CompareTag("Fill"))
        {
            textPour.SetActive(true);
            if (Input.GetMouseButtonDown(1))
            {
                if (objTakeOn.CompareTag("Pill"))
                {
                    objTakeOn.transform.parent = objPillAn.transform;
                    Instruments.ConnectPosRot(objTakeOn.gameObject, objPillAn);
                    objTakeOn.GetComponent<MeshCollider>().enabled = false;
                    objTakeOn = null;
                    animPill.SetBool("Pill", true);
                    activPill = true;
                }
                else
                {
                    objTakeOn.transform.parent = objAn.transform;
                    Instruments.ConnectPosRot(objTakeOn.gameObject, objAn);
                    //animPill.SetBool("Pill", false);
                    anim.SetBool("Zaliv", true);
                    animTimerActiv = true;
                    audioSource.Play();
                }
            }
        }
        else
        {
            textPour.SetActive(false);
        }


        if (objTakeOn && !ACselectable && !animTimerActiv || objTakeOn == null && !animTimerActiv)
        {
            textPour.SetActive(false);
        }
    }
}
