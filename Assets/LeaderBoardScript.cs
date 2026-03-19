using UnityEngine.Networking;
using UnityEngine;
using TMPro;
using System.Collections;

public class LeaderBoardScript : MonoBehaviour
{
    public string serverURL = "https://my-leaderboard-yj8n.onrender.com";
    public TMP_Text leaderboardText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [System.Serializable]
    public class ScoreData
    {
        public float timeInSeconds  = 0;
        public string playerName;
    }

    [System.Serializable]
    public class ScoreList
    {
        public ScoreData[] scores;
    }
    
    public void getLeaderBoard()
    {
        gameObject.SetActive(true);
        leaderboardText.text = "Loading global leaderboard";
        StartCoroutine(GetTopScores());
    }
    public void exitLeaderBoard()
    {
        gameObject.SetActive (false);
    }
    private IEnumerator GetTopScores()
    {
        UnityWebRequest request = UnityWebRequest.Get(serverURL + "/api/top-scores");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            leaderboardText.text = "Failed to connect to cloud";
            Debug.Log("Error loading results");
        }
        else
        {
            leaderboardText.text = "GLOBAL TOP 10\n";
            string jsonresponse = "{\"scores\":" + request.downloadHandler.text + "}";

            ScoreList fetchScores= JsonUtility.FromJson<ScoreList>(jsonresponse);

            for (int i = 0; i < fetchScores.scores.Length; i++)
            {
                ScoreData score = fetchScores.scores[i];

                leaderboardText.text += "\n " + (i + 1) + " -- " + score.playerName + " - " + score.timeInSeconds.ToString("F2") + "s\n";
            }


        }
        request.Dispose();

    }
    
    
    
    
    
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
