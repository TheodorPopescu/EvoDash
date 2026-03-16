using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public PlayerScript Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.UpdateCheckpoint(transform.position);
    }
}
