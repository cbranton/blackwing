using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DialogueResponseEvents))]
public class DialogueResponseEventEditor : Editor
{
    public override void OnInspectorGUI(){
        DrawDefaultInspector();
        DialogueResponseEvents responseEvents = (DialogueResponseEvents)target;
        if(GUILayout.Button("Refresh")){
            responseEvents.OnValidate();
        }
    }
}
