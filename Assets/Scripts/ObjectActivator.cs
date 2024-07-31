using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    [SerializeField] private GameObject targetObject; // Objeto alvo a ser ativado pela dist�ncia
                     public GameObject interactObject; // Objeto alvo a ser ativado pela intera��o
    [SerializeField] private Transform player; // Refer�ncia ao jogador
    [SerializeField] private float activationDistance = 5.0f; // Dist�ncia para ativa��o
    public Dialog dialog;//    

    private bool isPlayerWithinDistance = false; // Estado para verificar se o jogador est� dentro da dist�ncia

    private void Update()
    {
        // Verifica a dist�ncia entre o jogador e o objeto
        float distance = Vector3.Distance(player.position, transform.position);
        isPlayerWithinDistance = distance <= activationDistance;

        // Ativa ou desativa o objeto com base na dist�ncia
        targetObject.SetActive(isPlayerWithinDistance);

        // Verifica se o jogador pressionou a tecla 'E' e est� dentro da dist�ncia
        if (isPlayerWithinDistance && Input.GetKeyDown(KeyCode.Space))
        {
            interactObject.SetActive(true);
            FindObjectOfType<DialogManager>().StartDialog(dialog);
            
        }
    }
}
