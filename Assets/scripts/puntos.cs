using UnityEngine;

public class puntos : MonoBehaviour
{
    // Referencia al componente ObjetoRecolectable
    private ObjetoRecolectable tama�oCirculo;

    private void Start()
    {
        // Aseg�rate de que el objeto con el tag "Ground" tiene el componente ObjetoRecolectable
        tama�oCirculo = GameObject.FindGameObjectWithTag("Ground").GetComponent<ObjetoRecolectable>();

        // Comprobamos si el componente est� asignado desde el Inspector
        if (tama�oCirculo == null)
        {
            Debug.LogError("El componente ObjetoRecolectable no est� asignado. Por favor, asigna el componente en el Inspector.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que entra tiene la etiqueta "Player"
        if (collision.CompareTag("Player"))
        {
            // Desactiva el objeto (o destr�yelo si es necesario)
            gameObject.SetActive(false);

            // Llama al m�todo que ajusta el tama�o y el radio del personaje y del c�rculo
            if (tama�oCirculo != null)
            {
                tama�oCirculo.AjustarTama�oYRadio();  // Llama al m�todo correcto
            }
            else
            {
                Debug.LogError("El componente ObjetoRecolectable no est� asignado, no se puede ajustar el tama�o.");
            }
        }
    }
}

