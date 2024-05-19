using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoScript : MonoBehaviour
{
    private VideoPlayer player;
    public GameObject BtnPlay;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.loopPointReached += EndReached;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VideoStartBtn(){
        if(player.isPlaying == false){
            player.Play();
            BtnPlay.SetActive(false);
        }else{
            BtnPlay.SetActive(true);
        }
    }

    public void EndReached(VideoPlayer vp){
        BtnPlay.SetActive(true);
    }
}
