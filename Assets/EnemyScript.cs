using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector3 Initialpos;
    public float movespeed;
    public float moveDistance = 8f;
    public PlayerScript Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialpos = transform.position;
       Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float newX = Initialpos.x - Mathf.PingPong(Time.time * movespeed, moveDistance);
        transform.position = new Vector3(newX, Initialpos.y, Initialpos.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player.Respawn();
    }
}
