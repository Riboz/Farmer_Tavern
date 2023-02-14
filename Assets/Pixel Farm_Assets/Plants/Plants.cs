using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : Buyable
{
    public Sprite[] seedSprite;
    bool canHarvest;
    string Type;
    GameManager gameManager;
   
    public void TheSpriteArray(int length)
    {
        seedSprite=new Sprite[length];
    }
   
    public bool active(int plantCooldown,string type)
    {
       
        gameManager=GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Type=type;
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

            tile.GetComponent<Tile>().isOccupied=false;
            gameManager.Adding(Type);
            Destroy(this.gameObject);

            // üstünde olduğu tile i tekrardan duzelt
            // random bir sayıda o türden bitki versin
        }
   }

}
