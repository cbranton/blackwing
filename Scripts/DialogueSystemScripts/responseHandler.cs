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

    List<GameObject> tempResponseButtons = new List<GameObject>();

    private void Start(){
        DialogueUI = GetComponent<dialogueUI>();
    }

    public void ShowResponses(response[] Responses){
        float responseBoxHeight = 0f;

        foreach(response Response in Responses){
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = Response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(Response));

            tempResponseButtons.Add(responseButton);

            responseBoxHeight += responseBox.sizeDelta.y;
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);
    }

    private void OnPickedResponse(response Response){
        responseBox.gameObject.SetActive(false);

        foreach (GameObject button in tempResponseButtons){
            Destroy(button);
        }
        tempResponseButtons.Clear();

        DialogueUI.ShowDialogue(Response.dialogueObject);
    }
}
