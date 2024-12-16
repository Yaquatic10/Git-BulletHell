using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    
    private EnemyController enemyController;
    
    public Transform bossPosition;
    private bool startAttack;
    public float bossSpeed;

    private Transform[] points;
    private int currentPoint;
    
    
    public float vidaAcual = 500f;
    public float vidaMinima = 0f;

    
    public void danoBoss(float putasos)
    {
        vidaAcual -= putasos;
        Debug.Log("Daño recibido: " + putasos + ". Vida actual: " + vidaAcual);
        vidaAcual = Mathf.Max(vidaAcual, vidaMinima);
        CheckBoss();
    }

    public void CheckBoss()
    {
        if (vidaAcual <= vidaMinima)
        {
            DisableShip();
        }
    }
    
    private void Awake()
    {
        enemyController = EnemyController.instance;
        
        List<Transform> allWayPoints = new List<Transform>();
        allWayPoints.AddRange(enemyController.firstWayPoints);
        allWayPoints.AddRange(enemyController.secondWayPoints);
        allWayPoints.AddRange(enemyController.finalWayPoints);
        points = allWayPoints.ToArray();
        currentPoint = 0;
    }


    private void Update()
    {
        if (startAttack == false)
        {
            MoveToNextPoint();
        }
    }

    private void MoveToNextPoint()
    {
        
        if (Vector2.Distance(transform.position, points[currentPoint].position) < 0.2f)
        {
            
            currentPoint = Random.Range(0, points.Length);
        }

        
        Vector2 direction = (points[currentPoint].position - transform.position).normalized;

        
        transform.position = Vector2.MoveTowards(transform.position, points[currentPoint].position, bossSpeed * Time.deltaTime);
    }

    private void DisableShip()
    {
        this.gameObject.SetActive(false);
    }
    
}