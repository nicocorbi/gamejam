using UnityEngine;

public class CircleInteraction : MonoBehaviour
{
    public Transform groundCircle; // Referencia al círculo que actúa como suelo
    public float minGrowthFactor = 0.5f; // Factor mínimo de disminución (reduce el tamaño)
    public float maxGrowthFactor = 1.5f; // Factor máximo de crecimiento (aumenta el tamaño)
    public float growthDuration = 1.0f; // Tiempo que tomará en crecer o disminuir

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el personaje recoge un círculo con el tag "punto1"
        if (collision.CompareTag("punto1"))
        {
            // Inicia la corrutina para hacer crecer o disminuir el suelo gradualmente
            StartCoroutine(GrowOrShrinkGroundCircle());

            // Destruye el círculo recolectable
            Destroy(collision.gameObject);
        }
    }

    private System.Collections.IEnumerator GrowOrShrinkGroundCircle()
    {
        // Determina aleatoriamente si el suelo debe aumentar o disminuir
        float randomFactor = Random.Range(minGrowthFactor, maxGrowthFactor);
        Vector3 initialScale = groundCircle.localScale; // Tamaño inicial del suelo
        Vector3 targetScale = initialScale * randomFactor; // Tamaño objetivo basado en el factor aleatorio
        float elapsedTime = 0f; // Tiempo transcurrido

        // Incrementar o decrecer el tamaño poco a poco durante "growthDuration"
        while (elapsedTime < growthDuration)
        {
            groundCircle.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / growthDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // Espera hasta el siguiente frame
        }

        // Asegurar que el tamaño final sea exactamente el objetivo
        groundCircle.localScale = targetScale;
    }
}


