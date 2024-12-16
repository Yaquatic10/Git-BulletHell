using UnityEngine;

public class EnemyS : MonoBehaviour
{
    private EnemyController enemyController;

    private Transform mediumPoint;
    private Transform finalPoint;
    private Transform firstPoint;

    [SerializeField] float speed;
    [SerializeField] int pointsammount;
    [SerializeField] bool isSpecialShip;

    public float vidaAcual = 100f;
    public float vidaMinima = 0f;



    public void danoEP(float putasos)
    {
        vidaAcual -= putasos;
        Debug.Log("Daño recibido: " + putasos + ". Vida actual: " + vidaAcual);
        vidaAcual = Mathf.Max(vidaAcual, vidaMinima); 
        CheckEP();
    }

    public void CheckEP()
    {
        if (vidaAcual <= vidaMinima)
        {
            DisableShip();
        }
    }


    private void Awake()
    {
        enemyController = GameObject.FindObjectOfType<EnemyController>();
    }

    private void OnEnable()
    {
        SetRoute();
        transform.position = firstPoint.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, finalPoint.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, finalPoint.position) < 0.1f)
        {
            DisableShip(); 
        }
    }

    private void SetRoute()
    {
        for (int i = -1; i < pointsammount; i++)
        {
            switch (i)
            {
                case 0:
                    firstPoint = enemyController.SetWayPoint(i);
                    break;
                case 1:
                    finalPoint = enemyController.SetWayPoint(i);
                    break;
                case 2:
                    mediumPoint = enemyController.SetWayPoint(i);
                    break;

            }
        }
    }

    private void DisableShip()
    {
        this.gameObject.SetActive(false);
    }
}