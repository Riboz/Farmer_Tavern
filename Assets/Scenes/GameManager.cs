using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
  [Header("Inventory")]
  public int Gold,currentCost;
  public int [] inventoryspace;
  
  
  [Header("UI")]
  public Text Gold_Display;
  public Button changeOpButton;
  [Header("Others")]
  public GameObject grid;
  public CustomCursor customCursor;
  public Tile[] tiles;
  Buyable buyable_place;
  DOTweenManager dot;
  [SerializeField] private bool inArea,changeOpinion;
 
  public static bool canBuy;
  
  void Start()
  {
    //ınventorye egg coton mil carrot fln koy
    dot=GameObject.FindWithTag("Dot").GetComponent<DOTweenManager>();
    
  }
 

    // Update is called once per frame
    void Update()
{
        Gold_Display.text=Gold.ToString();
    
     if(inArea && !changeOpinion)
    {  
        if(Input.GetMouseButtonDown(0) && buyable_place != null)
        {
            Tile nearestTile = null;
            float nearestDistance = float.MaxValue;
            foreach(Tile tile in tiles)
            {
                float dist = Vector2.Distance(tile.transform.position,Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if(dist<nearestDistance)
                {
                    nearestDistance = dist;
                    nearestTile = tile;
                }
            }
            if(nearestTile.isOccupied == false)
            {
                buyable_place.TileFound(nearestTile);
                if(buyable_place.GetComponent<Buyable>().isAnimal)
                {
                    Instantiate(buyable_place , nearestTile.transform.position + new Vector3(0,0.2f,0) , Quaternion.identity);
                }
                else
                {
                    Instantiate(buyable_place , nearestTile.transform.position , Quaternion.identity);
                }
        
                buyable_place = null;
                nearestTile.isOccupied = true;
                grid.SetActive(false);
                customCursor.gameObject.SetActive(false);
                Cursor.visible = true;
                dot.shopButton.gameObject.SetActive(true);
                changeOpButton.gameObject.SetActive(false);
                
            }
        }
    }
     if(changeOpinion)
    {
       
        buyable_place = null;
        grid.SetActive(false);
        customCursor.gameObject.SetActive(false);
        Cursor.visible = true;
        dot.shopButton.gameObject.SetActive(true);
        changeOpinion = false;
        
    }
     else return;
}
    public void BuyBuyable(Buyable buyable)
    {
        if(Gold >= buyable.Cost)
        {
            currentCost=buyable.Cost;
            customCursor.gameObject.SetActive(true);
            customCursor.GetComponent<SpriteRenderer>().sprite = buyable.GetComponent<SpriteRenderer>().sprite;
            buyable_place = buyable;
            grid.SetActive(true);
            Gold -= buyable.Cost;
            changeOpButton.gameObject.SetActive(true);

        }
        else 
        {
            dot.shopButton.gameObject.SetActive(true);
        }
    }
    public void Adding(string type)
    {
       if(type == "Egg")
       {
            inventoryspace[0] += 1;
       }
       else if(type == "Milk")
       {
            inventoryspace[1] += 1;
       }
       else if(type == "Cotton")
       {
            inventoryspace[2] += 1;
       }
        else if(type == "Tomato")
       {
            inventoryspace[3] += Random.Range(1,4);
       }
       else if(type == "Carrot")
       {
            inventoryspace[4] += Random.Range(1,4);
       }
        else if(type == "Turp")
       {
            inventoryspace[5] += Random.Range(1,4);
       }
       else if(type == "Potato")
       {
            inventoryspace[6] += Random.Range(1,4);
       }


    }
    public void OnTriggerEnter2D(Collider2D Mause)
    {
        if(Mause.gameObject.tag == "Cursor")
        {
            inArea=true;
            Debug.Log("In");
        }
      
     
    }
    public void OnTriggerExit2D(Collider2D Mause)
    {
        if(Mause.gameObject.tag == "Cursor")
        {
            inArea=false;
            Debug.Log("Out");
        }
         
     
    }
    public void ChangeOpinion()
    {
        changeOpinion=true;
        Gold+=currentCost;
        changeOpButton.gameObject.SetActive(false);
    }
    
}
