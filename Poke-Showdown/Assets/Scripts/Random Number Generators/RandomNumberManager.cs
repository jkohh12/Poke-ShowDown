using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumberManager : MonoBehaviour
{

    public int randomNumber;
    private void Awake()
    {
        randomNumber = Random.Range(1, 650);
    }
}
