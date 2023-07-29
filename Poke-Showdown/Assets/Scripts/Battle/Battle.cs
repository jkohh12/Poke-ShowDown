using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Battle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PokeStatusTeam1 P1;
    [SerializeField] PokeStatusTeam2 P2;

    [SerializeField] P1Moves P1MovesSource;
    [SerializeField] P2Moves P2MovesSource;

    [SerializeField] P1HealthBar P1HealthBarSource;
    [SerializeField] P2HealthBar P2HealthBarSource;

    [SerializeField] p1Sprite p1sprite;
    [SerializeField] p2Sprite p2sprite;

    [SerializeField] GameObject newP1;
    [SerializeField] GameObject newP2;

    private int indexVar; //onClick Variable
    private float actionCounter = 0;
    private double damageResult;
    private float p2healthbarVal;

    private void Update()
    {


        //For testing
        
        
        if(P1MovesSource.moveCounterP1 == 3)
        {
            //For testing
            indexVar = Random.Range(0, 3);
            //

            //choosing move done in browser
            //indexVar = randTest; //indexVar should be set to index of move chosen in browser
           
            damageResult = chooseMove(indexVar);
                
        }
        if(actionCounter < (float)damageResult)
        {
            Debug.Log(damageResult);
            P2HealthBarSource.SetHealthP2((float)P2HealthBarSource.sliderP2.value - 0.1f);
            actionCounter+=0.1f;
        }

/*        if(P2HealthBarSource.sliderP2.value == 0)
        {
            //Vector3 p2Pos = p2sprite.transform.position;
            P2HealthBarSource.sliderP2.value = -1;
            Destroy(p2sprite.gameObject);
            p2healthbarVal = 1;
            Instantiate(newP2, p2Pos, Quaternion.identity);
        }*/

        //
        




    }





    private double chooseMove(int input)
    {
        int? playerPower = P1MovesSource.moveSetP1[input].power;
        float targetHealth = P2.statsGlobalP2[0].base_stat;
        float playerAttack = P1.statsGlobalP1[1].base_stat;
        float targetDefense = P2.statsGlobalP2[2].base_stat;
/*
        Debug.Log(playerPower);
        Debug.Log(targetHealth);
        Debug.Log(playerAttack);
        Debug.Log(targetDefense);*/

        int calcRandom = Random.Range(80,100);

        double damageCalc = ((((int)playerPower * (playerAttack / targetDefense) * 10)/50) /* * STAB  * TYPE1 * TYPE2 (type effectiveness)add it later */ * calcRandom)/100;

        if(damageCalc <= 2)
        {
            damageCalc = 2;
        }
        return damageCalc;
       









    }

    /*    private void moveAction(string name, int? power)
        {

        }*/

    // Update is called once per frame

}
