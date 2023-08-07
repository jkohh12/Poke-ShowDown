using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeEffectiveness : MonoBehaviour
{
    
    // Start is called before the first frame update
    public IDictionary<string, string[]> superEffective = new Dictionary<string, string[]>();

    public IDictionary<string, string[]> notEffective = new Dictionary<string, string[]>();

    public IDictionary<string, string[]> noEffect = new Dictionary<string, string[]>();
    void Start()
    {
    
        superEffective.Add("normal", new string[] { });
        superEffective.Add("fire", new string[] { "ice", "grass", "steel" });
        superEffective.Add("water", new string[] { "fire", "ground", "rock" });
        superEffective.Add("electric", new string[] { "water", "flying" });
        superEffective.Add("grass", new string[] { "water", "ground", "rock" });
        superEffective.Add("ice", new string[] { "grass", "ground", "flying", "dragon" });
        superEffective.Add("fighting", new string[] { "normal", "ice", "rock", "dark", "steel" });
        superEffective.Add("poison", new string[] { "grass", "fairy" });
        superEffective.Add("ground", new string[] { "fire", "electric", "poison", "rock", "steel" });
        superEffective.Add("fairy", new string[] { "fighting", "dragon", "dark" });
        superEffective.Add("steel", new string[] { "ice", "rock", "fairy" });
        superEffective.Add("dark", new string[] { "psychic", "ghost" });
        superEffective.Add("dragon", new string[] { "dragon" });
        superEffective.Add("ghost", new string[] { "psychic", "ghost" });
        superEffective.Add("rock", new string[] { "fire", "ice", "flying", "bug" });
        superEffective.Add("bug", new string[] { "grass", "psychic", "dark" });
        superEffective.Add("psychic", new string[] { "fighting", "poison" });
        superEffective.Add("flying", new string[] { "grass", "fighting", "bug" });

     
        notEffective.Add("normal", new string[] { "rock", "steel" });
        notEffective.Add("fire", new string[] { "fire", "water", "rock" });
        notEffective.Add("water", new string[] { "water", "grass", "dragon" });
        notEffective.Add("electric", new string[] { "electric", "grass", "dragon" });
        notEffective.Add("grass", new string[] { "fire", "grass", "poison", "flying", "bug", "dragon", "steel" });
        notEffective.Add("ice", new string[] { "fire", "water", "ice", "steel" });
        notEffective.Add("fighting", new string[] { "poison", "flying", "psychic", "bug", "fairy" });
        notEffective.Add("poison", new string[] { "poison", "ground", "rock", "ghost" });
        notEffective.Add("ground", new string[] { "grass", "bug" });
        notEffective.Add("fairy", new string[] { "poison", "steel" });
        notEffective.Add("steel", new string[] { "fire", "fighting", "ground" });
        notEffective.Add("dark", new string[] { "fighting", "bug", "fairy" });
        notEffective.Add("dragon", new string[] { "ice", "dragon", "fairy" });
        notEffective.Add("ghost", new string[] { "ghost", "dark" });
        notEffective.Add("rock", new string[] { "water", "grass", "fighting", "ground", "steel" });
        notEffective.Add("bug", new string[] { "fire", "flying", "rock" });
        notEffective.Add("psychic", new string[] { "bug", "ghost", "dark" });
        notEffective.Add("flying", new string[] { "electric", "ice", "rock" });

        noEffect.Add("normal", new string[] { "ghost" });
        noEffect.Add("fire", new string[] {});
        noEffect.Add("water", new string[] {});
        noEffect.Add("electric", new string[] { "ground"});
        noEffect.Add("grass", new string[] {});
        noEffect.Add("ice", new string[] {});
        noEffect.Add("fighting", new string[] { "ghost" });
        noEffect.Add("poison", new string[] { "steel" });
        noEffect.Add("ground", new string[] { "flying" });
        noEffect.Add("flying", new string[] { });
        noEffect.Add("psychic", new string[] { "dark" });
        noEffect.Add("bug", new string[] { });
        noEffect.Add("rock", new string[] { });
        noEffect.Add("ghost", new string[] { "normal" });
        noEffect.Add("dragon", new string[] { "fairy" });
        noEffect.Add("dark", new string[] { });
        noEffect.Add("steel", new string[] { });
        noEffect.Add("fairy", new string[] { });
 
        
    }


}
