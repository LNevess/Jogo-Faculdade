using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveUIinRange : MonoBehaviour
{
	public GameObject targetObject; // Objeto alvo a ser ativado pela distância
	public GameObject interactObject; // Objeto alvo a ser ativado pela interação
	public Transform player; // Referência ao jogador
	public float activationDistance = 5.0f; // Distância para ativação
	  

	public bool isPlayerWithinDistance = false; // Estado para verificar se o jogador está dentro da distância


	public bool jaContoUmaVezOK;
	public CountManager countManager;
	private void Start()
	{
		countManager = FindObjectOfType<CountManager>();
		jaContoUmaVezOK = false;
	}
	private void Update()
	{
		// Verifica a distância entre o jogador e o objeto
		float distance = Vector3.Distance(player.position, transform.position);
		isPlayerWithinDistance = distance <= activationDistance;

		// Ativa ou desativa o objeto com base na distância
		targetObject.SetActive(isPlayerWithinDistance);

		// Verifica se o jogador pressionou a tecla 'E' e está dentro da distância
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
