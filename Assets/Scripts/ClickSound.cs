using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip clickFx;

    public void clickSound()
    {
        myFx.PlayOneShot(clickFx);
    }
}
