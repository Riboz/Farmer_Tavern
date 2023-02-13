using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Plants
{
    [SerializeField]private int cooldown;
    [SerializeField] private Sprite[]CarrotSprites;
    private int length;
    
    Vector3 thePlant;
    // Start is called before the first frame update
    void Start()
    {
        length=CarrotSprites.Length;
        TheSpriteArray(length);
        for(int i=0;i<CarrotSprites.Length;i++)
        {
         seedSprite[i]=CarrotSprites[i];
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
