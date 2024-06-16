using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountManager : MonoBehaviour
{
    public int countProfessores;
	public bool mineGameOn;


	private void Start()
	{
		mineGameOn = false;
	}
	private void Update()
	{
		if (countProfessores == 8) 
		{
			mineGameOn = true;
		}
	}
}
