using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]

public class dialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] private response[] responses;

    public string[] Dialogue => dialogue;

    public bool HasResponses => Responses != null && Responses.Length > 0;

    public response[] Responses => responses;
}
