using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddingLiquid : MonoBehaviour
{
    public InstantianeObj inst;

    public GameObject textPour;
    public Text errorElement;

    [Header("Объекты анимаций")]
    public GameObject objAn;
    public GameObject objAn2;
    GameObject objPillAn;
    GameObject objPillAn2;

    [Header("Анимация")]
    public Animator anim;
    public Animator animPill;
    public Animator animPill2;
    public Animator anim2;

    [Header("Таймер")]
    public bool animTimerActiv = false;
    public float timer = 1.5f;

    [Header("Аудио")]
    public AudioSource audioSource;

    public bool activPill = false;
    private void Start()
    {
        objPillAn = GameObject.Find("AnPill");
        objPillAn2 = GameObject.Find("AnPill2");
        objAn = GameObject.Find("An");
        objAn2 = GameObject.Find("An2");
    }
    private void Update()
    {
        AddLiquid();
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
                anim2.SetBool("Zaliv", false);
                inst.objTakeOn.transform.SetParent(inst.objHand.GetComponent<Transform>());
                Instruments.ConnectPosRot(inst.objTakeOn.gameObject, inst.objHand);
                timer = 1.5f;
                animTimerActiv = false;
            }

        }
    }
    void AddLiquid()
    {
        if (inst.objTakeOn != null && inst.ACselectable != null && inst.ACselectable.CompareTag("Fill"))
        {
            textPour.SetActive(true);
            if (Input.GetMouseButtonDown(1))
            {
                
                //else
                //{
                    switch (inst.ACselectable.name)
                    {
                        case "Experience 2":
                        if (inst.objTakeOn.CompareTag("Pill") || inst.objTakeOn.name == "Spoon" || inst.objTakeOn.name == "Stirrer")
                        {
                            errorElement.text = "Этот элемент не используется здесь";
                        }
                        else
                        {
                            inst.objTakeOn.transform.parent = objAn2.transform;
                            Instruments.ConnectPosRot(inst.objTakeOn.gameObject, objAn2);
                            //animPill.SetBool("Pill", false);
                            anim2.SetBool("Zaliv", true);
                            anim.SetBool("Zaliv", false);
                            animTimerActiv = true;
                            audioSource.Play();
                        }

                        //inst.objTakeOn.transform.parent = objAn2.transform;
                        //Instruments.ConnectPosRot(inst.objTakeOn.gameObject, objAn2);
                        ////animPill.SetBool("Pill", false);
                        //anim2.SetBool("Zaliv", true);
                        //anim.SetBool("Zaliv", false);
                        //animTimerActiv = true;
                        //audioSource.Play();
                        break;
                        case "Experience 1":
                        if (inst.objTakeOn.CompareTag("Pill"))
                        {
                            inst.objTakeOn.transform.parent = objPillAn.transform;
                            Instruments.ConnectPosRot(inst.objTakeOn.gameObject, objPillAn);
                            inst.objTakeOn.GetComponent<MeshCollider>().enabled = false;
                            inst.objTakeOn = null;
                            animPill.SetBool("Pill", true);
                            //animPill2.SetBool("Pill", true);
                            activPill = true;
                        }
                        else if(inst.objTakeOn.name == "Spoon" || inst.objTakeOn.name == "Stirrer")
                            errorElement.text = "Этот элемент не используется здесь";
                        else
                        {
                            inst.objTakeOn.transform.parent = objAn.transform;
                            Instruments.ConnectPosRot(inst.objTakeOn.gameObject, objAn);
                            //animPill.SetBool("Pill", false);
                            anim.SetBool("Zaliv", true);
                            anim2.SetBool("Zaliv", false);
                            animTimerActiv = true;
                            audioSource.Play();
                        }
                        break;
                        default:
                        
                        anim2.SetBool("Zaliv", false);
                        anim.SetBool("Zaliv", false);
                            break;
                    }
                //}
            }
        }
        else
        {
            textPour.SetActive(false);
        }
        if (inst.objTakeOn && !inst.ACselectable && !animTimerActiv || inst.objTakeOn == null && !animTimerActiv)
        {
            textPour.SetActive(false);
        }
    }
}
