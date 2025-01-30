using UnityEngine;

public class ObjetoRecolectable : MonoBehaviour
{
    [SerializeField] private Izquierda personaje; // Referencia al personaje
    [SerializeField] private float radioNuevo = 9f; // Radio que tendrá el personaje cuando se recoja el objeto
    [SerializeField] private Vector3 nuevaEscala = new Vector3(2f, 2f, 1f); // Nueva escala que tendrá el círculo cuando se recoja el objeto

    private float radioOriginal; // Radio original del personaje
    private Vector3 escalaOriginal; // Escala original del círculo
    private Coroutine restaurarCoroutine;

    private void Start()
    {
        // Guardamos los valores originales
        if (personaje != null)
        {
            radioOriginal = personaje.bubbleRadius;
        }

        // Guardamos la escala original del círculo
        escalaOriginal = transform.localScale;
    }

    // Método para ajustar el tamaño y radio al recoger el objeto
    public void AjustarTamañoYRadio()
    {
        // Cambiar la escala del círculo
        transform.localScale = nuevaEscala;

        // Cambiar el radio del personaje
        CambiarBubbleRadius();

        // Iniciar el proceso para restaurar ambos valores (escala y radio) después de 10 segundos
        if (restaurarCoroutine != null)
        {
            StopCoroutine(restaurarCoroutine);
        }
        restaurarCoroutine = StartCoroutine(RestablecerEstadoOriginal());
    }

    // Cambiar el radio del personaje
    private void CambiarBubbleRadius()
    {
        if (personaje != null)
        {
            // Cambiar el radio del personaje al valor nuevo
            personaje.bubbleRadius = radioNuevo;
            personaje.baseSpeed = 15;

        }
        else
        {
            Debug.LogWarning("El componente 'izquierda' no está asignado en el Inspector.");
        }
    }

    // Corutina para restaurar el estado original después de 10 segundos
    private System.Collections.IEnumerator RestablecerEstadoOriginal()
    {
        yield return new WaitForSeconds(10f);

        // Restaurar la escala original del círculo
        transform.localScale = escalaOriginal;
        personaje.baseSpeed = 10;

        // Restaurar el radio original del personaje
        if (personaje != null)
        {
            personaje.bubbleRadius = radioOriginal;
        }
        else
        {
            Debug.LogWarning("El componente 'izquierda' no está asignado en el Inspector.");
        }
    }

    // Método para cambiar el radio original desde este script
    public void ConfigurarRadioOriginal(float nuevoRadioOriginal)
    {
        radioOriginal = nuevoRadioOriginal;

        // Si el componente 'izquierda' está asignado, también actualizamos su 'bubbleRadius' inicial
        if (personaje != null)
        {
            personaje.bubbleRadius = nuevoRadioOriginal;
        }
    }
}
