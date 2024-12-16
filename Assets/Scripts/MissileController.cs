using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float missileSpeed = 25f;  
    public float damage = 50f;        
    public float vidaRecuperada = 25f; 

    private SliVida playerHealth; 

    void Start()
    {
        
        playerHealth = FindObjectOfType<SliVida>();
        if (playerHealth == null)
        {
            Debug.LogError("No se encontró el componente SliVida.");
        }
    }

    void Update()
    {
       
        transform.Translate(Vector3.up * missileSpeed * Time.deltaTime);

        
        if (!IsVisible())
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            
            EnemyS enemy = other.GetComponent<EnemyS>();
            if (enemy != null)
            {
                enemy.danoEP(damage); 
                playerHealth?.RecuperarVida(vidaRecuperada); 
                Destroy(this.gameObject); 
            }
        }

        
        if (other.CompareTag("Boss"))
        {
            
            FinalBoss boss = other.GetComponent<FinalBoss>();
            if (boss != null)
            {
                boss.danoBoss(damage); 
                playerHealth?.RecuperarVida(vidaRecuperada); 
                Destroy(this.gameObject); 
            }
        }
    }

  
    private bool IsVisible()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }
}
