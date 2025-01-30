using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; } // Singleton

    private AudioSource audioSource;
    private const string VolumeKey = "MusicVolume"; // Clave para guardar el volumen en PlayerPrefs

    // Asigna los clips de m�sica para cada escena en el Inspector
    public AudioClip musicMenu; // M�sica para la escena Menu
    public AudioClip musicSampleScene; // M�sica para la escena SampleScene
    public AudioClip musicSettings; // M�sica para la escena Settings
    public AudioClip secondMusicSampleScene; // Segunda canci�n para SampleScene
    public AudioClip Animacion_Inicio;
    public float timeToChangeSong = 5f;  // Tiempo en segundos antes de cambiar la canci�n en SampleScene

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

        // Comprobamos si el AudioSource est� presente desde el inicio
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("El AudioSource no est� asignado en el objeto MusicManager.");
        }

        // Suscribirse al evento de cambio de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        // Revisa si el AudioSource se inicializ� correctamente en Awake
        if (audioSource == null)
        {
            Debug.LogError("El componente AudioSource no se inicializ� correctamente en Start.");
            return;
        }

        // Carga el volumen guardado al iniciar
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f); // Volumen predeterminado: 1
        SetVolume(savedVolume);

        // Reproduce la m�sica de la escena actual al cargar el juego
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    // M�todo para ajustar el volumen de la m�sica
    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = Mathf.Clamp01(volume); // Aseg�rate de que el volumen est� entre 0 y 1
            PlayerPrefs.SetFloat(VolumeKey, volume);   // Guarda el volumen
            PlayerPrefs.Save();                        // Guarda los cambios en disco
        }
    }

    // M�todo para obtener el volumen actual
    public float GetVolume()
    {
        return audioSource != null ? audioSource.volume : 0f;
    }

    // M�todo para cambiar el clip de m�sica
    public void PlayMusic(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.clip = clip;  // Asigna el nuevo clip
            audioSource.Play();       // Reproduce la nueva m�sica
        }
        else
        {
            Debug.LogError("El componente AudioSource no est� asignado.");
        }
    }

    // M�todo para manejar el evento cuando se carga una nueva escena
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Comprobamos si audioSource est� asignado antes de cambiar la m�sica
        if (audioSource == null)
        {
            Debug.LogError("El componente AudioSource no est� asignado durante el OnSceneLoaded.");
            return;
        }

        // Cambiar m�sica seg�n el nombre de la escena
        switch (scene.name)
        {
            case "menu":
                if (musicMenu != null)
                {
                    PlayMusic(musicMenu); // M�sica para la escena Menu
                }
                else
                {
                    Debug.LogWarning("musicMenu no est� asignado en el Inspector.");
                }
                break;

            case "SampleScene":
                if (musicSampleScene != null)
                {
                    PlayMusic(musicSampleScene); // M�sica para la escena SampleScene
                    StartCoroutine(ChangeSongAfterDelay(timeToChangeSong)); // Iniciar el cambio de m�sica despu�s del tiempo
                }
                else
                {
                    Debug.LogWarning("musicSampleScene no est� asignado en el Inspector.");
                }
                break;

            case "Settings":
                if (musicSettings != null)
                {
                    PlayMusic(musicSettings); // M�sica para la escena Settings
                }
                else
                {
                    Debug.LogWarning("musicSettings no est� asignado en el Inspector.");
                }
                break;
            case "Animacion_Inicio":
                if (Animacion_Inicio != null) // Verifica si el clip de Animacion est� asignado
                {
                    PlayMusic(Animacion_Inicio); // Reproduce la m�sica asignada para la escena Animacion
                }
                else
                {
                    Debug.LogWarning("Animacion no est� asignado en el Inspector.");
                }
                break;


            default:
                // Si no hay m�sica espec�fica para la escena, detener el audio
                audioSource.Stop();
                break;
        }
    }

    // M�todo para cambiar la m�sica despu�s de un tiempo determinado
    private IEnumerator ChangeSongAfterDelay(float delay)
    {
        // Espera el tiempo definido antes de cambiar la canci�n
        yield return new WaitForSeconds(delay);

        // Cambiar a la segunda canci�n de SampleScene
        if (secondMusicSampleScene != null)
        {
            PlayMusic(secondMusicSampleScene);
        }
        else
        {
            Debug.LogWarning("secondMusicSampleScene no est� asignado en el Inspector.");
        }
    }
}

