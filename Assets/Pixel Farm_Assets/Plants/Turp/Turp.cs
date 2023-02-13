using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turp : Plants
{
     [SerializeField]private int cooldown;
    [SerializeField] private Sprite[]turpSprites;
    private int length;
    Vector3 thePlant;
    // Start is called before the first frame update
    void Start()
    {
        length=turpSprites.Length;
        TheSpriteArray(length);
        for(int i=0;i<turpSprites.Length;i++)
        {
         seedSprite[i]=turpSprites[i];
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
