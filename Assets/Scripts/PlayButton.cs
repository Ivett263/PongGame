using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public InputField inputText;
    public void SavePlayerName()
    {
        string playerName = string.IsNullOrEmpty(inputText.text) ? "Player 1" : inputText.text;
        PlayerPrefs.SetString("Player1", playerName);
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
