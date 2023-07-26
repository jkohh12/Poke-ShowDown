using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumberManager : MonoBehaviour
{

    public int randomNumberP1;
    private void Awake()
    {
        randomNumberP1 = Random.Range(1, 650);
    }
}
