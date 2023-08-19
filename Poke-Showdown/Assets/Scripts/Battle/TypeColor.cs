using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeColor : MonoBehaviour
{
    [SerializeField] private P1Moves moves;



    [SerializeField] private TextMeshProUGUI type;

    [SerializeField] buttonChoose buttonChoose;
    private Button button;
    private ColorBlock color;
    private TextMeshProUGUI moveText;

    public IDictionary<string, Color> typeColor = new Dictionary<string, Color>();


    private void Awake()
    {
        typeColor.Add("normal", new Color(170 / 255f, 170 / 255f, 153 / 255f));
        typeColor.Add("fire", new Color(255 / 255f, 68 / 255f, 34 / 255f));
        typeColor.Add("water", new Color(51 / 255f, 153 / 255f, 255 / 255f));
        typeColor.Add("electric", new Color(255 / 255f, 204 / 255f, 51 / 255f));
        typeColor.Add("grass", new Color(119 / 255f, 204 / 255f, 85 / 255f));
        typeColor.Add("ice", new Color(102 / 255f, 204 / 255f, 255 / 255f));
        typeColor.Add("fighting", new Color(187 / 255f, 85 / 255f, 68 / 255f));
        typeColor.Add("poison", new Color(170 / 255f, 85 / 255f, 153 / 255f));
        typeColor.Add("ground", new Color(221 / 255f, 187 / 255f, 85 / 255f));
        typeColor.Add("flying", new Color(136 / 255f, 153 / 255f, 255 / 255f));
        typeColor.Add("psychic", new Color(255 / 255f, 85 / 255f, 153 / 255f));
        typeColor.Add("bug", new Color(170 / 255f, 187 / 255f, 34 / 255f));
        typeColor.Add("rock", new Color(187 / 255f, 170 / 255f, 102 / 255f));
        typeColor.Add("ghost", new Color(102 / 255f, 102 / 255f, 187 / 255f));
        typeColor.Add("dragon", new Color(119 / 255f, 102 / 255f, 238 / 255f));
        typeColor.Add("dark", new Color(119 / 255f, 85 / 255f, 68 / 255f));
        typeColor.Add("steel", new Color(170 / 255f, 170 / 255f, 187 / 255f));
        typeColor.Add("fairy", new Color(238 / 255f, 153 / 255f, 238 / 255f));


        button = GetComponent<Button>();
        color = GetComponent<Button>().colors;
        moveText = this.GetComponentInChildren<TextMeshProUGUI>();
        
    }


    public void hoverButton()
    {
        if (buttonChoose.move1.text == moveText.text)
        {
            color.highlightedColor = typeColor[moves.moveSetP1[0].type.name]; //typeColor[string of type from move]
            button.colors = color;
            type.text = char.ToUpper(moves.moveSetP1[0].type.name[0]) + moves.moveSetP1[0].type.name.Substring(1);
            type.color = typeColor[moves.moveSetP1[0].type.name];
        }
        if(buttonChoose.move2.text == moveText.text)
        {
            color.highlightedColor = typeColor[moves.moveSetP1[1].type.name]; //typeColor[string of type from move]
            button.colors = color;
            type.text = char.ToUpper(moves.moveSetP1[1].type.name[0]) + moves.moveSetP1[1].type.name.Substring(1);
            type.color = typeColor[moves.moveSetP1[1].type.name];
        }
        if(buttonChoose.move3.text == moveText.text)
        {
            color.highlightedColor = typeColor[moves.moveSetP1[2].type.name]; //typeColor[string of type from move]
            button.colors = color;
            type.text = char.ToUpper(moves.moveSetP1[2].type.name[0]) + moves.moveSetP1[2].type.name.Substring(1);
            type.color = typeColor[moves.moveSetP1[2].type.name];
        }
        if (buttonChoose.move4.text == moveText.text)
        {
            color.highlightedColor = typeColor[moves.moveSetP1[3].type.name]; //typeColor[string of type from move]
            button.colors = color;
            type.text = char.ToUpper(moves.moveSetP1[3].type.name[0]) + moves.moveSetP1[3].type.name.Substring(1);
            type.color = typeColor[moves.moveSetP1[3].type.name];
        }
    }

    public void exitHover()
    {
        type.text = "";
    }
}
