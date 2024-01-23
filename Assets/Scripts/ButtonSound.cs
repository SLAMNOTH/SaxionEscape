using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public void playButton(){
        GetComponent<AudioSource>().Play();
    }
}
