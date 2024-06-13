using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidade de movimento do personagem
    public float turnSmoothTime = 0.1f; // Tempo para suavizar a rota��o do personagem
    private float turnSmoothVelocity; // Velocidade de suaviza��o da rota��o

    public Transform cameraTransform; // Refer�ncia para a c�mera

    void Update()
    {
        // Obter as entradas de movimento
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Calcular o �ngulo de rota��o baseado na dire��o da c�mera
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            // Rotacionar o personagem na dire��o desejada
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Mover o personagem na dire��o desejada
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.Translate(moveDir.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}