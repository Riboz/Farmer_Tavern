using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MissionSuccesClass
{
  [Header("Inventory")]
  public int Gold,currentCost,Mission_array_Area;
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
  [SerializeField] private bool cantDo,inArea,changeOpinion;
  public bool[] missioncomp;
  public static bool canBuy;
  
  void Start()
  {
    //ınventorye egg coton mil carrot fln koy
    dot=GameObject.FindWithTag("Dot").GetComponent<DOTweenManager>();
    
    StartCoroutine(MissionChecking());
    
    
    
  }
  public IEnumerator MissionChecking()
        {
                // daha iyi bir teknik bulmaya çalış
        if(missioncomp[0] && inventoryspace[ missionSpace [0] ] != 0)
        {
            Debug.Log("Bu var");
            missioncomp[0] = false;
            inventoryspace[missionSpace[0]] -= 1;
        }
                yield return new WaitForSeconds(0.1f);
         if(missioncomp[1] && inventoryspace[ missionSpace [1] ] != 0)
        {
            Debug.Log("Bu var");
            missioncomp[1] = false;             
            inventoryspace[missionSpace[1]] -=1 ;
        }
                yield return new WaitForSeconds(0.1f);
         if(missioncomp[2] && inventoryspace[ missionSpace [2] ] != 0)
        {
            Debug.Log("Bu var");
            missioncomp[2] = false;
            inventoryspace[missionSpace[2]] -= 1;
        }
                yield return new WaitForSeconds(0.1f);
         if(missioncomp[3] && inventoryspace[ missionSpace [3] ] != 0)
        {
            Debug.Log("Bu var");
            missioncomp[3] = false;
            inventoryspace[missionSpace[3]] -= 1;
        }

            int MisionCount=0;
           for(int i = 0 ; i < missioncomp.Length ; i++)
           {
                if(missioncomp[i] == false)
                {
                    MisionCount += 1;
                }
                if(MisionCount == 4)
                {
                    for(int x = 0 ; x < missioncomp.Length ; x++)
                    {
                        missioncomp[x] = true;
                    }
                     //Gorev başarılı olunca araba gidiş ekle buraya
                      Debug.Log("becerdi");
                    yield return new WaitForSeconds(3f);
                    MissionSucces();
                   
                }
           }
          
            yield return new WaitForSeconds(1f);
            StartCoroutine(MissionChecking());
        
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
            inventoryspace[3] += 1;
       }
       else if(type == "Carrot")
       {
            inventoryspace[4] += 1;
       }
        else if(type == "Turp")
       {
            inventoryspace[5] += 1;
       }
       else if(type == "Potato")
       {
            inventoryspace[6] += 1;
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
