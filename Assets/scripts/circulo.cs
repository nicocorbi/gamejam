using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Circulo : MonoBehaviour
{
    // Variables relacionadas con la rotaci�n y control del juego
    public float velocidadRotacion = 100f;
    private bool circuloRecolectado = false;

    // Puntos de spawn para el c�rculo recolectable
    public Transform[] spawnPoints;
    public float respawnTime = 10f;

    [SerializeField] TMP_Text gameOver;

    // Variables privadas para la l�gica de rotaci�n
    private float contadorTiempo = 0f;
    private float tiempoCambioDireccion;
    private float contadorAumentoVelocidad = 0f;

    void Start()
    {
        // No m�s l�gica de escala inicial
    }

    void Update()
    {
        // Control de la rotaci�n
        contadorTiempo += Time.deltaTime;
        if (contadorTiempo >= 5f)  // Ajuste para cambiar la direcci�n de rotaci�n cada 5 segundos
        {
            velocidadRotacion = -velocidadRotacion;
            contadorTiempo = 0f;
        }

        // Rotaci�n del objeto
        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);

        // Si el c�rculo ha sido recolectado (sin cambios en escala)
        if (circuloRecolectado)
        {
            circuloRecolectado = false; // Resetea el estado para esperar el pr�ximo ciclo
        }
    }

    // Funci�n que se llama cuando el c�rculo es recolectado por el jugador
    public void OnCircleCollected()
    {
        // Cambiar el estado a "Recolectado"
        circuloRecolectado = true;

        // Iniciar el respawn (reaparecer el c�rculo en un punto de spawn aleatorio)
        Invoke("RespawnCircle", respawnTime);
    }

    // Funci�n para hacer que el recolectable reaparezca en un punto de spawn aleatorio
    void RespawnCircle()
    {
        if (spawnPoints.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            transform.position = spawnPoints[randomIndex].position;
        }
    }

    // Colisi�n con un objeto con el tag "pinchi"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pinchi"))
        {
            print("HIT");
            SceneManager.LoadScene("Muerte");
        }
    }

    internal void SeleccionarEscalaAleatoria()
    {
        throw new System.NotImplementedException();
    }

    internal void CambiarEscala()
    {
        throw new System.NotImplementedException();
    }
}

