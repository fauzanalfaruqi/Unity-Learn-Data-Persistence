using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public string username;
    public int userBestScore;
    public bool isLoggedIn = false;
    public static DataManager Instance;
    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        CheckPlayerPrefs();
    }

    void CheckPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Username"))
        {
            isLoggedIn = true;
            username = PlayerPrefs.GetString("Username");
            userBestScore = PlayerPrefs.GetInt("UserBestScore", 0);
        }
        else
        {
            isLoggedIn = false;
        }
    }

    public void UpdateBestScore(int newScore)
    {
        userBestScore = newScore;
        PlayerPrefs.SetInt("UserBestScore", newScore);
        PlayerPrefs.Save();
    }
}
