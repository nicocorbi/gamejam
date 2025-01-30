using UnityEngine;

public class RotacionYVelocidad : MonoBehaviour
{
    // Velocidad de rotación
    public float velocidadRotacion = 100f;
    private float contadorTiempo = 0f;

    void Update()
    {
        // Control de la rotación
        contadorTiempo += Time.deltaTime;
        if (contadorTiempo >= 5f)  // Ajuste para cambiar la dirección de rotación cada 5 segundos
        {
            velocidadRotacion = -velocidadRotacion;  // Cambiar dirección
            contadorTiempo = 0f;
        }

        // Rotación del objeto
        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);
    }
}
