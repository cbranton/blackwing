using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class responseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;

    private dialogueUI DialogueUI;
    private ResponseEvent[] responseEvents;

    List<GameObject> tempResponseButtons = new List<GameObject>();

    private void Start(){
        DialogueUI = GetComponent<dialogueUI>();
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents){
        this.responseEvents = responseEvents;
    }

    public void ShowResponses(response[] Responses){
        float responseBoxHeight = 0f;

        for (int i = 0; i< Responses.Length; i++){
            response Response = Responses[i];
            int responseIndex = i;

            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = Response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(Response, responseIndex));

            tempResponseButtons.Add(responseButton);

            responseBoxHeight += responseBox.sizeDelta.y;
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);
    }

    private void OnPickedResponse(response Response, int responseIndex){
        responseBox.gameObject.SetActive(false);

        foreach (GameObject button in tempResponseButtons){
            Destroy(button);
        }
        tempResponseButtons.Clear();

        if (responseEvents!= null && responseIndex <= responseEvents.Length){
            responseEvents[responseIndex].OnPickedResponse?.Invoke();
        }

        DialogueUI.ShowDialogue(Response.dialogueObject);
    }
}
