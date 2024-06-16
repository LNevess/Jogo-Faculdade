using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveUIinRange : MonoBehaviour
{
	public GameObject targetObject; // Objeto alvo a ser ativado pela dist�ncia
	public GameObject interactObject; // Objeto alvo a ser ativado pela intera��o
	public Transform player; // Refer�ncia ao jogador
	public float activationDistance = 5.0f; // Dist�ncia para ativa��o
	  

	public bool isPlayerWithinDistance = false; // Estado para verificar se o jogador est� dentro da dist�ncia


	public bool jaContoUmaVezOK;
	public CountManager countManager;
	private void Start()
	{
		countManager = FindObjectOfType<CountManager>();
		jaContoUmaVezOK = false;
	}
	private void Update()
	{
		// Verifica a dist�ncia entre o jogador e o objeto
		float distance = Vector3.Distance(player.position, transform.position);
		isPlayerWithinDistance = distance <= activationDistance;

		// Ativa ou desativa o objeto com base na dist�ncia
		targetObject.SetActive(isPlayerWithinDistance);

		// Verifica se o jogador pressionou a tecla 'E' e est� dentro da dist�ncia
		if (isPlayerWithinDistance && Input.GetKeyDown(KeyCode.E))
		{
			interactObject.SetActive(true);
			if (!jaContoUmaVezOK) 
			{
				countManager.countProfessores++;
				jaContoUmaVezOK = true;
			}	
		}
	}
}
