using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableButton : MonoBehaviour
{
    private bool pressed;
    public GameObject ghostBlock;
    private void Press()
    {
        ghostBlock.SetActive(true);
        Destroy(gameObject);
    }

    public void PressButton()
    {
        Press();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PressButton();
        }
    }
}
