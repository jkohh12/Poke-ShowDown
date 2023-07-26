using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class p1Sprite : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public Sprite sprite;

    [SerializeField] PokeStatus pokeStatus;
    private int randNum;
    // Start is called before the first frame update
    void Start()
    {
        
        randNum = pokeStatus.randNumberPoke1;
        string newRandNum = randNum.ToString();
        if(randNum < 10)
        {
            newRandNum = "00" + randNum.ToString();
        }
        else if (randNum < 100)
        {
            newRandNum = "0" + randNum.ToString();
        }
        Debug.Log(randNum);
        AsyncOperationHandle<Sprite> spriteHandle = Addressables.LoadAssetAsync<Sprite>("Assets/PokemonSprites/NORMAL/BACK/GIF/" + newRandNum + ".gif");
        spriteHandle.Completed += LoadSpritesWhenReady;

    }

    void LoadSpritesWhenReady (AsyncOperationHandle<Sprite> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            sprite = handleToCheck.Result;
        }

        spriteRenderer.sprite = sprite;

    }



}
