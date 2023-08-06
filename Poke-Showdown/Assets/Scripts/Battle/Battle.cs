using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Linq;

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


    [SerializeField] private TypeEffectiveness typeEffectiveness;

/*    [SerializeField] GameObject newP1;
    [SerializeField] GameObject newP2;*/

    [SerializeField] private TextMeshProUGUI dialogueText;

    private int indexVarP1;//onClick Variable
    private int indexVarP2; //onClick Variable
    private float actionCounterP1 = 0;
    private float actionCounterP2 = 0;
    private double damageResultP1;
    private double damageResultP2;
    private float p2healthbarVal;

    private bool p1Turn = true;
    private bool p2Turn;

    private string p1Name;
    private string p2Name;

    private bool p1Alive = true;
    private bool p2Alive = true;

    private bool hasTwoTypes = false;
    private int typeCounter = 0;




    //onClick(player clicks)

    private void Start()
    {

        // string nameP1Cap = char.ToUpper(P1.name[0]) + P1.name.Substring(1);
        p1Name = P1.textP1.text;
        p2Name = P2.textP2.text;
        /*        Debug.Log(p1Name);
                Debug.Log(p2Name);*/
        dialogueText.text = "What will " + P1.textP1.text + " do?";




    }


    void Update()
    {

        //Testing
        if (Input.GetButtonDown("Jump"))
        {
            chooseMove(0);
        }

        if (actionCounterP1 < (float)damageResultP1 && P1HealthBarSource.sliderP1.value != 0)
        { 
            //Debug.Log("P1 DAMAGE" + damageResultP1);
            P2HealthBarSource.SetHealthP2((float)P2HealthBarSource.sliderP2.value - 0.4f);
            actionCounterP1 += 0.4f;
            if(actionCounterP1 >= (float)damageResultP1)
            {
                actionCounterP1 = 0;
                damageResultP1 = 0;
                if(P2HealthBarSource.sliderP2.value != 0)
                {
                    p1Turn = false;
                    StartCoroutine("enemyMove");
                }

            }
        }

        if (actionCounterP2 < (float)damageResultP2)
        {
            //Debug.Log("P2 DAMAGE" + damageResultP2 );
            P1HealthBarSource.SetHealthP1((float)P1HealthBarSource.sliderP1.value - 0.4f);
            actionCounterP2 += 0.4f;
            if(actionCounterP2 >= (float)damageResultP2)
            {
                dialogueText.text = "";
                dialogueText.text = "What will " + P1.textP1.text + " do?";
                actionCounterP2 = 0;
                damageResultP2 = 0;
            }
        }


        if (P2HealthBarSource.sliderP2.value == 0 && p2Alive)
        {

            // P2HealthBarSource.sliderP2.value = -1;
            StartCoroutine(p2Faint());

        }

        if (!p2Alive)
        {
            StartCoroutine(victoryText());
        }

        if(P1HealthBarSource.sliderP1.value == 0 && p1Alive)
        {

            StartCoroutine(p1Faint());

        }

        if (!p1Alive/*P1HealthBarSource.sliderP1.value == -1*/)
        {
            StartCoroutine(lossText());
        }
        //

    }



    IEnumerator p1Faint()
    {
        yield return new WaitForSeconds(1f);
        dialogueText.text = "";
        dialogueText.text = p1Name + " fainted!";
        P1.textP1.text = "";
        p1sprite.gameObject.SetActive(false);
        p1Alive = false;
    }


    IEnumerator p2Faint()
    {

        yield return new WaitForSeconds(1f);
      
        dialogueText.text = "";
        dialogueText.text = "The foe's " + p2Name + " fainted!";
        P2.textP2.text = "";
        p2sprite.gameObject.SetActive(false);
        p2Alive = false;
    }

    IEnumerator lossText()
    {
        yield return new WaitForSeconds(1f);
        dialogueText.text = "";
        setLossText();
        //
    }

    IEnumerator victoryText()
    {
        yield return new WaitForSeconds(1f);
        dialogueText.text = "";
        setVictoryText();
        // 
    }


    public void setVictoryText()
    {
        dialogueText.text = "";
        dialogueText.text = "You defeated the enemy trainer!";
    }

    public void setLossText()
    {
        dialogueText.text = "";
        dialogueText.text = "You lost";
    }

    IEnumerator enemyMove()
    {
       // p1Turn = false;
        yield return new WaitForSeconds(1f);
        int enemyRandomMove = Random.Range(0, 3);
        enemyChooseMove(enemyRandomMove);
       
 

    }

