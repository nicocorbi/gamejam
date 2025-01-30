using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider; // Asigna el slider desde el inspector
    public MusicManager musicManager; // Asigna el MusicManager desde el inspector

    void Start()
    {
        if (volumeSlider != null && musicManager != null)
        {
            // Carga el volumen guardado
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
            volumeSlider.value = savedVolume;

            // Añade un listener para detectar cambios en el slider
            volumeSlider.onValueChanged.AddListener((value) =>
            {
                musicManager.SetVolume(value); // Ajusta el volumen de la música
            });
        }
    }
}