using UnityEngine;

public class puntos : MonoBehaviour
{
    // Referencia al componente ObjetoRecolectable
    private ObjetoRecolectable tamañoCirculo;

    private void Start()
    {
        // Asegúrate de que el objeto con el tag "Ground" tiene el componente ObjetoRecolectable
        tamañoCirculo = GameObject.FindGameObjectWithTag("Ground").GetComponent<ObjetoRecolectable>();

        // Comprobamos si el componente está asignado desde el Inspector
        if (tamañoCirculo == null)
        {
            Debug.LogError("El componente ObjetoRecolectable no está asignado. Por favor, asigna el componente en el Inspector.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que entra tiene la etiqueta "Player"
        if (collision.CompareTag("Player"))
        {
            // Desactiva el objeto (o destrúyelo si es necesario)
            gameObject.SetActive(false);

            // Llama al método que ajusta el tamaño y el radio del personaje y del círculo
            if (tamañoCirculo != null)
            {
                tamañoCirculo.AjustarTamañoYRadio();  // Llama al método correcto
            }
            else
            {
                Debug.LogError("El componente ObjetoRecolectable no está asignado, no se puede ajustar el tamaño.");
            }
        }
    }
}

