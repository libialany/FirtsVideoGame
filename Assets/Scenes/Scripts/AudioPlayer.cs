using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("SOUNDS")]
    public AudioSource audioS;
    public AudioClip living;
    private void Update() {
        audioS.PlayOneShot(living);
    }
}
