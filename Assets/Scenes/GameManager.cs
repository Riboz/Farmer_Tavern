using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public static GameObject[] Inventory;
  public GameObject[] Egg,Cotton,Milk,Carrot,Tomato,Potato,Turp;
  public int Gold;
  public Text Gold_Display;
  public GameObject grid;
  public CustomCursor customCursor;

public Tile[] tiles;
  Buyable buyable_place;
  
  

    // Update is called once per frame
    void Update()
    {
        Gold_Display.text=Gold.ToString();
    if(Input.GetMouseButtonDown(0)&& buyable_place!=null)
    {
        Tile nearestTile=null;
        float nearestDistance=float.MaxValue;
        foreach(Tile tile in tiles)
        {
            float dist=Vector2.Distance(tile.transform.position,Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if(dist<nearestDistance)
            {
                nearestDistance=dist;
                nearestTile=tile;
            }
        }
        if(nearestTile.isOccupied==false)
        {
        if(buyable_place.GetComponent<Buyable>().isAnimal){Instantiate(buyable_place,nearestTile.transform.position+new Vector3(0,0.2f,0),Quaternion.identity);}
        else{Instantiate(buyable_place,nearestTile.transform.position,Quaternion.identity);}
        buyable_place=null;
        nearestTile.isOccupied=true;
        grid.SetActive(false);
        customCursor.gameObject.SetActive(false);
        Cursor.visible=true;
        }
    }
    }
    public void BuyBuyable(Buyable buyable)
    {
        if(Gold>=buyable.Cost)
        {
         customCursor.gameObject.SetActive(true);
         customCursor.GetComponent<SpriteRenderer>().sprite=buyable.GetComponent<SpriteRenderer>().sprite;
         buyable_place=buyable;
         grid.SetActive(true);
         Gold-=buyable.Cost;

        }
    }
}
