using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Necesitas importar esto para usar TMP
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public TMP_Text countdownText;  // Referencia al texto TMP que mostrará el contador
    public string sceneToLoad = "SampleScene"; // Nombre de la escena a cargar (se mantiene solo para el ejemplo)
    public AudioClip countdownClip;  // Sonido para la cuenta regresiva y el "GO!"
    private AudioSource audioSource; // Referencia al componente AudioSource

    private bool gameStarted = false; // Variable para saber si el juego ha comenzado

    void Start()
    {
        // Configura el AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No se encontró un AudioSource en el objeto. Por favor, añade uno.");
            return;
        }

        // Pausar el juego al principio
        Time.timeScale = 0f;  // Esto detendrá el juego
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        int countdownValue = 3;

        // Mostrar el contador
        while (countdownValue > 0)
        {
            countdownText.text = countdownValue.ToString();  // Actualiza el texto con el valor actual

            // Reproducir sonido de la cuenta regresiva
            if (countdownClip != null && audioSource != null)
            {
                audioSource.PlayOneShot(countdownClip); // Reproduce el sonido
            }

            yield return new WaitForSecondsRealtime(1f);  // Espera 1 segundo real (no afectado por Time.timeScale)
            countdownValue--;  // Decrementa el valor del contador
        }

        // Mostrar "GO!" antes de empezar
        countdownText.text = "GO!";

        // Reproducir sonido de "GO!" (mismo sonido que la cuenta regresiva)
        if (countdownClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(countdownClip); // Reproduce el sonido
        }

        yield return new WaitForSecondsRealtime(1f);  // Espera 1 segundo real antes de continuar

        // Iniciar el juego
        countdownText.gameObject.SetActive(false);  // Ocultar el texto del contador
        Time.timeScale = 1f;  // Reactivar el juego (despausar)
        gameStarted = true;  // Indicar que el juego ha comenzado
    }

    void Update()
    {
        // Aquí puedes verificar si el juego ha comenzado y permitir interacciones
        if (gameStarted)
        {
            // Código para que el jugador pueda jugar aquí (por ejemplo, mover al jugador, interactuar, etc.)
        }
    }
}
