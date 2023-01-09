using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience2 : MonoBehaviour
{
    public InstantianeObj inst;
    public AddingLiquid addingLiquid;

    [Header("Анимация опыта")]
    public Animator animEx2;

    [Header("Тексты ошибок")]
    public GameObject errorBottle;
    public Text errorElement;
    [Header("Номер опыта")]
    Text nameExperience2;

    [Header("Выполнение опыта")]
    public GameObject winLab;

    bool activAcid = false;
    [SerializeField] public bool activTimer;

    float timer = 1.5f;
    float timer2 = 5f;
    private void Start()
    {
        errorBottle.SetActive(false);
        winLab.SetActive(false);
        activAcid = false;
        nameExperience2 = GameObject.Find("TextNameExperience").GetComponent<Text>();
    }
    private void Update()
    {
        Potion();
    }
    private void OnMouseEnter()
    {
        nameExperience2.text = "Опыт 2";
    }
    private void OnMouseExit()
    {
        nameExperience2.text = "";
    }
    void Potion()
    {
        try
        {
            switch (inst.objTakeOn.name)
            {
                case "HCl":
                    if (inst.ACselectable.name == "Experience 2" && addingLiquid.animTimerActiv && !activAcid 
                        && inst.objTakeOn.transform.parent == addingLiquid.objAn2.transform)
                    {
                        animEx2.SetBool("Ex2ColorWater", true);
                        activAcid = true;
                        errorBottle.SetActive(false);
                    }
                    break;
                case "С13H22O6":
                    if (inst.ACselectable.name == "Experience 2" && addingLiquid.animTimerActiv && activAcid
                        && inst.objTakeOn.transform.parent == addingLiquid.objAn2.transform)
                    {
                        animEx2.SetBool("Ex2AddLacmus", true);
                        activTimer = true;
                    }
                    if (addingLiquid.animTimerActiv && !activAcid && inst.selectable.name == "Experience 2")
                        errorElement.text = "Этот элемент должен использоваться после HCl";
                    break;
                default:
                    if (inst.objTakeOn.name != "HCl" && inst.objTakeOn.name != "С13H22O6" && addingLiquid.animTimerActiv
                        && inst.objTakeOn.transform.parent == addingLiquid.objAn2.transform && inst.selectable.name == "Experience 2")
                        errorBottle.SetActive(true);
                    else
                        errorBottle.SetActive(false);
                    break;
            }
        }
        catch
        {
            errorBottle.SetActive(false);
            //Debug.LogError("Нет объекта");
            if (addingLiquid.timer >= 1.4f)
                errorElement.text = " ";
            if (activTimer)
            {
                timer -= Time.deltaTime;
                if (timer <= 0.1f)
                {
                    winLab.SetActive(true);
                    timer2 -= Time.deltaTime;
                    if (timer2 <= 0.01f)
                        winLab.SetActive(false);
                }
            }
           
        }
    }
}
