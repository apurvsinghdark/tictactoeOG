using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button button;
    public Text buttonText;
    public string playerString;
    //private ga

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();
    }
    
    public void SetSpace()
    {
        buttonText.text = GameControl.instance.GetPlayerSide();
        button.interactable = false;
        GameControl.instance.EndTurn();
    }

}
