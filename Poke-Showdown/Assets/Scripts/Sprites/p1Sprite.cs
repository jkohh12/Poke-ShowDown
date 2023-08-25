using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class p1Sprite : MonoBehaviour
{

  
    [SerializeField] public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArrayP1;

    [SerializeField] PokeStatusTeam1 pokeStatus;
    private int randNum;

    private int currentSprite = 0;


    // Start is called before the first frame update
    public void setUpSpriteP1(int rand)
    {
       
/*        string newRandNum = randNum.ToString();
        if(randNum < 10)
        {
            newRandNum = "00" + randNum.ToString();
        }
        else if (randNum < 100)
        {
            newRandNum = "0" + randNum.ToString();
        }*/
        //Debug.Log(randNum);
        AsyncOperationHandle<Sprite[]> spriteHandle = Addressables.LoadAssetAsync<Sprite[]>("Assets/PokeSprites/BACK/" + rand + ".png");
        spriteHandle.Completed += LoadSpritesWhenReady;

    }
    

    void LoadSpritesWhenReady (AsyncOperationHandle<Sprite[]> handleToCheck)  
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            spriteArrayP1 = handleToCheck.Result;
        }

        StartCoroutine(UpdateAnimation());

    }


    IEnumerator UpdateAnimation()
    {
        
        spriteRenderer.sprite = spriteArrayP1[currentSprite];
        currentSprite++;
        if (currentSprite >= spriteArrayP1.Length || SpriteRenderer.ReferenceEquals(spriteRenderer.sprite, null)) 
        {
            currentSprite = 0;
            spriteRenderer.sprite = spriteArrayP1[currentSprite];
        }
        yield return new WaitForSeconds(0.1f);
        
        StartCoroutine(UpdateAnimation());
    }

}
