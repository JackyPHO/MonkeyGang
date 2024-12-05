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

    void Start()
    {
        if (hearts == 0)
        {
            hearts = 3;
        }
        heart3.SetActive(false);
        heart2.SetActive(false);
        heart1.SetActive(false);
    }
    private void Update()
    {
        if (hearts == 0)
        {
            Die();
        }
        if (hearts == 1)
        {
            heart3.SetActive(false);
            heart2.SetActive(false);
            heart1.SetActive(true);
        }
        if (hearts == 2)
        {
            heart3.SetActive(false);
            heart2.SetActive(true);
            heart1.SetActive(true);
        }
        if (hearts == 3)
        {
            heart3.SetActive(true);
            heart2.SetActive(true);
            heart1.SetActive(true);
        }
    }
    private void Die()
    {
        Debug.Log("Player has died!");
        SceneManager.LoadScene("GameOver");
        // Implement additional death behavior here (e.g., reload level, show game over screen)
    }
}