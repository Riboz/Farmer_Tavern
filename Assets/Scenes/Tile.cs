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
    if(isOccupied== true)
    {
        Rend.color=RedColor;

    }
    else
    {
    Rend.color=GreenColor;
    }
}
}
