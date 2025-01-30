using TMPro;
using UnityEngine;

public class contador : MonoBehaviour
{
    [SerializeField] TMP_Text textUI;
    [SerializeField] float currentValue = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Opcional: inicializa el texto en la UI
        textUI.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        currentValue += Time.deltaTime; // Incrementa el tiempo
        int integerValue = Mathf.FloorToInt(currentValue); // Convierte a entero truncando decimales
        textUI.text = integerValue.ToString(); // Asigna el número entero al texto
    }
}
