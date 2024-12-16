using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private float paralaxSpeed;
    
    
    void Update()
    {
    float yPosition = transform.position.y;
    if (yPosition > ParalaxManager.Instance.GetParalaxPivot().position.y )
    {
        transform.position = new Vector3(transform.position.x, yPosition - paralaxSpeed * ParalaxManager.Instance.GetSpeedMultiplier()* Time.deltaTime, transform.position.z);
        
        
    }
    else
    {
        transform.position =new Vector3(transform.position.x, transform.position.y +(62f *2), transform.position.z);
    }
        
        
        
    }
}