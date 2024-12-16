using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellSpawner : MonoBehaviour
{
  
    public int columns;
    public float speed;
    public Sprite texture;
    public Color color;
    public float lifetime;
    public float firerate;
    public float size;
    private float angle;
    public Material material;
    public float spinspeed;
    private float time;

    public ParticleSystem system;


    public void Awake()
    {
        Summon();
    }

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        transform.rotation = Quaternion.Euler(0, 0, time * spinspeed);
    }

    void Summon()
    {
        angle = 360f / columns;
        for (int i = 0; i < columns; i++)
        
        {
            Material particleMaterial = material;

            
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle * i, 90, 0); 
            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;
            mainModule.startSpeed = speed;
            mainModule.maxParticles = 10000;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;



            var emission = system.emission;
            emission.enabled = false;

            var forma = system.shape;
            forma.enabled = true;
            forma.shapeType = ParticleSystemShapeType.Sprite;
            forma.sprite = null;

            
            var text = system.textureSheetAnimation;
            text.enabled = true;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.AddSprite (texture);

            
        }
                
        InvokeRepeating("DoEmit", 0f , firerate );
    }

    void DoEmit()
    {
        foreach(Transform child in transform)
        { 
        system = child.GetComponent<ParticleSystem>();
        
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.startColor = color;
        emitParams.startSize = size;
        emitParams.startLifetime = lifetime;
        system.Emit(emitParams, 10);
        }
    }
}