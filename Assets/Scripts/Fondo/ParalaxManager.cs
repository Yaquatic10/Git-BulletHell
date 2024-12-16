using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxManager : MonoBehaviour
{

    [SerializeField] private Transform paralaxPivot;

    [SerializeField] private float speedMultiplier;
    
    public static ParalaxManager Instance;
    
    public Transform GetParalaxPivot() => paralaxPivot;
    public float GetSpeedMultiplier() => speedMultiplier;
   
    
    private void Awake()
    {
       
            Instance = this;
      
    }
    
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
      speedMultiplier += .5f ;
    }
    
    
}

