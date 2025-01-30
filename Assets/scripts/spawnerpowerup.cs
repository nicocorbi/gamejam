using UnityEngine;

public class spawnerpowerup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject puntosPrefab;      // Prefab del objeto que se va a generar
    public Transform spawnPoints;      // Array de puntos de spawn
    public float intervalo = 10f;         // Intervalo entre cada spawn
    private float tiempoTranscurrido = 0f; // Tiempo transcurrido para controlar el intervalo
    public float tiempoDesaparicion = 5f;  // Tiempo en segundos para que el objeto desaparezca

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Aumentar el tiempo transcurrido
        tiempoTranscurrido += Time.deltaTime;

        // Si ha pasado el intervalo, realizamos el spawn
        if (tiempoTranscurrido >= intervalo)
        {
            // Llamamos a la funci�n de spawn
            Spawn();

            // Resetear el contador de tiempo
            tiempoTranscurrido = 0f;
        }
    }
    void Spawn()
    {

        // Instanciar el objeto en ese punto de spawn
        GameObject objetoInstanciado = Instantiate(puntosPrefab, spawnPoints.position, Quaternion.identity);

        // Destruir el objeto despu�s de 'tiempoDesaparicion' segundos
        Destroy(objetoInstanciado, tiempoDesaparicion);

    }
}