using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class buttonChoose : MonoBehaviour
{

    [SerializeField] private Battle battle;


    [SerializeField] public TextMeshProUGUI move1;
    [SerializeField] public TextMeshProUGUI move2;
    [SerializeField] public TextMeshProUGUI move3;
    [SerializeField] public TextMeshProUGUI move4;

    [SerializeField] private AudioSource selectionSound;


    [SerializeField] private GameObject fightOverlay;

    [Header("Pokemon Details")]
    [SerializeField] private P1Moves p1Moves;


    public void moveSelect1()
    {

        selectionSound.Play();
        StartCoroutine(moveSelect1Delay());
    }

    public void moveSelect2()
    {
        selectionSound.Play();
        StartCoroutine(moveSelect2Delay());
    }
    public void moveSelect3()
    {
        selectionSound.Play();
        StartCoroutine(moveSelect3Delay());

    }
    public void moveSelect4()
    {
        selectionSound.Play();
        StartCoroutine(moveSelect4Delay());
    }

    IEnumerator moveSelect1Delay()
    {
        yield return new WaitForSeconds(1f);
        fightOverlay.gameObject.SetActive(false);
        battle.chooseMove(0);
    }

    IEnumerator moveSelect2Delay()
    {
        yield return new WaitForSeconds(1f);
        fightOverlay.gameObject.SetActive(false);
        battle.chooseMove(1);
    }
    IEnumerator moveSelect3Delay()
    {
        yield return new WaitForSeconds(1f);
        fightOverlay.gameObject.SetActive(false);
        battle.chooseMove(2);
    }
    IEnumerator moveSelect4Delay()
    {
        yield return new WaitForSeconds(1f);
        fightOverlay.gameObject.SetActive(false);
        battle.chooseMove(3);
    }

    public void moveDisplay()
    {
        Debug.Log("WORKING");



        string move1Cap = char.ToUpper(p1Moves.moveSetP1[0].name[0]) + p1Moves.moveSetP1[0].name.Substring(1);
        move1.text = move1Cap;


        string move2Cap = char.ToUpper(p1Moves.moveSetP1[1].name[0]) + p1Moves.moveSetP1[1].name.Substring(1);
        move2.text = move2Cap;


        string move3Cap = char.ToUpper(p1Moves.moveSetP1[2].name[0]) + p1Moves.moveSetP1[2].name.Substring(1);
        move3.text = move3Cap;


        string move4Cap = char.ToUpper(p1Moves.moveSetP1[3].name[0]) + p1Moves.moveSetP1[3].name.Substring(1);
        move4.text = move4Cap;



    }
}

