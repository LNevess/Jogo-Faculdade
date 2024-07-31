using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    [SerializeField] private GameObject targetObject; // Objeto alvo a ser ativado pela distância
                     public GameObject interactObject; // Objeto alvo a ser ativado pela interação
    [SerializeField] private Transform player; // Referência ao jogador
    [SerializeField] private float activationDistance = 5.0f; // Distância para ativação
    public Dialog dialog;//    

    private bool isPlayerWithinDistance = false; // Estado para verificar se o jogador está dentro da distância

    private void Update()
    {
        // Verifica a distância entre o jogador e o objeto
        float distance = Vector3.Distance(player.position, transform.position);
        isPlayerWithinDistance = distance <= activationDistance;

        // Ativa ou desativa o objeto com base na distância
        targetObject.SetActive(isPlayerWithinDistance);

        // Verifica se o jogador pressionou a tecla 'E' e está dentro da distância
        if (isPlayerWithinDistance && Input.GetKeyDown(KeyCode.Space))
        {
            interactObject.SetActive(true);
            FindObjectOfType<DialogManager>().StartDialog(dialog);
            
        }
    }
}
