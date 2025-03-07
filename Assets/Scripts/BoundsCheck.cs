﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// keeps a game object on screen when using ortographic cameras at 0,0,0
/// </summary>
public class BoundsCheck : MonoBehaviour
{
    [Header("Set in inspector")]
    public float radius = -1f;
    public bool keepOnScreen = true;

    [Header("Set dynamically")]
    public bool isOnScreen = true;
    public float camWidth;
    public float camHeight;

    [HideInInspector]
    public bool offRight, offLeft, offUp, offDown;

    private void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        isOnScreen = true;
        offRight = offLeft = offUp = offDown = false;

        
        if (gameObject.CompareTag("Player"))
        {
            if (pos.x > camWidth - radius)
            {
                pos.x = camWidth - radius;
                offRight = true;
            }
            if (pos.x < -camWidth + radius)
            {
                pos.x = -camWidth + radius;
                offLeft = true;
            }
            if (pos.y > camHeight - radius)
            {
                pos.y = camHeight - radius;
                offUp = true;
            }
            if (pos.y < -camHeight + radius)
            {
                pos.y = -camHeight + radius;
                offDown = true;
            }
        }

        isOnScreen = !(offDown || offLeft || offRight || offUp);

        
        if (gameObject.CompareTag("Player") && keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
            offRight = offLeft = offUp = offDown = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
