using TMPro;


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FinishLineScript : MonoBehaviour
{
    public CloudLeaderboard leaderboard;
    public Button Replay;
    public GameObject FinishLine;
    public TMP_Text LevelComplete;
    public TimerScript timerScript;
    public GameObject FinishLineScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        LevelComplete.text = "Level Complete";
        FinishLineScreen.SetActive(true);

        timerScript.StopTimer();
        leaderboard.SubmitScore(PlayerProfile.playerName, timerScript.returnTime());
        Time.timeScale = 0f;
    }
}

