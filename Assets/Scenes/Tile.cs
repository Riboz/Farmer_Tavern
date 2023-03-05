using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
private SpriteRenderer Rend;
public bool isOccupied;
public Color RedColor,GreenColor;
private void Start()
{
    Rend=GetComponent<SpriteRenderer>();
}
void Update()
{
    if(isOccupied == true)
    {
        Rend.color = RedColor;

    }
    else
    {
    Rend.color=GreenColor;
    }
}
void OnTriggerEnter2D(Collider2D coll)
{
    if(coll.gameObject.tag == "Buyable")
    {
        Debug.Log("ALiverli");
        isOccupied=true;
    }
}
void OnTriggerExit2D(Collider2D coll)
{
    if(coll.gameObject.tag == "Buyable")
    {
        Debug.Log("ALiverli");
        isOccupied = false;
    }
}

}
