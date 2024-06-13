using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O personagem que a câmera vai seguir
    public Vector3 offset; // A distância e a posição da câmera em relação ao personagem
    public float mouseSensitivity = 100f; // Sensibilidade do mouse para rotação
    public float minYAngle = -30f; // Ângulo mínimo para a rotação vertical
    public float maxYAngle = 60f; // Ângulo máximo para a rotação vertical

    private float yaw = 0f; // Rotação em torno do eixo Y
    private float pitch = 0f; // Rotação em torno do eixo X

    void Start()
    {
        // Se você quiser definir um deslocamento padrão
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0, 3, -5); // Ajuste estes valores conforme necessário
        }

        // Inicializa yaw e pitch com a rotação atual da câmera
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

        // Restringir o pitch para ficar dentro dos ângulos mínimos e máximos
        pitch = Mathf.Clamp(pitch, minYAngle, maxYAngle);

        // Calcular a nova rotação da câmera
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        // Atualizar a posição da câmera
        transform.position = desiredPosition;

        // Fazer a câmera olhar para o personagem
        transform.LookAt(target);
    }
}
