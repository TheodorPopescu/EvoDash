using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour
{
    public static string playerName;
    public TMP_InputField nameInputField;
    public Button button;
    public GameObject startingScreen;

    private PlayerScript playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj)
            playerScript = playerObj.GetComponent<PlayerScript>();
        if (PlayerPrefs.HasKey("SavedPlayerName"))
        {
            playerName = PlayerPrefs.GetString("SavedPlayerName");
            Time.timeScale = 1f;
            startingScreen.SetActive(false);
            if (playerScript != null) playerScript.enabled = true;
        }
        else
        {
          
            Time.timeScale = 0f;
            playerScript.enabled = false;
            startingScreen.SetActive(true);

        }

    }
    
    public void SaveNameAndStart()
    {
        if (!string.IsNullOrEmpty(nameInputField.text))
        {

            playerName = nameInputField.text;
            PlayerPrefs.SetString("SavedPlayerName", playerName);
            PlayerPrefs.Save();

            Time.timeScale = 1f;
            playerScript.enabled = true;
            startingScreen.SetActive(false);
        }
        else
            Debug.Log("Please insert a name");
                }   
    public void StartGame()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
