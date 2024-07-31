using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yesorno : MonoBehaviour
{
    bool isyes;
    public int numberProf;


    public void YES(bool isCorrect)
    {
        if (isyes) return;

        if (isCorrect)
        {
            CountManager.Instance.countProfessores++;
         
            isyes = true;
        }

        if (!isCorrect)
        {
            CountManager.Instance.countErrosProfessores++;
            CountManager.Instance.errors[numberProf].SetActive(true);
            isyes = true;
        }

    }

   

    

}
