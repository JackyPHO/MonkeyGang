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

    void Update()
    {
        // Check if the player presses E while near the NPC
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // Show the dialogue panel and update the text
            dialoguePanel.SetActive(true);
            dialogueText.text = message;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Ensure only the player triggers the interaction
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Ensure only the player triggers the interaction
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;

            // Hide the dialogue when the player walks away
            dialoguePanel.SetActive(false);
        }
    }
}