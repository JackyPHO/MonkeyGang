using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static int hearts = 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private Vector3 spawnPoint;

    void Start()
    {
        // Find the spawn point in the scene
        GameObject spawnPointObj = GameObject.FindGameObjectWithTag("SpawnPoint");
        if (spawnPointObj != null)
        {
        
            float cubeHeight = spawnPointObj.transform.localScale.y;
            spawnPoint = spawnPointObj.transform.position + new Vector3(0, cubeHeight / 2 + 1f, 0);
        }
        else
        {
            Debug.LogError("SpawnPoint not found! Ensure a cube with the 'SpawnPoint' tag is in the scene.");
        }

        // Initialize hearts
        if (hearts == 0)
        {
            hearts = 3;
        }
        heart3.SetActive(true);
        heart2.SetActive(true);
        heart1.SetActive(true);
    }

    private void Update()
    {
        if (hearts == 0)
        {
            Die();
        }
        if (hearts == 1)
        {
            heart2.SetActive(false);
        }
        if (hearts == 2)
        {
            heart3.SetActive(false);
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        Respawn(); // Respawn the player
    }

    private void Respawn()
    {
        // Reset hearts
        hearts = 3;
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);

        // Move the player back to the spawn point
        transform.position = spawnPoint;
        Debug.Log("Player respawned at: " + spawnPoint);
    }
}