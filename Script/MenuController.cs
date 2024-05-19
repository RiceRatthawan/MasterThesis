using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject T1, T2, T3;

    void Update()
    {
        
    }

    //ChangeScene
    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
    public void LoadSceneIndex(int index){
        SceneManager.LoadScene(index);
    }

    //ChangePageInTutorial
    public void TutorialP1(){
        T1.SetActive(true);
        T2.SetActive(false);
        T3.SetActive(false);
    }
    public void TutorialP2(){
        T1.SetActive(false);
        T2.SetActive(true);
        T3.SetActive(false);
    }
    public void TutorialP3(){
        T1.SetActive(false);
        T2.SetActive(false);
        T3.SetActive(true);
    }

    public void QuitApp(){
        Application.Quit();
    }
}
