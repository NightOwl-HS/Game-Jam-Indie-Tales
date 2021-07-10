using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableButton : MonoBehaviour
{
    private bool pressed;
    public GameObject ghostBlock;

    private void Update()
    {
        CheckButton();
    }
    private void CheckButton()
    {
        if (pressed)
        {
            ButtonPress();
        }
    }

    private void ButtonPress()
    {
        ghostBlock.SetActive(true);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pressed = true;
        }
    }
}
