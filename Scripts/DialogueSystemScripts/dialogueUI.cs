using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private dialogueObject testDialogue;
    [SerializeField] private GameObject dialogueBox;

    public bool isOpen { get; private set; }

    private responseHandler ResponseHandler;
    private typewriterEffect TypewriterEffect;

    private void Start(){
        TypewriterEffect = GetComponent<typewriterEffect>();
        ResponseHandler = GetComponent<responseHandler>();

        CloseDialogueBox();
    }

    public void ShowDialogue(dialogueObject DialogueObject){
        isOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(DialogueObject));
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents){
        ResponseHandler.AddResponseEvents(responseEvents);
    }

    private IEnumerator StepThroughDialogue(dialogueObject DialogueObject){
        yield return new WaitForSeconds(1);

        for(int i = 0; i < DialogueObject.Dialogue.Length; i++){
            string dialogue = DialogueObject.Dialogue[i];
            yield return RunTypingEffect(dialogue);

            textLabel.text = dialogue;

            if (i == DialogueObject.Dialogue.Length - 1 && DialogueObject.HasResponses) break;
            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        }
        if(DialogueObject.HasResponses){
            ResponseHandler.ShowResponses(DialogueObject.Responses);
        }
        else{
            CloseDialogueBox();
        }
    }

    private IEnumerator RunTypingEffect(string dialogue){
        TypewriterEffect.Run(dialogue, textLabel);
        while(TypewriterEffect.IsRunning){
            yield return null;

            if(Input.GetKeyDown(KeyCode.RightShift)||Input.GetKeyDown(KeyCode.LeftShift)){
                TypewriterEffect.Stop();
            }
        }
    }

    public void CloseDialogueBox(){
        isOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }

}
