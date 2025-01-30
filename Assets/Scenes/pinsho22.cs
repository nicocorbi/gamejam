using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importar para cambiar de escena

public class pinsho22 : MonoBehaviour
{
    [SerializeField] public float bulletSpeed; // Velocidad del pincho
    public Vector2 bulletDirection; // Dirección del movimiento del pincho
    private bool hasTouchedEdge = false; // Variable para comprobar si ha tocado el edge

    private void Start()
    {
        // Verifica que el pincho tenga un Collider configurado como Trigger
        Collider2D collider = GetComponent<Collider2D>();
        if (collider == null || !collider.isTrigger)
        {
            Debug.LogWarning("Advertencia: El pincho no tiene un Collider2D configurado como Trigger.");
        }
    }

    private void Update()
    {
        // Mueve el pincho en la dirección establecida
        transform.Translate(bulletDirection * bulletSpeed * Time.deltaTime);

        // Destruye el pincho si se sale de los límites visibles
        if (transform.position.x >= 15 || transform.position.y >= 15 ||
            transform.position.y <= -15 || transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el pincho colisiona con el Edge Collider
        if (collision.CompareTag("Ground")) // El Edge debe tener el tag "Edge"
        {
            Debug.Log("El pincho ha tocado el edge.");
            SceneManager.LoadScene("Muerte"); // Cambia a la escena "Muerte"
        }

        // Verifica si el pincho colisiona con el jugador (Player)
        if (collision.CompareTag("Player")) // El jugador debe tener el tag "Player"
        {
            Debug.Log("El pincho ha tocado al jugador.");
            Destroy(gameObject); // Destruye el pincho
        }
    }
}

