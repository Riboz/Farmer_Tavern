using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyable : MonoBehaviour
{
public int Cost,Which;
public bool isAnimal; 
public Tile tile; 

 public void OnDestroy()
 {
    SaveSytem.buyables.Remove(this);
 }
 public void TileFound(Tile thisTile)
    {
        tile=thisTile;
    }
    public void Awake()
    {

    SaveSytem.buyables.Add(this);
    }
}
