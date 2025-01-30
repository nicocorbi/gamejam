using UnityEngine;

public class ObjetoRecolectable : MonoBehaviour
{
    [SerializeField] private Izquierda personaje; // Referencia al personaje
    [SerializeField] private float radioNuevo = 9f; // Radio que tendr� el personaje cuando se recoja el objeto
    [SerializeField] private Vector3 nuevaEscala = new Vector3(2f, 2f, 1f); // Nueva escala que tendr� el c�rculo cuando se recoja el objeto

    private float radioOriginal; // Radio original del personaje
    private Vector3 escalaOriginal; // Escala original del c�rculo
    private Coroutine restaurarCoroutine;

    private void Start()
    {
        // Guardamos los valores originales
        if (personaje != null)
        {
            radioOriginal = personaje.bubbleRadius;
        }

        // Guardamos la escala original del c�rculo
        escalaOriginal = transform.localScale;
    }

    // M�todo para ajustar el tama�o y radio al recoger el objeto
    public void AjustarTama�oYRadio()
    {
        // Cambiar la escala del c�rculo
        transform.localScale = nuevaEscala;

        // Cambiar el radio del personaje
        CambiarBubbleRadius();

        // Iniciar el proceso para restaurar ambos valores (escala y radio) despu�s de 10 segundos
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
            Debug.LogWarning("El componente 'izquierda' no est� asignado en el Inspector.");
        }
    }

    // Corutina para restaurar el estado original despu�s de 10 segundos
    private System.Collections.IEnumerator RestablecerEstadoOriginal()
    {
        yield return new WaitForSeconds(10f);

        // Restaurar la escala original del c�rculo
        transform.localScale = escalaOriginal;
        personaje.baseSpeed = 10;

        // Restaurar el radio original del personaje
        if (personaje != null)
        {
            personaje.bubbleRadius = radioOriginal;
        }
        else
        {
            Debug.LogWarning("El componente 'izquierda' no est� asignado en el Inspector.");
        }
    }

    // M�todo para cambiar el radio original desde este script
    public void ConfigurarRadioOriginal(float nuevoRadioOriginal)
    {
        radioOriginal = nuevoRadioOriginal;

        // Si el componente 'izquierda' est� asignado, tambi�n actualizamos su 'bubbleRadius' inicial
        if (personaje != null)
        {
            personaje.bubbleRadius = nuevoRadioOriginal;
        }
    }
}
