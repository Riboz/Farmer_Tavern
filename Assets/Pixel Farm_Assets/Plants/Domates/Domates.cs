using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domates : Plants
{
   
    [SerializeField]private int cooldown;
    [SerializeField] private Sprite[]domatesSprites;
    
    Vector3 thePlant;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<domatesSprites.Length;i++)
        {
         seedSprite[i]=domatesSprites[i];
        }
       
        active(cooldown);
    }
    void OnTriggerEnter2D(Collider2D Player)
    {
        if(Player.gameObject.CompareTag("Player"))
        {
           Takes_Items();
        }
    }
   
}
