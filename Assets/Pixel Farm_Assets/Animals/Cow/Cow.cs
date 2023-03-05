using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Animal
{
    
    [SerializeField]private int cooldown_Drop_cow;
    [SerializeField]private GameObject milk;
    [SerializeField]private AudioClip Cow_Sound;
    Vector3 The_cow;
    // Start is called before the first frame update
    void Start()
    {
        The_cow=this.transform.position+new Vector3(0,0.35f,0);
        active(cooldown_Drop_cow,milk,Cow_Sound,The_cow,"Milk");
        
    }
    
    void OnTriggerEnter2D(Collider2D Player)
    {
        if(Player.gameObject.CompareTag("Player"))
        {
           Takes_Items();
        }

    }
}
