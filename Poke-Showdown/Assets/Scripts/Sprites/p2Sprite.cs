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
    private bool isReady = false;

    // Start is called before the first frame update
    void Start()
    {

        setUpSpriteP2();


    }


    public void setUpSpriteP2()
    {
        randNum = pokeStatus.randNumberP2;
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
        AsyncOperationHandle<Sprite[]> spriteHandle = Addressables.LoadAssetAsync<Sprite[]>("Assets/PokeSprites/FRONT/" + randNum + ".png");
        spriteHandle.Completed += LoadSpritesWhenReady;
    }
    private void LoadSpritesWhenReady(AsyncOperationHandle<Sprite[]> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            spriteArrayP2 = handleToCheck.Result;
        }

        isReady = true;
    }



    private void Update()
    {

        if (isReady)
        {
            if (spriteRenderer.sprite == null)
            {
                spriteRenderer.sprite = spriteArrayP2[0];
            }
            StartCoroutine(UpdateAnimation());



        }


    }

    IEnumerator UpdateAnimation()
    {
        isReady = false;
        spriteRenderer.sprite = spriteArrayP2[currentSprite];
        currentSprite++;
        if (currentSprite >= spriteArrayP2.Length - 1)
        {
            currentSprite = 0;
        }
        yield return new WaitForSeconds(0.1f);
        isReady = true;
    }
}
