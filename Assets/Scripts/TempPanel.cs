using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPanel : MonoBehaviour
{
    public GameObject dialogue;
    private float seconds = 3f;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyAfterTime(dialogue, seconds));
    }
    private IEnumerator DestroyAfterTime(GameObject panel, float time)
    {
        yield return new WaitForSeconds(time);
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}
