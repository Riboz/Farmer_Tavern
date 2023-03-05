using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{
    
    [SerializeField]private int cooldown_Drop_chicken;
    [SerializeField]private GameObject egg;
    [SerializeField]private AudioClip chicken_Sound;
    Vector3 The_Chicken;
    // Start is called before the first frame update
    void Start()
    {
        The_Chicken=this.transform.position+new Vector3(0,0.25f,0);
        active(cooldown_Drop_chicken,egg,chicken_Sound,The_Chicken,"Egg");
    }
    void OnTriggerEnter2D(Collider2D Player)
    {
        if(Player.gameObject.CompareTag("Player"))
        {
           Takes_Items();
        }
         
    }
   
}
