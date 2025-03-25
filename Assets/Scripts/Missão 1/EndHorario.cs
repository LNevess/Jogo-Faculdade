using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndHorario : MonoBehaviour
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
    if (count == 9)
    {
        calendarios[0].SetActive(false);
        calendarios[1].SetActive(true);
    }

    if (count == 19)
    {
        calendarios[1].SetActive(false);
        vitoria.SetActive(true);
        xpAnimator.StartXPAnimation(1f);
    }

    }
}

