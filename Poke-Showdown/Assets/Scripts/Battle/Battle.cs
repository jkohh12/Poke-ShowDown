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



    [Header("Audio")]
    [SerializeField] private AudioSource[] effectivenessSound;
    [SerializeField] private AudioSource mainBGM;
    [SerializeField] private AudioSource victoryBGM;
    [SerializeField] private AudioSource lowHP;
    [SerializeField] private AudioSource YOULOST;

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
    private bool p2Turn = false;

    private string p1Name;
    private string p2Name;

    private bool p1Alive = true;
    private bool p2Alive = true;
    private int p1Input;

    private bool superEffectiveSound = false;
    private bool notEffectiveSound = false;
    private bool normalEffectSound = false;
    private bool noEffectSound = false;

    private bool superEffective = false;
    private bool notEffective = false;
    private bool normalEffect = false;
    private bool noEffect = false;

    private bool moveMissP1 = false;
    private bool moveMissP2 = false;


    private bool canChooseMove = true;

    private float currentHealth;

    private int enemyRandomMove;


    private void Start()
    {
        mainBGM.Play();
        // string nameP1Cap = char.ToUpper(P1.name[0]) + P1.name.Substring(1);
        p1Name = P1.textP1.text;
        p2Name = P2.textP2.text;
        /*        Debug.Log(p1Name);
                Debug.Log(p2Name);*/
        dialogueText.text = "What will " + P1.textP1.text + " do?";
        currentHealth = P1.statsGlobalP1[0].base_stat;

    }


    void Update()
    {

        //Testing
        if (Input.GetButtonDown("Jump"))
        {
            chooseMove(0);
        }

        if (superEffectiveSound)
        {
            effectivenessSound[1].Play();
            superEffective = true;
            superEffectiveSound = false;
        }
        else if (notEffectiveSound)
        {
            effectivenessSound[2].Play();
            notEffective = true;
            notEffectiveSound = false;
        }
        else if (normalEffectSound)
        {
            effectivenessSound[0].Play();
            normalEffect = true;
            normalEffectSound = false;
        }

        else if (noEffectSound)
        {
            noEffect = true;
            noEffectSound = false;
        }

        //TODO: Fix move miss and no effect
        if (noEffectSound && !p2Turn || moveMissP1 && !p2Turn)
        {
            Debug.Log("NO EFFECT");
            
            StartCoroutine(enemyMove());
            moveMissP1 = false;

        }
        if(noEffectSound && !p1Turn || moveMissP2 && !p1Turn)
        {
            Debug.Log("NO EFFECT");
            
            StartCoroutine(p1Move());
            moveMissP2 = false;
        }


        if (actionCounterP1 < (float)damageResultP1 && P1HealthBarSource.sliderP1.value != 0)
        { 

            P2HealthBarSource.SetHealthP2((float)P2HealthBarSource.sliderP2.value - 1f);
            actionCounterP1 += 1f;
            if(actionCounterP1 >= (float)damageResultP1)
            {
                actionCounterP1 = 0;
                damageResultP1 = 0;

                if(P2HealthBarSource.sliderP2.value != 0 && !p2Turn)
                {

                   StartCoroutine(enemyMove());
      
                }


            }
        }

        if (actionCounterP2 < (float)damageResultP2)
        {
            P1HealthBarSource.SetHealthP1((float)P1HealthBarSource.sliderP1.value - 1f);
            actionCounterP2 += 1f;
            if(actionCounterP2 >= (float)damageResultP2)
            {

                actionCounterP2 = 0;
                damageResultP2 = 0;
                if(P1HealthBarSource.sliderP1.value != 0 && !p1Turn)
                {
                    
                  
                   StartCoroutine(p1Move());
             


                }

                
            }
        }


        if (P2HealthBarSource.sliderP2.value == 0 && p2Alive)
        {
            p2Alive = false;
            StartCoroutine(p2Faint());
            
            


        }


        if(P1HealthBarSource.sliderP1.value == 0 && p1Alive)
        {
            p1Alive = false;
            StartCoroutine(p1Faint());
          
        }

        //

    }


    IEnumerator effectivenessText()
    {

        //TODO: Rework 
        Debug.Log("GOT TO HERE");
        
        if (superEffective)
        {
            yield return new WaitForSeconds(1f);
            dialogueText.text = "";
            dialogueText.text = "It's super effective!";
            Debug.Log("WE TO HERE");
            superEffective = false;

        }

        else if (notEffective)
        {
            yield return new WaitForSeconds(1f);
            dialogueText.text = "";
            dialogueText.text = "It's not very effective...";
            Debug.Log("WE TO HERE");
            notEffective = false;
        }
        else if (noEffect)
        {
            yield return new WaitForSeconds(1f);
            dialogueText.text = "";
            dialogueText.text = "It has no effect";
            Debug.Log("WE TO HERE");
            noEffect = false;
        }
        else if (moveMissP1) 
        {
            yield return new WaitForSeconds(1f);
            dialogueText.text = "";
            dialogueText.text = P1.textP1.text + " missed!";
            moveMissP1 = false;

        }
        else if (moveMissP2)
        {
            yield return new WaitForSeconds(1f);
            dialogueText.text = "";
            dialogueText.text = "The foe's " + P2.textP2.text + " missed!";
            moveMissP2 = false;
        }
        else
        {
            Debug.Log("WE TO HERE");
            normalEffect = false;
        }




        
     



    }

    public void p1DialogueText()
    {

        dialogueText.text = "What will " + P1.textP1.text + " do?";
        canChooseMove = true;

    }


    IEnumerator p1Faint()
    {
        yield return StartCoroutine(effectivenessText());
        yield return new WaitForSeconds(1f);
        dialogueText.text = "";
        dialogueText.text = p1Name + " fainted!";
        P1.textP1.text = "";
        p1sprite.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        lowHP.FadeOut(1f);
        mainBGM.FadeOut(2f);
        setLossText();

        

  
    }


    IEnumerator p2Faint()
    {
        yield return StartCoroutine(effectivenessText());
        yield return new WaitForSeconds(1f);
      
        dialogueText.text = "";
        dialogueText.text = "The foe's " + p2Name + " fainted!";
        P2.textP2.text = "";
        p2sprite.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        mainBGM.FadeOut(2f);
        setVictoryText();
        
        
    }



    public void setVictoryText()
    {
        dialogueText.text = "";
        dialogueText.text = "You defeated the enemy trainer!";
 
        //mainBGM.Stop();
        victoryBGM.Play();
        
    }

    public void setLossText()
    {
        dialogueText.text = "";
        dialogueText.text = "You lost";

        YOULOST.Play(); //change later lol
    }

    IEnumerator p1Move()
    {
        p1Turn = true;
        yield return StartCoroutine(effectivenessText());
        yield return new WaitForSeconds(1f);
        p1ChooseMove(p1Input);
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(effectivenessText());
        yield return new WaitForSeconds(1f);
        if(p2Alive)
        {
            p1DialogueText();
        }

    }

    IEnumerator enemyMove()
    {
        // p1Turn = false;
        p2Turn = true;
        yield return StartCoroutine(effectivenessText());
        //  yield return new WaitUntil(() => effectText == true);
        yield return new WaitForSeconds(1f);
        enemyRandomMove = Random.Range(0, 3);
        enemyChooseMove(enemyRandomMove);
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(effectivenessText());
        yield return new WaitForSeconds(1f);
        if(p1Alive)
        {
            p1DialogueText();

        }
   
    }

    IEnumerator playLowHP()
    {
        yield return new WaitForSeconds(1f);
        lowHP.Play();
  

    }


    public void chooseMove(int input)
    {
        if (canChooseMove && P2HealthBarSource.sliderP2.value != 0 && P1HealthBarSource.sliderP1.value != 0)
        {

            enemyRandomMove = Random.Range(0, 3);
            p1Input = input;

            if (P1.statsGlobalP1[5].base_stat > P2.statsGlobalP2[5].base_stat)
            {
                p1Turn = true;
                p2Turn = false;
                p1ChooseMove(input);
            }
            else if (P1.statsGlobalP1[5].base_stat < P2.statsGlobalP2[5].base_stat)
            {
                p2Turn = true;
                p1Turn = false;
                enemyChooseMove(enemyRandomMove);
            }

            else
            {
                int speedTie = Random.Range(0, 1);
                if (speedTie == 0)
                {
                    p1Turn = true;
                    p2Turn = false;
                    p1ChooseMove(input);
                }
                else
                {
                    p2Turn = true;
                    p1Turn = false;
                    enemyChooseMove(enemyRandomMove);
                }
            }
            canChooseMove = false;

        }
        



    }
    public void enemyChooseMove(int input) //make it wait for moves to generate
    {


            string p2MoveCap = char.ToUpper(P2MovesSource.moveSetP2[input].name[0]) + P2MovesSource.moveSetP2[input].name.Substring(1);
            dialogueText.text = "";
            dialogueText.text = "The foe's " + P2.textP2.text + " used " + p2MoveCap + "!";
            int? enemyPower = P2MovesSource.moveSetP2[input].power;
            float targetHealth = P1.statsGlobalP1[0].base_stat;


            float enemyAttack = P2.statsGlobalP2[1].base_stat;
            float enemySpAttack = P2.statsGlobalP2[3].base_stat;

            float targetDefense = P2.statsGlobalP2[2].base_stat;
            float targetSpDefense = P2.statsGlobalP2[4].base_stat;

            int calcRandom = Random.Range(80, 100);
            int accRandom = Random.Range(1, 100);

            double damageCalc;

       // Debug.Log("randomP2" + accRandom);

            if (accRandom > P2MovesSource.moveSetP2[input].accuracy)
            {

                //Debug.Log("P2: MISS");
                moveMissP2 = true;
                damageCalc = 0;
                return;
            }
            else
            {
                if (P2MovesSource.moveSetP2[input].damage_class.name == "physical")
                {
                    damageCalc = ((((int)enemyPower * (enemyAttack / targetDefense) * 10) / 50) * calcRandom) / 100;
                    //Debug.Log("p2: PHYS");
                }
                else
                {
                    damageCalc = ((((int)enemyPower * (enemySpAttack / targetSpDefense) * 10) / 50) * calcRandom) / 100;
                   // Debug.Log("p2: SP");
                }

            }


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

            //STAB
            damageCalc = stabCalc(damageCalc, p1Types, P2MovesSource.moveSetP2[input].type.name);



            currentHealth = currentHealth - (float)damageCalc;


            if (currentHealth / targetHealth <= 0.160 && currentHealth / targetHealth > 0) //normalize percent value?
            {

                mainBGM.FadeOut(0.5f);
                StartCoroutine(playLowHP());
            }


            damageResultP2 = damageCalc;
            Mathf.Floor((float)damageResultP2);



    }


    public void p1ChooseMove(int input)
    {

            //check for speed here
            string p1MoveCap = char.ToUpper(P1MovesSource.moveSetP1[input].name[0]) + P1MovesSource.moveSetP1[input].name.Substring(1);
            dialogueText.text = "";
            dialogueText.text = P1.textP1.text + " used " + p1MoveCap + "!";

            int? playerPower = P1MovesSource.moveSetP1[input].power;
            float targetHealth = P2.statsGlobalP2[0].base_stat;

            //Attacks
            float playerAttack = P1.statsGlobalP1[1].base_stat;
            float playerSpAttack = P1.statsGlobalP1[3].base_stat;
            
            //Defenses
            float targetDefense = P2.statsGlobalP2[2].base_stat;
            float targetSpDefense = P2.statsGlobalP2[4].base_stat;

            int calcRandom = Random.Range(80, 100);
            int accRandom = Random.Range(1, 100);

            //normal effect, 2x super effective, 4x super effective, 0.5 not effective, 0.25 not effective, no effect

            //accuracy
            double damageCalc;

       // Debug.Log("P1 rand:" + accRandom);
            if (accRandom > P1MovesSource.moveSetP1[input].accuracy) 
            {

                Debug.Log("P1: MISS");
                moveMissP1 = true;
                damageCalc = 0;
                return;
            }
            else
            {
                if(P1MovesSource.moveSetP1[input].damage_class.name == "physical") 
                {
                    damageCalc = ((((int)playerPower * (playerAttack / targetDefense) * 10) / 50) * calcRandom) / 100;
                    //Debug.Log("p1: PHYS");
                }
                
                else
                {
                    damageCalc = ((((int)playerPower * (playerSpAttack / targetSpDefense) * 10) / 50) * calcRandom) / 100;
                   // Debug.Log("p1: SP");
                }
            }

            List<string> p2Types = new List<string>();
            if (P2.typeGlobalP2.Count == 2)
            {
                p2Types.Add(P2.typeGlobalP2[0].type.name);
                p2Types.Add(P2.typeGlobalP2[1].type.name);

            }
            else
            {
                p2Types.Add(P2.typeGlobalP2[0].type.name);
            }

            damageCalc = effectivenessCalc(damageCalc, input, P1MovesSource.moveSetP1[input].type.name, p2Types);

            //STAB
            damageCalc = stabCalc(damageCalc, p2Types, P1MovesSource.moveSetP1[input].type.name);

            damageResultP1 = damageCalc;
    
            Mathf.Floor((float)damageResultP1);

            //Debug.Log("P1 DAMAGE: " + damageResultP1);

    }


    private double stabCalc(double damageCalc, List<string> pokeTypes, string moveType )
    {

        if (pokeTypes.Count == 2)
        {
            if (moveType == pokeTypes[0] || moveType == pokeTypes[1])
            {
                damageCalc = damageCalc * 1.5;
                //Debug.Log("2TYPE: STAB");
            }
        }
        else if (pokeTypes.Count == 1)
        {
            if (moveType == pokeTypes[0])
            {
                damageCalc = damageCalc * 1.5;
              //  Debug.Log("1Type: STAB");
            }

        }

        else
        {
            damageCalc = damageCalc * 1;
        }

        return damageCalc;
    }
    

    private double effectivenessCalc(double damageCalc, int input, string dealingDamage, List<string> takingDamage)
    {
        //TYPE CALC
        //Debug.Log("THIS IS THE MOVE TYPE DEALING DAMAGE" + dealingDamage);

        //Debug.Log("Before Calcs: " + damageCalc);

        double beforeDamageCalc = damageCalc;

        //Debug.Log("P HAS THIS MANY TYPES" + P2.typeGlobalP2.Count);


        if (typeEffectiveness.superEffective[dealingDamage].Contains(takingDamage[0]))
        {
            damageCalc = damageCalc * 2;
           // Debug.Log("2x");
            
        }
        else if (typeEffectiveness.notEffective[dealingDamage].Contains(takingDamage[0]))
        {
            damageCalc = damageCalc * 0.5;
           // Debug.Log("0.5x");
          
        }
        else if (typeEffectiveness.noEffect[dealingDamage].Contains(takingDamage[0]))
        {
            damageCalc = 0;
           // Debug.Log("no Effect");
        }

        else
        {
            damageCalc = damageCalc * 1;
           // Debug.Log("nothing");
           

        }

        if (takingDamage.Count == 2)
        {
            if (typeEffectiveness.superEffective[dealingDamage].Contains(takingDamage[1]))
            {
                damageCalc = damageCalc * 2;
              //  Debug.Log("2type: 4x");
                
            }
            else if (typeEffectiveness.notEffective[dealingDamage].Contains(takingDamage[1]))
            {
                damageCalc = damageCalc * 0.5;
              //  Debug.Log("2type: 0.5x");
                
            }
            else if (typeEffectiveness.noEffect[dealingDamage].Contains(takingDamage[1]))
            {
                damageCalc = 0;
              //  Debug.Log("2type: NoEffect");

            }

            else
            {
                damageCalc = damageCalc * 1;
               // Debug.Log("2type: nothing");

            }
        }


        //check which type of Effectiveness
        if(beforeDamageCalc * 2 == damageCalc || beforeDamageCalc * 4 == damageCalc)
        {
            superEffectiveSound = true;
        }
        else if (beforeDamageCalc * 0.5 == damageCalc || beforeDamageCalc * 0.25 == damageCalc)
        {
            notEffectiveSound = true;
        }
        else if (beforeDamageCalc == damageCalc)
        {
            normalEffectSound = true;
        }
        else if(damageCalc == 0)
        {
            noEffectSound = true;
        }
        else
        {
            noEffectSound = false;
            superEffectiveSound = false;
            notEffectiveSound = false;
            normalEffectSound = false;

        }
        //Debug.Log("After Calcs: " + damageCalc);
        // Debug.Log("END HERE");

        return damageCalc;
    }






}
