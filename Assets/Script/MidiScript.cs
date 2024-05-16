using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MidiScript : MonoBehaviour
{
    public int noteNum;
    public bool press;

    // Start is called before the first frame update
    void Start()
    {
        
        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;
            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            midiDevice.onWillNoteOn += (note, velocity) => {
                press = true;
                noteNum = note.noteNumber;
                // Debug.Log(string.Format(
                //     "Note On #{0} ({1}) vel:{2:0.00} ch:{3} dev:'{4}'",
                //     note.noteNumber,
                //     note.noteNumber.GetType(),
                //     note.shortDisplayName,
                //     velocity,
                //     velocity.GetType(),
                //     (note.device as Minis.MidiDevice)?.channel,
                //     note.device.description.product
                // ));
                Debug.Log(noteNum);
            };
            
            midiDevice.onWillNoteOff += (note) => {
                press = false;
                // Debug.Log(string.Format(
                //     "Note Off #{0} ({1}) ch:{2} dev:'{3}'",
                //     note.noteNumber,
                //     note.shortDisplayName,
                //     (note.device as Minis.MidiDevice)?.channel,
                //     note.device.description.product
                // ));
                 Debug.Log(noteNum+" off");
            };
        };
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}