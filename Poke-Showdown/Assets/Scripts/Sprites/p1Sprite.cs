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

    private bool isReady = false;
    // Start is called before the first frame update
    void Start()
    {
        
        randNum = pokeStatus.randNumberP1;
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
        AsyncOperationHandle<Sprite[]> spriteHandle = Addressables.LoadAssetAsync<Sprite[]>("Assets/PokeSprites/BACK/" + randNum + ".png");
        spriteHandle.Completed += LoadSpritesWhenReady;

    }
    

    void LoadSpritesWhenReady (AsyncOperationHandle<Sprite[]> handleToCheck)  
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            spriteArrayP1 = handleToCheck.Result;
        }

        isReady = true;

    }

    private void Update()
    {

        if (isReady)
        {
            if (spriteRenderer.sprite == null)
            {
                spriteRenderer.sprite = spriteArrayP1[0];
            }
            StartCoroutine(UpdateAnimation());

        }

    }

    IEnumerator UpdateAnimation()
    {
        isReady = false;
        spriteRenderer.sprite = spriteArrayP1[currentSprite];
        currentSprite++;
        if (currentSprite >= spriteArrayP1.Length - 1)
        {
            currentSprite = 0;
        }
        yield return new WaitForSeconds(0.1f);
        isReady = true;
    }

}
