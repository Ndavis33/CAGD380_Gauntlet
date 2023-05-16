using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerHack : MonoBehaviour
{
    public void Init()
    {
        this.GetComponent<AudioListener>().enabled = true;
    }

}
