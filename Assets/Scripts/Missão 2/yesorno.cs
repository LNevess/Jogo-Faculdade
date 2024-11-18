using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// para fazer o botão ser pressionado apenas uma vez por fase.
/// está ruim, mas funciona.
/// </summary>
public class yesorno : MonoBehaviour
{
    bool isyes;
    public int numberProf;

    public Image buttonImage;

	private void Start()
	{
		buttonImage = GetComponent<Image>();
	}
	public void YES(bool isCorrect)
    {
        if (isyes) return;

        if (isCorrect)
        {
            CountManager.Instance.countProfessores++;
         
            isyes = true;
            Debug.Log(CountManager.Instance.countProfessores);

            buttonImage.color = Color.green;
        }

        if (!isCorrect)
        {
            CountManager.Instance.countErrosProfessores++;
            CountManager.Instance.errors[numberProf].SetActive(true);
            isyes = true;
			buttonImage.color = Color.red;
		}

    }

   

    

}
