using System;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private bool canInteract = false;
    private GameObject indicator;
    public Dialogue dialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        indicator = GameObject.Find("DialogueIndicator");
        if (indicator == null)
        {
            Debug.LogError("DialogueIndicator GameObject not found in the scene.");
            return;
        }
        indicator.SetActive(false);

        dialogue = FindFirstObjectByType<Dialogue>();
        if (dialogue == null)
        {
            Debug.LogError("Dialogue script not found in the scene.");
        }
        else
        {
            dialogue.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) || Input.GetKeyDown(KeyCode.Space))
        {
            canInteract = false;
            indicator.SetActive(false);
            Debug.Log("Dialogue Triggered");
            dialogue.gameObject.SetActive(true);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canInteract = true;
        indicator.SetActive(true);
        Debug.Log("Player in range to interact");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canInteract = false;
        indicator.SetActive(false);
        Debug.Log("Player left range to interact");
    }
}