using UnityEngine;
using UnityEngine.SceneManagement;

public class Iniciar_juego : MonoBehaviour
{
    void Start()
    {
        // Llama a la función ChangeScene después de 10 segundos
        Invoke("ChangeScene", 36f);
    }

    void ChangeScene()
    {
        // Cambia a la escena llamada "SampleScene"
        SceneManager.LoadScene("SampleScene");
    }
}