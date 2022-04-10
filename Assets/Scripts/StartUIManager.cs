using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class StartUIManager : MonoBehaviour
{
    [SerializeField] TMP_InputField usernameInput;
    [SerializeField] Button startButton;
    [SerializeField] TextMeshProUGUI welcomeMessage, scoreMessage, startText;

    [Space]
    [SerializeField] UnityEvent startButtonEvent, loginButtonEvent;

    void Start()
    {
        var dm = DataManager.Instance;

        if (dm.isLoggedIn)
        {
            welcomeMessage.gameObject.SetActive(true);
            welcomeMessage.text = $"Hi, {dm.username}";
            scoreMessage.text = $"Your Best Score : {dm.userBestScore}";
            
            startText.text = "Start Game";
            startButton.onClick.AddListener(startButtonEvent.Invoke);

            usernameInput.gameObject.SetActive(false);
        }
        else
        {
            welcomeMessage.gameObject.SetActive(false);

            startText.text = "Login";
            startButton.onClick.AddListener(loginButtonEvent.Invoke);
        }
    }

    public void SetUsernameData()
    {
        var dm = DataManager.Instance;

        dm.username = usernameInput.text;
        PlayerPrefs.SetString("Username", usernameInput.text);
        PlayerPrefs.Save();

        startText.text = "Start Game";
        startButton.onClick.AddListener(startButtonEvent.Invoke);

        welcomeMessage.gameObject.SetActive(true);
        welcomeMessage.text = $"Hi, {dm.username}";
        scoreMessage.text = $"Your Best Score : {dm.userBestScore}";

        usernameInput.gameObject.SetActive(false);
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("main");
    }
}
