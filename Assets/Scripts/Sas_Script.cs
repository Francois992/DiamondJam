using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Sas_Script : MonoBehaviour
{
    public bool Ouvert;
    private float initialPosY;
    private float finalPosY;

    // Start is called before the first frame update
    void Start()
    {
        initialPosY = transform.localPosition.y;
        finalPosY = transform.localPosition.y + transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Ouvert)
        {
            transform.DOLocalMoveY(finalPosY, 0.5f);
        }

        else
        {
            transform.DOLocalMoveY(initialPosY, 0.5f);
        }
        
    }
}
