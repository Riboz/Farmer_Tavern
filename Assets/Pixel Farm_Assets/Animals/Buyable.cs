using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyable : MonoBehaviour
{
public int Cost;
public bool isAnimal; 
 public Tile tile; 
 public void TileFound(Tile thisTile)
    {
        tile=thisTile;
    }
}
