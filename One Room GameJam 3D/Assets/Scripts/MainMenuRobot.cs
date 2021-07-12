using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuRobot : MonoBehaviour
{
    private Animator anim;
    private AudioSource source;

    IEnumerator Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        anim.SetTrigger("Welcome");
        source.Play();
        yield return new WaitForSeconds(1.2f);
        anim.SetBool("Idle", true);
    }
}
