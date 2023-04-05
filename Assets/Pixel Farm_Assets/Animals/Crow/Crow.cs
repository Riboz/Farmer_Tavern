using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Crow : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem crowFeather;
    public GameObject plant;
    public bool stay = false,direction,death=false;
    public float speed;
    void Start()
    {
       if(plant == null) plant=GameObject.FindGameObjectWithTag("Buyable");
       StartCoroutine(CheckEverytime());
       
    }
    IEnumerator DestroyThePlant()
    {
        yield return new WaitForSeconds(1f);
        stay = true;
        yield return new WaitForSeconds(2f);
        //gak desin
        if(plant.GetComponent<Animal>()!=null)
        {
            Destroy(plant.GetComponent<Animal>().spawned_Item);
             
        }
        Destroy(plant);
        yield return new WaitForSeconds(1f);
        if(plant == null) plant=GameObject.FindGameObjectWithTag("Buyable");
        yield break;
    }
public IEnumerator CheckEverytime()
{
    while(true)
    {
        yield return new WaitForSeconds(0.4f);
    if(!death)
             {
                if(!direction) transform.DOScale(new Vector2(-1.1f,1.1f),0.3f);
                else    transform.DOScale(new Vector2(1.1f,1.1f),0.3f);
             }
        if(!stay && plant   ==  null)
        {
            plant=GameObject.FindGameObjectWithTag("Buyable");
        }
        
        yield return new WaitForSeconds(0.4f);
        if(!death)
           {
                if(!direction)transform.DOScale(new Vector2(-0.9f,0.9f),0.3f);
                else transform.DOScale(new Vector2(0.9f,0.9f),0.3f);
           }
    }
        
    
}
    // Update is called once per frame
    void FixedUpdate()
    {
        if(!stay && plant!=null)
        {
        transform.position= Vector2.MoveTowards(this.transform.position,plant.transform.position,speed);
        if(transform.position.x-plant.transform.position.x>0)
        {
             direction=false;
        }
        else
        {
            direction=true;
        }
        }
    }
    void OnTriggerEnter2D(Collider2D plants)
    {
        if(plant == plants.transform.gameObject)
        {
            StartCoroutine(DestroyThePlant());
           
        }
        if(plants.gameObject.tag=="Player")
        {
            stay = true;
            death=true;
            transform.DOScale(Vector2.zero,0.8f);
            ParticleSystem feath=Instantiate(crowFeather,this.transform.position,Quaternion.identity);
            Destroy(feath,3f);
            GetComponent<SpriteRenderer>().DOFade(0,0.8f);
            
            Destroy(this.gameObject,1f);


        }

    }
    void OnTriggerExit2D(Collider2D plants)
    {
        if(plant == plants.transform.gameObject)
        {
       
            Debug.Log("Calis köpek");
            stay = false;
        }

    }
}
