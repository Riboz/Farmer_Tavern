using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patato : Plants
{
     [SerializeField]private int cooldown;
    [SerializeField] private Sprite[]PatatoSprites;
    private int length;
    
    Vector3 thePlant;
    // Start is called before the first frame update
    void Start()
    {
        length=PatatoSprites.Length;
        TheSpriteArray(length);

        for(int i=0;i<PatatoSprites.Length;i++)
        {
         seedSprite[i]=PatatoSprites[i];
        }
       
        active(cooldown,"Potato");
    }
    void OnTriggerEnter2D(Collider2D Player)
    {
        if(Player.gameObject.CompareTag("Player"))
        {
           Takes_Items();
        }
        
    }
}
