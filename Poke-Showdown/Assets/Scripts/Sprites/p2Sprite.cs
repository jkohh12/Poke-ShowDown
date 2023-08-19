using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class p2Sprite : MonoBehaviour
{
    [SerializeField] public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArrayP2;

    [SerializeField] PokeStatusTeam2 pokeStatus;
    private int randNum;

    private int currentSprite = 0;


    // Start is called before the first frame update
    public void setUpSpriteP2(int rand)
    {

        //use for multiple pokemon // setUpSpriteP2(); 
     
        /*        string newRandNum = randNum.ToString();
                if (randNum < 10)
                {
                    newRandNum = "00" + randNum.ToString();
                }
                else if (randNum < 100)
                {
                    newRandNum = "0" + randNum.ToString();
                }*/
        //Debug.Log(randNum);
        AsyncOperationHandle<Sprite[]> spriteHandle = Addressables.LoadAssetAsync<Sprite[]>("Assets/PokeSprites/FRONT/" + rand + ".png");
        spriteHandle.Completed += LoadSpritesWhenReady;

    }


    private void LoadSpritesWhenReady(AsyncOperationHandle<Sprite[]> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            spriteArrayP2 = handleToCheck.Result;
        }

        StartCoroutine(UpdateAnimation());
    }



    IEnumerator UpdateAnimation()
    {
   
        spriteRenderer.sprite = spriteArrayP2[currentSprite];
        currentSprite++;
        if (currentSprite >= spriteArrayP2.Length)
        {
            currentSprite = 0;
            spriteRenderer.sprite = spriteArrayP2[currentSprite];
        }
        yield return new WaitForSeconds(0.05f);

        StartCoroutine(UpdateAnimation());
    }
}
