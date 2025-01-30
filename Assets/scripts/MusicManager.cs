using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; } // Singleton

    private AudioSource audioSource;
    private const string VolumeKey = "MusicVolume"; // Clave para guardar el volumen en PlayerPrefs

    // Asigna los clips de música para cada escena en el Inspector
    public AudioClip musicMenu; // Música para la escena Menu
    public AudioClip musicSampleScene; // Música para la escena SampleScene
    public AudioClip musicSettings; // Música para la escena Settings
    public AudioClip secondMusicSampleScene; // Segunda canción para SampleScene
    public AudioClip Animacion_Inicio;
    public float timeToChangeSong = 5f;  // Tiempo en segundos antes de cambiar la canción en SampleScene

    void Awake()
    {
        // Configura el Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Hace que este objeto persista entre escenas
        }
        else
        {
            Destroy(gameObject); // Elimina la instancia duplicada
            return;
        }

        // Comprobamos si el AudioSource está presente desde el inicio
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("El AudioSource no está asignado en el objeto MusicManager.");
        }

        // Suscribirse al evento de cambio de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        // Revisa si el AudioSource se inicializó correctamente en Awake
        if (audioSource == null)
        {
            Debug.LogError("El componente AudioSource no se inicializó correctamente en Start.");
            return;
        }

        // Carga el volumen guardado al iniciar
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f); // Volumen predeterminado: 1
        SetVolume(savedVolume);

        // Reproduce la música de la escena actual al cargar el juego
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    // Método para ajustar el volumen de la música
    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = Mathf.Clamp01(volume); // Asegúrate de que el volumen esté entre 0 y 1
            PlayerPrefs.SetFloat(VolumeKey, volume);   // Guarda el volumen
            PlayerPrefs.Save();                        // Guarda los cambios en disco
        }
    }

    // Método para obtener el volumen actual
    public float GetVolume()
    {
        return audioSource != null ? audioSource.volume : 0f;
    }

    // Método para cambiar el clip de música
    public void PlayMusic(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.clip = clip;  // Asigna el nuevo clip
            audioSource.Play();       // Reproduce la nueva música
        }
        else
        {
            Debug.LogError("El componente AudioSource no está asignado.");
        }
    }

    // Método para manejar el evento cuando se carga una nueva escena
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Comprobamos si audioSource está asignado antes de cambiar la música
        if (audioSource == null)
        {
            Debug.LogError("El componente AudioSource no está asignado durante el OnSceneLoaded.");
            return;
        }

        // Cambiar música según el nombre de la escena
        switch (scene.name)
        {
            case "menu":
                if (musicMenu != null)
                {
                    PlayMusic(musicMenu); // Música para la escena Menu
                }
                else
                {
                    Debug.LogWarning("musicMenu no está asignado en el Inspector.");
                }
                break;

            case "SampleScene":
                if (musicSampleScene != null)
                {
                    PlayMusic(musicSampleScene); // Música para la escena SampleScene
                    StartCoroutine(ChangeSongAfterDelay(timeToChangeSong)); // Iniciar el cambio de música después del tiempo
                }
                else
                {
                    Debug.LogWarning("musicSampleScene no está asignado en el Inspector.");
                }
                break;

            case "Settings":
                if (musicSettings != null)
                {
                    PlayMusic(musicSettings); // Música para la escena Settings
                }
                else
                {
                    Debug.LogWarning("musicSettings no está asignado en el Inspector.");
                }
                break;
            case "Animacion_Inicio":
                if (Animacion_Inicio != null) // Verifica si el clip de Animacion está asignado
                {
                    PlayMusic(Animacion_Inicio); // Reproduce la música asignada para la escena Animacion
                }
                else
                {
                    Debug.LogWarning("Animacion no está asignado en el Inspector.");
                }
                break;


            default:
                // Si no hay música específica para la escena, detener el audio
                audioSource.Stop();
                break;
        }
    }

    // Método para cambiar la música después de un tiempo determinado
    private IEnumerator ChangeSongAfterDelay(float delay)
    {
        // Espera el tiempo definido antes de cambiar la canción
        yield return new WaitForSeconds(delay);

        // Cambiar a la segunda canción de SampleScene
        if (secondMusicSampleScene != null)
        {
            PlayMusic(secondMusicSampleScene);
        }
        else
        {
            Debug.LogWarning("secondMusicSampleScene no está asignado en el Inspector.");
        }
    }
}

