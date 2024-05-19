using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioSource music;
    public BeatScroller beatScroller;

    private int currentTime = 0;
    private int playtime;
    public bool playMusic;
    private bool startPlaying;
    private GameObject lastNote;
    
    public int currentScore;
    public int scorePerNote = 1;
    public TMP_Text scoreText;

    public int countdown;
    private bool isCountdown;
    public GameObject countdownPanel;
    public TMP_Text countdownText;

    public bool MuMode;

    void Awake()
    {
        if (instance == null){
            instance = this;
        }
        else if(instance != null) {
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lastNote = GameObject.Find("30-C");
        StartCoroutine(CountdownToStart());
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = (int)Time.time;

        if(!startPlaying && !isCountdown){
            startPlaying = true;
            beatScroller.hasStarted = true;
            // playtime = currentTime + 1;
            if(playMusic){
                Debug.Log("A");
                music.Play();
            }
        }
        else if(lastNote == null){
            //Music Understanding
            if(MuMode && beatScroller.isPrac){
                SceneManager.LoadScene("01_MU_Done");
            }
            //Listening
            if(MuMode && beatScroller.isTest){
                SceneManager.LoadScene("03_MP0-2");
            }
            //Music Performance
            if(!MuMode && beatScroller.isPrac){
                SceneManager.LoadScene("03_MP1-2");
            }
            //Test  
            if(!MuMode && beatScroller.isTest){
                SceneManager.LoadScene("03_MP2-2");
            }    
        }
    }

    public void NoteHit(){
        currentScore += scorePerNote;
        scoreText.text = currentScore.ToString();
    }

    public void NoteWrong(){
        Debug.Log("Wrong Note");
    }

    IEnumerator CountdownToStart(){
        while(countdown > 0){
            isCountdown = true;
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;
        }
        countdownPanel.SetActive(false);
        isCountdown = false;
    }
}
