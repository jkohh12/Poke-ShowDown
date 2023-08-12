using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.Networking;
public class P2Moves : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PokeStatusTeam2 pokemon;

    public List<moveStats> movePoolAttackP2 = new List<moveStats>();
    public List<moveStats> moveSetP2;

    private int randomNum;

    public int moveCounterP2 = 0;

    public bool poolFullP2;

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Ailment
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Category
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class ContestCombos
    {
        public Normal normal { get; set; }
        public Super super { get; set; }
    }

    public class ContestEffect
    {
        public string url { get; set; }
    }

    public class ContestType
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class DamageClass
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class EffectEntry
    {
        public string effect { get; set; }
        public Language language { get; set; }
        public string short_effect { get; set; }
    }

    public class FlavorTextEntry
    {
        public string flavor_text { get; set; }
        public Language language { get; set; }
        public VersionGroup version_group { get; set; }
    }

    public class Generation
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Language
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class LearnedByPokemon
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Machine
    {
        public Machine machine { get; set; }
        public VersionGroup version_group { get; set; }
    }

    public class Machine2
    {
        public string url { get; set; }
    }

    public class Meta
    {
        public Ailment ailment { get; set; }
        public int? ailment_chance { get; set; }
        public Category category { get; set; }
        public int? crit_rate { get; set; }
        public int? drain { get; set; }
        public int? flinch_chance { get; set; }
        public int? healing { get; set; }
        public object max_hits { get; set; }
        public object max_turns { get; set; }
        public object min_hits { get; set; }
        public object min_turns { get; set; }
        public int? stat_chance { get; set; }
    }

    public class Name
    {
        public Language language { get; set; }
        public string name { get; set; }
    }

    public class Normal
    {
        public List<UseAfter> use_after { get; set; }
        public object use_before { get; set; }
    }

    public class moveStats
    {
        public int? accuracy { get; set; }
        public ContestCombos contest_combos { get; set; }
        public ContestEffect contest_effect { get; set; }
        public ContestType contest_type { get; set; }
        public DamageClass damage_class { get; set; }
        public object effect_chance { get; set; }
        public List<object> effect_changes { get; set; }
        public List<EffectEntry> effect_entries { get; set; }
        public List<FlavorTextEntry> flavor_text_entries { get; set; }
        public Generation generation { get; set; }
        public int? id { get; set; }
        public List<LearnedByPokemon> learned_by_pokemon { get; set; }
        public List<Machine> machines { get; set; }
        public Meta meta { get; set; }
        public string name { get; set; }
        public List<Name> names { get; set; }
        public List<object> past_values { get; set; }
        public int? power { get; set; }
        public int? pp { get; set; }
        public int? priority { get; set; }
        public List<object> stat_changes { get; set; }
        public SuperContestEffect super_contest_effect { get; set; }
        public Target target { get; set; }
        public Type type { get; set; }
    }

    public class Super
    {
        public object use_after { get; set; }
        public object use_before { get; set; }
    }

    public class SuperContestEffect
    {
        public string url { get; set; }
    }

    public class Target
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Type
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class UseAfter
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class VersionGroup
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    private void Start()
    {

        //for multiple pokemon //setUpMoveP2();
        moveCounterP2 = 0;
        moveSetP2 = new List<moveStats>();
        movePoolAttackP2 = new List<moveStats>();
        for (int i = 0; i < pokemon.movesGlobalP2.Count; i++)
        {
            StartCoroutine(GetRequest("https://pokeapi.co/api/v2/move/" + pokemon.movesGlobalP2[i].move.name));

        }

    }

/*    public void setUpMoveP2()
    {

    }
*/
/*    private void Start()
    {
        for(int i = 0; i < pokemon.movesGlobal.Count; i++)
        {
            StartCoroutine(GetRequest("https://pokeapi.co/api/v2/move/" + pokemon.movesGlobal[i].move.name));
        }

    }*/
    private IEnumerator GetRequest(string uri)
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
            
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError: //connection error or dataprocessing error, log an error in console
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(string.Format("Something went wrong: {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:
                    moveStats moveStat = JsonConvert.DeserializeObject<moveStats>(webRequest.downloadHandler.text);

                    //moveStats test = moveStat;
                    int? movePower = moveStat.power;
                    poolFullP2 = false;

                    if (movePower.HasValue)
                    {
                        movePoolAttackP2.Add(moveStat);
                      
                    }

                    poolFullP2 = true;


                    break;

            }
            
           
            
        }
    }

    // Update is called once per frame
    private void Update()
    {

        if (poolFullP2 && moveCounterP2 <= 3)
        {
            randomNum = Random.Range(0, movePoolAttackP2.Count - 1); //number in between 0 and end of movePoolAttack list
            moveSetP2.Add(movePoolAttackP2[randomNum]);
            //Debug.Log("Player 2" + moveSetP2[moveCounterP2].name);
            moveCounterP2++;
        }


    }
}
