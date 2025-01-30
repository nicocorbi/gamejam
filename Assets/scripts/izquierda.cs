using UnityEngine;

public class Izquierda : MonoBehaviour
{
    [SerializeField] Transform izquierda;
    [SerializeField] Transform derecha;
    [SerializeField] Transform arriba;
    [SerializeField] Transform abajo;
    [SerializeField] public float baseSpeed = 10f; // Velocidad base del jugador
    [SerializeField] Transform bubbleCenter; // Centro de la burbuja
    public float bubbleRadius = 8f; // Radio de la burbuja
    [SerializeField] Rigidbody2D rb;

    private Vector3 currentVelocity = Vector3.zero;
    private float smoothTime = 0.1f;
    private float currentSpeed; // Velocidad actual del jugador
    private bool isSpeedBoostActive = false;

    private void Start()
    {
        currentSpeed = baseSpeed; // Inicializa la velocidad actual
    }

    void Update()
    {
        Vector3 targetDirection = Vector3.zero;

        // Detecta la dirección basada en la entrada del jugador
        if (Input.GetKey(KeyCode.A))
        {
            targetDirection = (izquierda.position - transform.position).normalized;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            targetDirection = (derecha.position - transform.position).normalized;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            targetDirection = (arriba.position - transform.position).normalized;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            targetDirection = (abajo.position - transform.position).normalized;
        }

        // Solo se mueve si hay una dirección
        if (targetDirection != Vector3.zero)
        {
            // Calcula la posición suavizada
            Vector3 smoothedDirection = Vector3.SmoothDamp(
                transform.position,
                transform.position + targetDirection * currentSpeed,
                ref currentVelocity,
                smoothTime
            );

            // Calcula la dirección hacia el centro de la burbuja
            Vector3 toCenter = (smoothedDirection - bubbleCenter.position).normalized;

            // Ajusta la posición dentro del radio de la burbuja
            transform.position = bubbleCenter.position + toCenter * bubbleRadius;

            // Corrige la orientación para que los pies apunten hacia el centro de la burbuja
            transform.up = -toCenter; // Invierte la dirección para que los pies apunten hacia el centro
        }
    }

    // Activa un "speed boost" temporal
    public void ActivateSpeedBoost(float duration, float speedMultiplier)
    {
        if (!isSpeedBoostActive)
        {
            isSpeedBoostActive = true;
            currentSpeed = baseSpeed * speedMultiplier; // Multiplica la velocidad
            Debug.Log("Speed Boost Activated!");
            StartCoroutine(ResetSpeedAfterDelay(duration));
        }
    }

    // Restaura la velocidad normal después del "boost"
    private System.Collections.IEnumerator ResetSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        currentSpeed = baseSpeed; // Restablece la velocidad base
        isSpeedBoostActive = false;
        Debug.Log("Speed Boost Ended.");
    }
}
