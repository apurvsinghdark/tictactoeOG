using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance; 
    public List<Text> buttonList = new List<Text>();
    
    public GameObject gameOverPanel;
    public Text gameOverText;

    private string playerSide;

    private int moveCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        gameOverPanel.SetActive(false);
        moveCount = 0;
    }
    private void Start()
    {
        //gameOverPanel = GameObject.Find("GameOver");
        //gameOverText = GameObject.Find("GameOverText");

        playerSide = "X";

        var button =  FindObjectsOfType<Text>();
        
        for(int i = button.Length - 1; i>=0; i--)
        {
            buttonList.Add(button[i]);
        }   
    }
    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }
    public string GetPlayerSide()
    {
        return playerSide;
    }
    public void EndTurn()
    {
        moveCount++;
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }

        if (moveCount >= 9)
        {
            SetGameOverText("It's a draw!");
        }

        ChangeSides();
    }
    void GameOver()
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
        SetGameOverText(playerSide + " Wins!");
    }

    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }
}
