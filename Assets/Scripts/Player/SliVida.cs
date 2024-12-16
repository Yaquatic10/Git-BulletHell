using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliVida : MonoBehaviour
{
    public Slider vida;                
    public float vidaMaxima = 100;     
    private float vidaActual;          
    public GameObject botonReinicio;   

    private void Start()
    {
        vida.maxValue = vidaMaxima;
        vidaActual = vidaMaxima;
        vida.value = vidaActual;

       
        if (botonReinicio != null)
        {
            botonReinicio.SetActive(false);
        }
    }

    public void PerdidaV(float dano1)
    {
        vidaActual -= dano1;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima); 
        vida.value = vidaActual;

        CheckVi(); 
    }

    
    public void RecuperarVida(float cantidad)
    {
        vidaActual += cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima); 
        vida.value = vidaActual;
        Debug.Log("Vida recuperada: " + cantidad + ". Vida actual: " + vidaActual);
    }

    public void CheckVi()
    {
        if (vidaActual <= 0)
        {
            Time.timeScale = 0f; 
            MostrarBotonReinicio(); 
        }
    }

    
    private void MostrarBotonReinicio()
    {
        if (botonReinicio != null)
        {
            botonReinicio.SetActive(true); 
        }
    }

    
    public void ReiniciarJuego()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
