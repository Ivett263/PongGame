using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    private GameObject namePlayer1;

    private void Start()
    {
        namePlayer1 = GameObject.FindGameObjectWithTag("Player1");
        if (namePlayer1 != null)
        {
            namePlayer1.GetComponent<Text>().text = PlayerPrefs.GetString("Player1");
        }
        else
        {
            Debug.LogError("GameObject with tag 'Player1' not found!");
        }
        
    }
}
