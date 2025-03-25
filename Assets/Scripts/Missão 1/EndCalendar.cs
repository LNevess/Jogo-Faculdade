using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCalendar : MonoBehaviour
{

    public int count;
    public GameObject vitoria;
    public GameObject[] calendarios;
    public XpBarAnimator1 xpAnimator;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 5)
        {
            calendarios[0].SetActive(false);
            calendarios[1].SetActive(true);
        }

        if (count == 10)
        {
            calendarios[1].SetActive(false);
            calendarios[2].SetActive(true);
        }

        if (count == 15)
        {
            calendarios[2].SetActive(false);
            calendarios[3].SetActive(true);
        }

        if (count == 20)
        {
            calendarios[3].SetActive(false);
            calendarios[4].SetActive(true);
        }

        if (count == 25)
        {
            calendarios[4].SetActive(false);
            calendarios[5].SetActive(true);
        }

        if (count == 30)
        {
            calendarios[5].SetActive(false);
            vitoria.SetActive(true);
            xpAnimator.StartXPAnimation(1f); // Exemplo: preenche a barra até 75%
        }
    }
}

