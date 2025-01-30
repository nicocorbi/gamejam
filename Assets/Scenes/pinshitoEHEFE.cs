using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class pinshitoEHEFE : MonoBehaviour
{
    [SerializeField] public float timePassed;
    [SerializeField] Transform controladorDisparo;
    [SerializeField] GameObject pinsho;
    [SerializeField] float delayIniciar = 6f; // Retraso inicial antes de empezar
    [SerializeField] float intervaloDisparo = 6f; // Intervalo entre disparos

    // Direcciones posibles para las balas
    private Vector2[] bulletDirections = { Vector2.up, Vector2.down, Vector2.right, Vector2.left };

    void Start()
    {
        InvokeRepeating("spinas", delayIniciar, intervaloDisparo);
    }

    private void Update()
    {
        timePassed += Time.deltaTime; // Incrementa el tiempo transcurrido

        // Cambiar de escena si han pasado 180 segundos
        if (timePassed >= 180f)
        {
            CambiarEscena();
        }
        if (timePassed >= 80) { intervaloDisparo = 1;
        }
    }

    void spinas()
    {
        // Instancia una nueva bala
        GameObject nuevaBala = Instantiate(pinsho, controladorDisparo.position, controladorDisparo.rotation);

        // Obtén el script de la bala
        pinsho22 pinchoScript = nuevaBala.GetComponent<pinsho22>();

        // Asegúrate de que la bala tenga un componente de dirección
        if (pinchoScript == null)
        {
            Debug.LogError("El prefab de la bala no tiene el script pinsho22.");
            return;
        }

        // Define la dirección y la velocidad de la bala
        if (timePassed < 5)
        {
            pinchoScript.bulletDirection = bulletDirections[Random.Range(0, bulletDirections.Length)];
            pinchoScript.bulletSpeed = 0.6f;
        }
        else
        {
            // Cambia la dirección de forma dinámica según el tiempo
            pinchoScript.bulletDirection = bulletDirections[Random.Range(0, bulletDirections.Length)];
            pinchoScript.bulletSpeed = 1.5f;
        }

        // Normaliza la dirección de la bala para que sea un vector unitario
        pinchoScript.bulletDirection.Normalize();
    }

    void CambiarEscena()
    {
        // Cambia a la escena deseada
        SceneManager.LoadScene("Muerte"); // Sustituye "NombreDeLaEscena" con el nombre exacto de tu escena
    }
}


