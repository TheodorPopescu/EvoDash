using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class CloudLeaderboard : MonoBehaviour
{

    public string serverURL = "https://my-leaderboard-yj8n.onrender.com";
    public class ScoreData
    {
        public string playerName;
        public float score;
    }

    public void SubmitScore(string name, float time)
    {
        StartCoroutine(PostScore(name, time));
    }
    private IEnumerator PostScore(string name, float time)
    {
        ScoreData data= new ScoreData();
        data.playerName = name;
        data.score = time;

        string json= JsonUtility.ToJson(data);

        UnityWebRequest request = new UnityWebRequest(serverURL + "/api/add-score", "POST");
        byte[] bodyRaw= Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("ERROR SENDING SCORE: " + request.error);
        }
        else
            Debug.Log("SUCCESFULLY SENT CODE! Server response : " + request.downloadHandler.text);

        request.Dispose(); 
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
