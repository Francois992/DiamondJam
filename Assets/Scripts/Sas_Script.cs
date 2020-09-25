using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Sas_Script : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public bool Ouvert;
    [SerializeField] public float initialPosY = 0;
    [SerializeField] private float finalPosY = 2.5f;

    [SerializeField] private Oxygene_Script OxygeneZone = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Ouvert)
        {
            transform.DOLocalMoveY(finalPosY, 0.5f);
            if( OxygeneZone != null)OxygeneZone.Oxygene = 0;
            if (!source.isPlaying)
            {
                source.PlayOneShot(clip);
            }
        }

        else
        {
            transform.DOLocalMoveY(initialPosY, 0.5f);
        }
        
    }
}
