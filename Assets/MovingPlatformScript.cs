using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovingPlatformScript : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector3 Initialpos;
    public float movespeed;
    public float moveDistance = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialpos = transform.position;
    }
  
    // Update is called once per frame
    void Update()
    {
 

    }
    private void FixedUpdate()
    {
        float y = Initialpos.y + Mathf.Sin(Time.time * movespeed) * moveDistance;
        rb.MovePosition(new Vector2(rb.position.x,y));  
    }
}
