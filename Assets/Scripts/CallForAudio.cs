using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallForAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        AudioManager.instance.Play("FallingEgg");
    }

}
