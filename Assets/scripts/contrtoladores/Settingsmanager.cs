using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider; // Asigna el Slider desde el Inspector

    private void Start()
    {
        // Obtiene el volumen actual desde el MusicManager
        if (MusicManager.Instance != null)
        {
            float currentVolume = MusicManager.Instance.GetVolume();
            volumeSlider.value = currentVolume; // Sincroniza el Slider con el volumen actual
        }

        // Agrega un listener para actualizar el volumen al mover el Slider
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    private void UpdateVolume(float volume)
    {
        // Actualiza el volumen en el MusicManager
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.SetVolume(volume);
        }
    }
}