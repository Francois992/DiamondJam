using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour
{
    public AudioSource source;
    public AudioClip fallingZic;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            {

            AudioManager.instance.Stop("MainMusic");

            if (!source.isPlaying)
                {
                    source.PlayOneShot(fallingZic);
                }
        }
    }
}
