using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CountManager : MonoBehaviour
{
    public static CountManager Instance;
	public int countProfessores;
	public int countErrosProfessores;
	
	public bool mineGameOn;


	public GameObject screenMake;
	public GameObject screenError;
	public GameObject[] errors;


    private void Awake()
    {
		Instance = this;
    }

    private void Start()
	{
		mineGameOn = false;
		screenMake.SetActive(false);
		screenError.SetActive(false);

		for (int i = 0; i < errors.Length; i++)
		{
			errors[i].SetActive(false);
		}
	}
	private void Update()
	{
		if (countProfessores == 8) 
		{
			screenMake.SetActive(true);		
		}

        if (countErrosProfessores == 4)
        {
            screenError.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

		if (countErrosProfessores == 1)
		{
			errors[0].SetActive(true);
		}
		if (countErrosProfessores ==2)
		{
			errors[1].SetActive(true);
		}
		if (countErrosProfessores == 3)
		{
			errors[2].SetActive(true);
		}
		if (countErrosProfessores == 4)
		{
			errors[3].SetActive(true);
		}
	}

	public void GOTO(string nameScene) 
	{
		SceneManager.LoadScene(nameScene);
	}
}
