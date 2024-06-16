using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CountManager : MonoBehaviour
{
    public int countProfessores;
	public bool mineGameOn;

	public GameObject screenMake;


	private void Start()
	{
		mineGameOn = false;
		screenMake.SetActive(false);
	}
	private void Update()
	{
		if (countProfessores == 8) 
		{
			screenMake.SetActive(true);			
		}
	}

	public void GOTO(string nameScene) 
	{
		SceneManager.LoadScene(nameScene);
	}
}
