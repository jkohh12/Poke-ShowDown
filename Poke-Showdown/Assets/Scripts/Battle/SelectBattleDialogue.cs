using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectBattleDialogue : MonoBehaviour
{
    [SerializeField] PokeStatusTeam1 P1;
    [SerializeField] PokeStatusTeam2 P2;

    [SerializeField] private TextMeshProUGUI commandText;

    [SerializeField] private buttonChoose displayMoves;

    [Header("Overlays")]
    [SerializeField] private GameObject commandOverlay;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject movesOverlay;

    

   
    public void whatWillPokeDo(string name)
    {
        movesOverlay.gameObject.SetActive(false);
        button.gameObject.SetActive(true);
        commandOverlay.gameObject.SetActive(true);
        commandText.text = "What will " + name + " do?";

    }

    public void moveSelection()
    {
        gameObject.SetActive(false);
        commandOverlay.gameObject.SetActive(false);
        movesOverlay.gameObject.SetActive(true);

        displayMoves.moveDisplay();
    }
 
}
