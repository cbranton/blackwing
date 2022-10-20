using UnityEngine;
using System;

public class DialogueResponseEvents : MonoBehaviour
{
    [SerializeField] private dialogueObject DialogueObject;
    [SerializeField] private ResponseEvent[] events;

    public ResponseEvent[] Events => events;

    public void OnValidate(){
        if(DialogueObject == null) return;
        if(DialogueObject.Responses == null) return;
        if(events!=null && events.Length == DialogueObject.Responses.Length) return;

        if(events== null){
            events = new ResponseEvent[DialogueObject.Responses.Length];
        }
        else{
            Array.Resize(ref events, DialogueObject.Responses.Length);
        }

        for(int i = 0; i < DialogueObject.Responses.Length; i++){
            response Response = DialogueObject.Responses[i];

            if(events[i]!= null){
                events[i].name = Response.ResponseText;
            }
            events[i] = new ResponseEvent(){name = Response.ResponseText};
        }
    }
}
