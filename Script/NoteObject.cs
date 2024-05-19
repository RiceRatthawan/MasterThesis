using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    private GameManager gameManager;
    BeatScroller beatScroller;
    // private MidiScript midiScript;
    private Client clientReceive;
    private Renderer renderNoteColor;
    
    // private int noteBarNum;
    private string noteBarNum;
    public bool canBePressed;
    private bool onStay;
    MeshRenderer mr;
    Color originalColor;

    void Awake(){
        beatScroller = GameObject.Find("NoteHolder").GetComponent<BeatScroller>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // midiScript = GameObject.Find("MidiManager").GetComponent<MidiScript>();
        clientReceive = GameObject.Find("client").GetComponent<Client>(); 
        gameManager = GameManager.instance;
        renderNoteColor = GetComponent<Renderer>();
        // noteBarNum = int.Parse(gameObject.tag);
        noteBarNum = gameObject.tag;
        mr = GetComponent<MeshRenderer>();
        originalColor = gameObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        // if(canBePressed){
        //     if(beatScroller.isPrac){            
        //         if(midiScript.noteNum == noteBarNum && midiScript.press == true){
        //             mr.material.EnableKeyword("_EMISSION");
        //             beatScroller.beatTempo = beatScroller.initialBeatTempo;
                    
        //         }
        //     } else if(beatScroller.isTest) {
        //         if(midiScript.press == true && onStay){
        //             //press correct
        //             if(midiScript.noteNum == noteBarNum){
        //                 gameManager.NoteHit();
        //                 mr.material.EnableKeyword("_EMISSION");
        //             }
        //             //press wrong
        //             else if(midiScript.noteNum != noteBarNum){
        //                 gameManager.NoteMissed();
        //                 renderNoteColor.material.color = Color.grey;
        //             }
        //         }
        //     }   
        // }
        if(canBePressed){
            if(beatScroller.isPrac){   
                //haven't press
                if(clientReceive.noteNum == "OFF"){
                    renderNoteColor.material.color = originalColor;
                }
                //press real key and correct        
                if(clientReceive.noteNum == noteBarNum && clientReceive.noteNum != "OFF"){
                    renderNoteColor.material.color = Color.green;
                    beatScroller.beatTempo = beatScroller.initialBeatTempo;
                }
                //press real key and incorrect  
                if(clientReceive.noteNum != noteBarNum && clientReceive.noteNum != "OFF"){
                    renderNoteColor.material.color = Color.red;
                }
            } else if(beatScroller.isTest) {
                //not press
                if(clientReceive.noteNum == "OFF" && onStay){
                    renderNoteColor.material.color = originalColor;
                }
                //press correct
                if(clientReceive.noteNum == noteBarNum && clientReceive.noteNum != "OFF" && onStay){
                    gameManager.NoteHit();
                    renderNoteColor.material.color = Color.green;
                }
                //press wrong
                if(clientReceive.noteNum != noteBarNum && clientReceive.noteNum != "OFF" && onStay){
                    gameManager.NoteWrong();
                    renderNoteColor.material.color = Color.red;
                }
            }  
        }
    }

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("piano")){
            if(beatScroller.isPrac){
                beatScroller.beatTempo = 0f;
            }else{
                beatScroller.beatTempo = beatScroller.initialBeatTempo;
            }
            canBePressed = true;   
        }
    }
    public void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("piano")){
            onStay = true;
        }
    }
    public void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("piano")){
            canBePressed = false;
            onStay = false;
            Destroy(gameObject);
        }
    }
}
