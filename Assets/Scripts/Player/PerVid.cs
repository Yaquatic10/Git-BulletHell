using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerVid : MonoBehaviour
{
    public float atkM = 30;
    public float bull = 50;
    public float boss = 60;

    private SliVida sliVidaInstance;

    void Start()
    {
        
        sliVidaInstance = FindObjectOfType<SliVida>();

        if (sliVidaInstance == null)
        {
            Debug.LogError("No se encontró una instancia de SliVida.");
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (sliVidaInstance == null) return;

        
        if (collision.gameObject.tag == "Enemy")
        {
            sliVidaInstance.PerdidaV(atkM);
            collision.gameObject.SetActive(false);  
        }
        else if (collision.gameObject.tag == "Boss") 
        {
            sliVidaInstance.PerdidaV(boss);
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            sliVidaInstance.PerdidaV(bull);
            collision.gameObject.SetActive(false);  
        }
    }
}
