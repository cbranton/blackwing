using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMapTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("An object entered.");
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("An object left.");
    }
}
