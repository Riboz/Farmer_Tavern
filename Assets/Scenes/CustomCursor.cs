using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
   public GameObject deleteObj;
    public bool deleteOpen=false,Buttonmode;
    public Sprite delete;
    public Tile tile;
     GameManager gamemanager;
    
    void Update()
    {
       Vector2 mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);

       this.transform.position=mousePosition; 
     
        

       if(Input.GetMouseButtonDown(0)&&deleteOpen&&deleteObj!=null)
       {
        if(deleteObj.GetComponent<Animal>()!=null)
        {
              Destroy(deleteObj.GetComponent<Animal>().spawned_Item);
        }
      
        Destroy(deleteObj);
         tile.isOccupied=false;
            tile=null;
        // partikül efekti eklenebilinir
       
     
        
       }
    }
    public void Delete()
    {
        Buttonmode=!Buttonmode;
        if(Buttonmode)
        {
            deleteOpen=true; 
            gamemanager= GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            gamemanager.grid.gameObject.SetActive(true);
            this.GetComponent<SpriteRenderer>().sprite=delete;
        }        
       else
       {
        deleteOpen=false;
        this.GetComponent<SpriteRenderer>().sprite=null;
        gamemanager.grid.gameObject.SetActive(false);
       }
          
            
        
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Buyable")
        {
            deleteObj=collider.gameObject;
            
        }
        if(collider.gameObject.tag=="Tile")
        {
            tile=collider.gameObject.GetComponent<Tile>();
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Buyable")
        {
            deleteObj=null;
        }

       

    }
}
