using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FriendlyNPC : MonoBehaviour
{
    public GameObject dialoguePanel; 
    public TextMeshProUGUI dialogueText; 
    public string message = "Collect all the orbs to unlock the next level!";

    private bool isPlayerNearby = false;

    void Start()
    {
        // Ensure the dialogue panel is hidden at the start
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
    }

    void Update()
    {
        // Show the dialogue panel when the player presses E
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // Toggle the dialogue panel visibility
            bool isActive = dialoguePanel.activeSelf;
            dialoguePanel.SetActive(!isActive);

            // Update the dialogue text when activating
            if (!isActive)
            {
                dialogueText.text = message;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Detect when the player enters the NPC's area
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Detect when the player leaves the NPC's area
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;

            // Hide the dialogue panel when the player walks away
            if (dialoguePanel != null)
            {
                dialoguePanel.SetActive(false);
            }
        }
    }
}