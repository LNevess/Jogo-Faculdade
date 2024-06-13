using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O personagem que a c�mera vai seguir
    public Vector3 offset; // A dist�ncia e a posi��o da c�mera em rela��o ao personagem
    public float mouseSensitivity = 100f; // Sensibilidade do mouse para rota��o
    public float minYAngle = -30f; // �ngulo m�nimo para a rota��o vertical
    public float maxYAngle = 60f; // �ngulo m�ximo para a rota��o vertical

    private float yaw = 0f; // Rota��o em torno do eixo Y
    private float pitch = 0f; // Rota��o em torno do eixo X

    void Start()
    {
        // Se voc� quiser definir um deslocamento padr�o
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0, 3, -5); // Ajuste estes valores conforme necess�rio
        }

        // Inicializa yaw e pitch com a rota��o atual da c�mera
        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
    }

    void LateUpdate()
    {
        // Obter a entrada do mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Atualizar yaw e pitch com a entrada do mouse
        yaw += mouseX;
        pitch -= mouseY;

        // Restringir o pitch para ficar dentro dos �ngulos m�nimos e m�ximos
        pitch = Mathf.Clamp(pitch, minYAngle, maxYAngle);

        // Calcular a nova rota��o da c�mera
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        // Atualizar a posi��o da c�mera
        transform.position = desiredPosition;

        // Fazer a c�mera olhar para o personagem
        transform.LookAt(target);
    }
}
