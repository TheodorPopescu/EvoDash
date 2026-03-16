using UnityEngine;

public class Checkp2 : MonoBehaviour
{
    public PlayerScript Player;
    void Start()
    {
       Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.UpdateCheckpoint(transform.position);
    }
}
