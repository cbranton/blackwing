using System.Collections;
using UnityEngine;
using TMPro;

public class dialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private dialogueObject testDialogue;
    [SerializeField] private GameObject dialogueBox;

    private typewriterEffect TypewriterEffect;

    private void Start(){
        TypewriterEffect = GetComponent<typewriterEffect>();
        CloseDialogueBox();
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(dialogueObject DialogueObject){
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(DialogueObject));
    }

    private IEnumerator StepThroughDialogue(dialogueObject DialogueObject){
        yield return new WaitForSeconds(1);

        foreach (string dialogue in DialogueObject.Dialogue){
            yield return TypewriterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        }

        CloseDialogueBox();
    }

    private void CloseDialogueBox(){
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }

}
