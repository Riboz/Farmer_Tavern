using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : Animal
{
    [SerializeField]private int cooldown_Drop_sheep;
    [SerializeField]private GameObject Cotton;
    [SerializeField]private AudioClip sheep_Sound;
    Vector3 the_Sheep;
    // Start is called before the first frame update
    void Start()
    {
        the_Sheep=this.transform.position+new Vector3(0,0.25f,0);
        active(cooldown_Drop_sheep,Cotton,sheep_Sound,the_Sheep);
    }
    void OnTriggerEnter2D(Collider2D Player)
    {
        if(Player.gameObject.CompareTag("Player"))
        {
           Takes_Items();
        }
    }
}
