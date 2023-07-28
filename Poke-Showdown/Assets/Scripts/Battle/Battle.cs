using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PokeStatusTeam1 P1;
    [SerializeField] PokeStatusTeam2 P2;

    [SerializeField] P1Moves P1Moves;
    [SerializeField] P2Moves P2Moves;

    [SerializeField] P1HealthBar P1HealthBar;
    [SerializeField] P2HealthBar P2HealthBar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
