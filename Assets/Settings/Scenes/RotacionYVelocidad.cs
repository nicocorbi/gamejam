using UnityEngine;

public class RotacionYVelocidad : MonoBehaviour
{
    // Velocidad de rotaci�n
    public float velocidadRotacion = 100f;
    private float contadorTiempo = 0f;

    void Update()
    {
        // Control de la rotaci�n
        contadorTiempo += Time.deltaTime;
        if (contadorTiempo >= 5f)  // Ajuste para cambiar la direcci�n de rotaci�n cada 5 segundos
        {
            velocidadRotacion = -velocidadRotacion;  // Cambiar direcci�n
            contadorTiempo = 0f;
        }

        // Rotaci�n del objeto
        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);
    }
}
