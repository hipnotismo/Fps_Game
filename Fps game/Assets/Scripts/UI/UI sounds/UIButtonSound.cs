using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hoverButton;
    [SerializeField] private AudioClip clickButton;

    public void HoverSound()
    {
        if (hoverButton)
            audioSource.PlayOneShot(hoverButton);
    }

    public void ClickSound()
    {
        if (clickButton)
            audioSource.PlayOneShot(clickButton);
    }
}
