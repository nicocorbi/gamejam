using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del Power-Up
    public float changeDirectionTime = 2f; // Tiempo entre cambios de dirección
    public float rotationSpeed = 100f; // Velocidad de rotación en el eje Z
    private Vector2 randomDirection; // Dirección aleatoria actual
    private float timer; // Temporizador para cambiar de dirección

    private void Start()
    {
        // Generar la primera dirección aleatoria
        GenerateRandomDirection();
    }

    private void Update()
    {
        // Rotar continuamente sobre el eje Z
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        // Mover el Power-Up en la dirección aleatoria
        transform.Translate(randomDirection * speed * Time.deltaTime, Space.World);

        // Cambiar de dirección después del tiempo definido
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            GenerateRandomDirection();
            timer = 0f;
        }
    }

    // Generar una nueva dirección aleatoria
    private void GenerateRandomDirection()
    {
        float angle = Random.Range(0f, 360f); // Ángulo aleatorio en grados
        float radians = angle * Mathf.Deg2Rad; // Convertir a radianes
        randomDirection = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
        randomDirection.Normalize(); // Normalizar para magnitud 1
    }

    // Detectar colisión con el jugador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Llama al método ActivateSpeedBoost del jugador
            Izquierda player = collision.GetComponent<Izquierda>();
            if (player != null)
            {
                player.ActivateSpeedBoost(10f, 2f); // Aumenta la velocidad durante 10 segundos con un multiplicador de 2x
            }

            // Desactiva el Power-Up
            Destroy(gameObject); // Elimina la instancia del Power-Up
            Debug.Log("Power-Up recogido y destruido.");
        }
    }
}

