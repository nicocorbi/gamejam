using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vidaaa : MonoBehaviour
{
    public Image barraDevida;
    [SerializeField] public float vidaActual;
    [SerializeField] public float vidaMaxima;
    // Start is called before the first frame update
    void Start()
    {
        vidaMaxima = 180f;
        vidaActual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        vidaActual = vidaActual - Time.deltaTime;
        barraDevida.fillAmount = vidaActual / vidaMaxima;
        if (vidaActual <= 0)
        {
            SceneManager.LoadScene("Victoria");
        }
    }
        
}
