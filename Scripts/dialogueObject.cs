using UnityEngine;
[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]

public class dialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;

    public string[] Dialogue => dialogue;
}
