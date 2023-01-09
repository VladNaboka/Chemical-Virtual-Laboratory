using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience1 : MonoBehaviour
{
    public InstantianeObj inst;
    public AddingLiquid addingLiquid;

    Text nameExperience1; // Номер опыта

    [Header("Анимация опыта")]
    public Animator animShader;
    public Animator animExp;

    [Header("Выход ошибки. Не тот элемент")]
    public GameObject errorBottle;

    public Text errorElement;

    [SerializeField] public bool activFenilftalein = false;

    [Header("Выполнение опыта")]
    public GameObject winLab;

    float timer = 1.5f;
    float timer2 = 5f;
    private void Start()
    {
        errorBottle.SetActive(false);
        winLab.SetActive(false);
        nameExperience1 = GameObject.Find("TextNameExperience").GetComponent<Text>();
    }
    private void Update()
    {
        Potion();        
    }
    private void OnMouseEnter()
    {
        nameExperience1.text = "Опыт 1";
    }
    private void OnMouseExit()
    {
        nameExperience1.text = "";
    }
    void Potion()
    {
        try
        {
            switch (inst.objTakeOn.name)
            {
                case "C20H14O4":
                    if (addingLiquid.animTimerActiv && inst.ACselectable.name == "Experience 1"
                        && inst.objTakeOn.transform.parent == addingLiquid.objAn.transform)
                    {
                        animShader.SetBool("shaderAnim", true);
                        activFenilftalein = true;
                        errorBottle.SetActive(false);
                    }
                    break;
                default:
                    if (addingLiquid.animTimerActiv && inst.objTakeOn.name != "C20H14O4" && inst.selectable.name == "Experience 1")
                        errorBottle.SetActive(true);

                    //else
                    //    errorBottle.SetActive(false);
                    break;
            }
        }
        catch
        {
            if (addingLiquid.animTimerActiv && inst.objTakeOn.name != "C20H14O4" && inst.selectable.name == "Experience 1")
                errorBottle.SetActive(true);

            errorBottle.SetActive(false);
            if (addingLiquid.timer >= 1.4f)
                errorElement.text = " ";
        }
        if (activFenilftalein && addingLiquid.activPill)
        {
            animExp.SetBool("shaderExperience1", true);
            timer -= Time.deltaTime;
            if (timer <= 0.1f)
            {
                winLab.SetActive(true);
                timer2 -= Time.deltaTime;
                if (timer2 <= 0.01f)
                    winLab.SetActive(false);
            }
            
        }
        else
            animExp.SetBool("shaderExperience1", false);
    }

}
