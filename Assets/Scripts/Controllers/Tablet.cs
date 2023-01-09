using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour
{
    //Открытие планшета и таблицы менделеева
    public Animator anim;
    public Animator animTable;
    bool activatorAnimLab = false;
    bool activatorLab;

    bool activatorAnimMen = false;
    bool activatorMen;
    void Start()
    {
        anim = GetComponent<Animator>();
        activatorLab = true;
        activatorMen = true;
    }
    void Update()
    {
        //activatorAnim = Input.GetKey(KeyCode.Q) ? true : false;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            activatorAnimLab = !activatorAnimLab;
            if (activatorAnimLab && activatorLab)
            {
                anim.SetBool("AnimMenu", true);
                activatorLab = false;
            }
            else
            {
                anim.SetBool("AnimMenu", false);
                activatorLab = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            activatorAnimMen = !activatorAnimMen;
            if (activatorAnimMen && activatorMen)
            {
                animTable.SetBool("Mendeleev", true);
                activatorMen = false;
            }
            else
            {
                animTable.SetBool("Mendeleev", false);
                activatorMen = true;
            }
        }
    }
}
