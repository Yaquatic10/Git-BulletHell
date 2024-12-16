using UnityEngine;

public class PlayerBounds2D : MonoBehaviour
{
    private float camWidth;
    private float camHeight;
    private float playerWidth;
    private float playerHeight;

    void Start()
    {
        
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;

        
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            playerWidth = sr.bounds.size.x / 2;  
            playerHeight = sr.bounds.size.y / 2; 
        }
    }

    void Update()
    {
        
        Vector3 pos = transform.position;

        
        pos.x = Mathf.Clamp(pos.x, -camWidth + playerWidth, camWidth - playerWidth);

       
        pos.y = Mathf.Clamp(pos.y, -camHeight + playerHeight, camHeight - playerHeight);

       
        transform.position = pos;
    }
}
