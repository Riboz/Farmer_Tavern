using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : Buyable
{
    public Sprite[] seedSprite;
    bool canHarvest;
    public bool active(int plantCooldown)
    {
        StartCoroutine(Growth(plantCooldown));
        return true;
    }
    public IEnumerator Growth(int plantCooldown)
    {

     float Important = plantCooldown/seedSprite.Length;
     this.GetComponent<SpriteRenderer>().sprite=seedSprite[0];

     for(int i=0;i<seedSprite.Length;i++)
     {

        yield return new WaitForSeconds(Important);
        this.GetComponent<SpriteRenderer>().sprite=seedSprite[i];
        Debug.Log(""+i);
     }
     Debug.Log("oldu");
     canHarvest=true;
     yield break;
    
    }

    public void Takes_Items()
   {
        if(canHarvest)
        {
            Destroy(this);
            // random bir sayıda o türden bitki versin
        }
   }

}
