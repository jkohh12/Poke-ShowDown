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
    private int newRand;
    private float actionCounterP1 = 0;
    private float actionCounterP2 = 0;
    private double damageResultP1;
    private double damageResultP2;
    private float p2healthbarVal;

    //onClick(player clicks)


    

    private void Update()
    {


        //For testing
        
        
        if(/*P1MovesSource.moveCounterP1 == 3 ||*/ P2MovesSource.moveCounterP2 == 3)
        {
            //For testing
            indexVar = Random.Range(0, 3);
            newRand = Random.Range(0, 3);
            //
            //speed check here

            //choosing move done in browser
            //indexVar = randTest; //indexVar should be set to index of move chosen in browser

            //P1
            // damageResultP1 = chooseMove(indexVar);  //damage being done to player2 by player1

            //P2
            //Debug.Log("TEST");
            damageResultP2 = enemyChooseMove(newRand);
            

                
        }

        if(actionCounterP2 < (float)damageResultP2)
        {
            Debug.Log(damageResultP2);
            P1HealthBarSource.SetHealthP1((float)P1HealthBarSource.sliderP1.value - 0.1f);
            actionCounterP2 += 0.1f;
        }
        if(actionCounterP1 < (float)damageResultP1)
        {
         //   Debug.Log(damageResultP1);
            P2HealthBarSource.SetHealthP2((float)P2HealthBarSource.sliderP2.value - 0.1f);
            actionCounterP1+=0.1f;
        }

        if (P2HealthBarSource.sliderP2.value == 0)
        {
            P2HealthBarSource.sliderP2.value = -1;
            p2sprite.spriteRenderer.sprite = null;
            P2.textP2.text = "";

        }

        //





    }




    private double enemyChooseMove(int input) //make it wait for moves to generate
    {
        int? enemyPower = P2MovesSource.moveSetP2[input].power;
        float targetHealth = P1.statsGlobalP1[0].base_stat;
        float enemyAttack = P2.statsGlobalP2[1].base_stat;
        float targetDefense = P2.statsGlobalP2[2].base_stat;

        int calcRandom = Random.Range(80, 100);

        double damageCalc = ((((int)enemyPower * (enemyAttack / targetDefense) * 10) / 50) /* * STAB  * TYPE1 * TYPE2 (type effectiveness)add it later */ * calcRandom) / 100;

        if(damageCalc <= 2)
        {
            damageCalc = 2;
        }


        return damageCalc;
    }
    private double chooseMove(int input)
    {
        int? playerPower = P1MovesSource.moveSetP1[input].power;
        float targetHealth = P2.statsGlobalP2[0].base_stat;
        float playerAttack = P1.statsGlobalP1[1].base_stat;
        float targetDefense = P2.statsGlobalP2[2].base_stat;

     /*   Debug.Log(playerPower);
        Debug.Log(targetHealth);
        Debug.Log(playerAttack);
        Debug.Log(targetDefense);*/

        int calcRandom = Random.Range(80,100);

        double damageCalc = ((((int)playerPower * (playerAttack / targetDefense) * 10)/50) /* * STAB  * TYPE1 * TYPE2 (type effectiveness)add it later */ * calcRandom)/100;

        if(damageCalc <= 2)
        {
            damageCalc = 2;
        }

  /*      while (targetHealth > 0)
        {

        }*/
        return damageCalc;
       









    }

    /*    private void moveAction(string name, int? power)
        {

        }*/

    // Update is called once per frame

}
