using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class response
{
    [SerializeField] private string responseText;
    [SerializeField] private dialogueObject DialogueObject;

    public string ResponseText => responseText;

    public dialogueObject dialogueObject => DialogueObject;
}
