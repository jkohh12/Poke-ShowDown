using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumberManagerP2 : MonoBehaviour
{

    public int randomNumberP2;
    private void Awake()
    {
        randomNumberP2 = Random.Range(1, 650);
    }
}
