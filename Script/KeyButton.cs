using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class KeyButton : MonoBehaviour
{
    // Keyboard keyboard;
    TextMeshProUGUI buttonText;
    public TextMeshProUGUI totalString;
    public GameObject canvasMainMenu;
    public GameObject canvasIP;
    public GameObject canvasCountdown;

    public static string ipInput;

    // Start is called before the first frame update
    void Start()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void InsertNum(){
        totalString.text += buttonText.text;
        Debug.Log("totalString: " + totalString.text);
    }
    public void DelButton(){
        if(totalString.text.Length > 0){
            totalString.text = totalString.text.Substring(0, totalString.text.Length - 1);
        }
    }
    public void Submit(){
        ipInput = totalString.text;
        Debug.Log(ipInput);
        SceneManager.LoadScene("00_MainMenu");
    }
}
