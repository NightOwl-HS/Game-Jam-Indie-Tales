using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableButton : MonoBehaviour
{
    public GameObject ghostBlock;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Press()
    {
        Debug.Log("AAA");
        ghostBlock.SetActive(!ghostBlock.activeInHierarchy);
        anim.SetBool("Pressed", true);
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
