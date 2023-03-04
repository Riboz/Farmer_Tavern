


using UnityEngine;

[System.Serializable]

public class BuyableData
{
public float[] position = new float[3];

public int which;



public BuyableData(Buyable buyable)
{ 

    which=buyable.Which;
  
    position[0] = buyable.transform.position.x;
    position[1] = buyable.transform.position.y;
    position[2] = buyable.transform.position.z;
   

}



}







