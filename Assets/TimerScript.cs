using UnityEngine;
using TMPro;
public class TimerScript : MonoBehaviour
{
    public TMP_Text timerText;
    public bool isRunning= false;
    private float TimeElapsed=0;
    public GameObject Platform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
            isRunning = true;
    }
    public void StartTimer()
    {
        TimeElapsed = 0f;
        isRunning = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            TimeElapsed += Time.deltaTime;
            timerText.text = "Time: " + TimeElapsed.ToString("F2");
        }
    }
    public float returnTime()
    {
        return TimeElapsed;
    }
    public void StopTimer()
    {
        isRunning = false;
        
    }    
}
