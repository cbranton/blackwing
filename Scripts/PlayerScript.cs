using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private dialogueUI dialogueUI;

    private const float MoveSpeed = 10f;

    public dialogueUI DialogueUI => dialogueUI;

    public interactable interactable { get; set; }

    private Rigidbody2D rb;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if(dialogueUI.isOpen) return;
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.MovePosition(rb.position + input.normalized* (MoveSpeed * Time.fixedDeltaTime));
        if (Input.GetKeyDown(KeyCode.Return)){
            if(interactable != null){
                interactable.Interact(this);
            }
        }
    }
}
