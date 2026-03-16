using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;
 
    public float movespeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
             if (Player.transform.position.x> transform.position.x + 2)
        {
            transform.position = new Vector3(Player.transform.position.x-2, transform.position.y, transform.position.z);
        }
             if(Player.transform.position.x < transform.position.x - 2)
        {
            transform.position = new Vector3(Player.transform.position.x + 2, transform.position.y, transform.position.z);
        }
             if (Player.transform.position.y > transform.position.y)

        {
           transform.position= new Vector3(transform.position.x, Player.transform.position.y,transform.position.z);
        }
             if(Player.transform.position.y < transform.position.y -2.75f)
        {
            transform.position = new Vector3(transform.position.x, Player.transform.position.y+2.75f, transform.position.z);
        }
    }
}