/*    IEnumerator enemyMoveAction()
    {
        

    }*/

    public void enemyChooseMove(int input) //make it wait for moves to generate
    {
        string p2MoveCap = char.ToUpper(P2MovesSource.moveSetP2[input].name[0]) + P2MovesSource.moveSetP2[input].name.Substring(1);
        dialogueText.text = "";
        dialogueText.text = "The foe's " + P2.textP2.text + " used " + p2MoveCap + "!";
        int? enemyPower = P2MovesSource.moveSetP2[input].power;
        float targetHealth = P1.statsGlobalP1[0].base_stat;
        float enemyAttack = P2.statsGlobalP2[1].base_stat;
        float targetDefense = P2.statsGlobalP2[2].base_stat;

        int calcRandom = Random.Range(80, 100);

        double damageCalc = ((((int)enemyPower * (enemyAttack / targetDefense) * 10) / 50) /* * STAB  * TYPE1 * TYPE2 (type effectiveness)add it later */ * calcRandom) / 100;

        List<string> p1Types = new List<string>();
        if (P1.typeGlobalP1.Count == 2)
        {
            p1Types.Add(P1.typeGlobalP1[0].type.name);
            p1Types.Add(P1.typeGlobalP1[1].type.name);

        }
        else
        {
            p1Types.Add(P1.typeGlobalP1[0].type.name);

        }

        damageCalc = effectivenessCalc(damageCalc, input, P2MovesSource.moveSetP2[input].type.name, p1Types);

        if(P2.typeGlobalP2.Count == 2)
        {
            if (P2MovesSource.moveSetP2[input].type.name == P2.typeGlobalP2[0].type.name || P2MovesSource.moveSetP2[input].type.name == P2.typeGlobalP2[1].type.name)
            {
                damageCalc = damageCalc * 1.5;
                Debug.Log("2TYPE: STAB");
            }
        }
        else
        {
            if(P2MovesSource.moveSetP2[input].type.name == P2.typeGlobalP2[0].type.name)
            {
                damageCalc = damageCalc * 1.5;
                Debug.Log("1Type: STAB");
            }
        }
        //STAB
       


/*        if (damageCalc <= 2)
        {
            damageCalc = 2;
        }
*/
        damageResultP2 = damageCalc;
        p1Turn = true;


//        return damageCalc;
    }
    public void chooseMove(int input)
    {

        if (p1Turn && P2HealthBarSource.sliderP2.value != 0 && P1HealthBarSource.sliderP1.value != 0)
        {
            //check for speed here
            string p1MoveCap = char.ToUpper(P1MovesSource.moveSetP1[input].name[0]) + P1MovesSource.moveSetP1[input].name.Substring(1);
            dialogueText.text = "";
            dialogueText.text = P1.textP1.text + " used " + p1MoveCap + "!";

            int? playerPower = P1MovesSource.moveSetP1[input].power;
            float targetHealth = P2.statsGlobalP2[0].base_stat;
            float playerAttack = P1.statsGlobalP1[1].base_stat;
            float targetDefense = P2.statsGlobalP2[2].base_stat;

            /*   Debug.Log(playerPower);
               Debug.Log(targetHealth);
               Debug.Log(playerAttack);
               Debug.Log(targetDefense);*/

            int calcRandom = Random.Range(80, 100);


        

            
          

            //normal effect, 2x super effective, 4x super effective, 0.5 not effective, 0.25 not effective, no effect

            double damageCalc = ((((int)playerPower * (playerAttack / targetDefense) * 10) / 50) /* * STAB  * TYPE1 * TYPE2 (type effectiveness)add it later */ * calcRandom) / 100;

            List<string> p2Types = new List<string>();
            if(P2.typeGlobalP2.Count == 2)
            {
                p2Types.Add(P2.typeGlobalP2[0].type.name);
                p2Types.Add(P2.typeGlobalP2[1].type.name);

            }
            else
            {
                p2Types.Add(P2.typeGlobalP2[0].type.name);
            }

            damageCalc = effectivenessCalc(damageCalc, input, P1MovesSource.moveSetP1[input].type.name, p2Types);


            if (P1.typeGlobalP1.Count == 2)
            {
                if (P1MovesSource.moveSetP1[input].type.name == P1.typeGlobalP1[0].type.name || P1MovesSource.moveSetP1[input].type.name == P1.typeGlobalP1[1].type.name)
                {
                    damageCalc = damageCalc * 1.5;
                    Debug.Log("2TYPE: STAB");
                }
            }
            else
            {
                if (P1MovesSource.moveSetP1[input].type.name == P1.typeGlobalP1[0].type.name)
                {
                    damageCalc = damageCalc * 1.5;
                    Debug.Log("1Type: STAB");
                }
            }
            /*
                        if (damageCalc <= 2)
                        {
                            damageCalc = 2;
                        }*/

            //STAB CALC

            damageResultP1 = damageCalc;
        }

  //      return damageCalc;

    }
    

    private double effectivenessCalc(double damageCalc, int input, string dealingDamage, List<string> takingDamage)
    {
        //TYPE CALC
        Debug.Log("THIS IS THE MOVE TYPE DEALING DAMAGE" + dealingDamage);

        Debug.Log("Before Calcs: " + damageCalc);

        Debug.Log("P HAS THIS MANY TYPES" + P2.typeGlobalP2.Count);


        if (typeEffectiveness.superEffective[dealingDamage].Contains(takingDamage[0]))
        {
            damageCalc = damageCalc * 2;
            Debug.Log("2x");
        }
        else if (typeEffectiveness.notEffective[dealingDamage].Contains(takingDamage[0]))
        {
            damageCalc = damageCalc * 0.5;
            Debug.Log("0.5x");
        }
        else if (typeEffectiveness.noEffect[dealingDamage].Contains(takingDamage[0]))
        {
            damageCalc = 0;
            Debug.Log("no Effect");
        }

        else
        {
            damageCalc = damageCalc * 1;
            Debug.Log("nothing");

        }

        if (takingDamage.Count == 2)
        {
            if (typeEffectiveness.superEffective[dealingDamage].Contains(takingDamage[1]))
            {
                damageCalc = damageCalc * 2;
                Debug.Log("2type: 4x");
            }
            else if (typeEffectiveness.notEffective[dealingDamage].Contains(takingDamage[1]))
            {
                damageCalc = damageCalc * 0.5;
                Debug.Log("2type: 0.5x");
            }
            else if (typeEffectiveness.noEffect[dealingDamage].Contains(takingDamage[1]))
            {
                damageCalc = 0;
                Debug.Log("2type: NoEffect");

            }

            else
            {
                damageCalc = damageCalc * 1;
                Debug.Log("2type: nothing");

            }
        }


        Debug.Log("After Calcs: " + damageCalc);
        Debug.Log("END HERE");

        return damageCalc;
    }






}
