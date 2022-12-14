using UnityEngine;

public class dialogueActivator : MonoBehaviour, interactable
{
    [SerializeField] private dialogueObject DialogueObject;

    public void UpdateDialogueObject(dialogueObject DialogueObject){
        this.DialogueObject = DialogueObject;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerScript player)){
            player.interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Player") && other.TryGetComponent(out PlayerScript player)){
            if (player.interactable is dialogueActivator DialogueActivator && DialogueActivator == this){
                player.interactable = null;
            }
        }
    }

    public void Interact(PlayerScript player){
        if (TryGetComponent(out DialogueResponseEvents responseEvents) && responseEvents.dialogueObject == DialogueObject){
            player.DialogueUI.AddResponseEvents(responseEvents.Events);
        }
        player.DialogueUI.ShowDialogue(DialogueObject);
    }
}
