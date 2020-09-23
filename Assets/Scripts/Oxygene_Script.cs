using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Oxygene_Script : MonoBehaviour
{
    public int Oxygene = 100;

    private void Update()
    {
        if(Oxygene < 100)
        {
            Oxygene++;
        }
    }
}
