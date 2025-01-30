using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject puntosPrefab;      // Prefab del objeto que se va a generar
    public Transform[] spawnPoints;      // Array de puntos de spawn
    [SerializeField] float delayIniciar = 10f; // Retraso inicial antes de empezar
    [SerializeField] float intervalo = 20f; // Intervalo entre disparos
                                                  // Intervalo entre cada spawn (en segundos)
    private float tiempoTranscurrido = 0f; // Tiempo transcurrido para controlar el intervalo
    public float tiempoDesaparicion = 5f;  // Tiempo en segundos para que el objeto desaparezca

    private void Update()
    {
        // Aumentar el tiempo transcurrido
        tiempoTranscurrido = tiempoTranscurrido + Time.deltaTime;

        // Si ha pasado el intervalo, realizamos el spawn
        if (tiempoTranscurrido >= intervalo)
        {
            // Llamamos a la función de spawn
            Spawn();

            // Resetear el contador de tiempo
            tiempoTranscurrido = 0f;
        }
    }

    void Spawn()
    {
        // Asegurarse de que haya al menos un punto de spawn
        if (spawnPoints.Length > 0)
        {
            // Elegir un punto de spawn aleatorio
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomIndex];

            // Instanciar el objeto en ese punto de spawn
            GameObject objetoInstanciado = Instantiate(puntosPrefab, spawnPoint.position, spawnPoint.rotation);

            // Destruir el objeto después de 'tiempoDesaparicion' segundos
            Destroy(objetoInstanciado, tiempoDesaparicion);
        }
        else
        {
            Debug.LogWarning("No hay puntos de spawn asignados.");
        }
    }
}







