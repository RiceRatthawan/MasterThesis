using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float initialBeatTempo;
    public float beatTempo;
    public bool hasStarted;
    public bool isPrac;
    public bool isTest;

    void Start(){
        beatTempo = beatTempo / 60f;
        initialBeatTempo = beatTempo;
    }

    void Update(){
        if(!hasStarted){
            // if(Input.anyKeyDown){
            //     hasStarted = true;
            // }
        }else {
            // transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
            transform.position -= new Vector3(0f, 0f, beatTempo * Time.deltaTime);
        }
    }
}
