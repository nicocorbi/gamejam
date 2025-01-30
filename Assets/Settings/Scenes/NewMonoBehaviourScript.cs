using UnityEngine;

public class CircleInteraction : MonoBehaviour
{
    public Transform groundCircle; // Referencia al c�rculo que act�a como suelo
    public float minGrowthFactor = 0.5f; // Factor m�nimo de disminuci�n (reduce el tama�o)
    public float maxGrowthFactor = 1.5f; // Factor m�ximo de crecimiento (aumenta el tama�o)
    public float growthDuration = 1.0f; // Tiempo que tomar� en crecer o disminuir

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el personaje recoge un c�rculo con el tag "punto1"
        if (collision.CompareTag("punto1"))
        {
            // Inicia la corrutina para hacer crecer o disminuir el suelo gradualmente
            StartCoroutine(GrowOrShrinkGroundCircle());

            // Destruye el c�rculo recolectable
            Destroy(collision.gameObject);
        }
    }

    private System.Collections.IEnumerator GrowOrShrinkGroundCircle()
    {
        // Determina aleatoriamente si el suelo debe aumentar o disminuir
        float randomFactor = Random.Range(minGrowthFactor, maxGrowthFactor);
        Vector3 initialScale = groundCircle.localScale; // Tama�o inicial del suelo
        Vector3 targetScale = initialScale * randomFactor; // Tama�o objetivo basado en el factor aleatorio
        float elapsedTime = 0f; // Tiempo transcurrido

        // Incrementar o decrecer el tama�o poco a poco durante "growthDuration"
        while (elapsedTime < growthDuration)
        {
            groundCircle.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / growthDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // Espera hasta el siguiente frame
        }

        // Asegurar que el tama�o final sea exactamente el objetivo
        groundCircle.localScale = targetScale;
    }
}


