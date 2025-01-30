using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Cargar la escena principal del juego
        SceneManager.LoadScene("SampleScene"); // Cambia "SampleScene" por el nombre de tu escena principal
    }

    

    public void QuitGame()
    {
        // Salir del juego
        Debug.Log("Salir del juego");
        Application.Quit(); // Funciona solo en un juego compilado
    }

    public void IrASettings()
    {
        SceneManager.LoadScene("Settings"); // Aseg�rate de que "Settings" es el nombre exacto de la escena
    }

    public void ReturnToMainMenu()
    {
        // Cargar la escena del men� principal
        SceneManager.LoadScene("Menu"); // Cambia "MainMenu" por el nombre de tu escena de men� principal
        Debug.Log("Volver al men� principal");
    }
    public void IniciarAnimacion()
    {
        // Cargar la escena del men� principal
        SceneManager.LoadScene("Animacion_Inicio"); // Cambia "MainMenu" por el nombre de tu escena de men� principal
        Debug.Log("empezar animacion");
    }
}