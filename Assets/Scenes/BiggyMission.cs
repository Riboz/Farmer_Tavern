using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggyMission : MonoBehaviour
{
   public Inventory inventory;
   public int[] RandomItem=new int[3];
   public void Start()
   {
    inventory=GameObject.FindGameObjectWithTag("inventory").GetComponent<Inventory>();

   }

   // rastgele bir random sistem belirler oradaki itemlerden belirli sayıda seçilmesini ister vıttırı zıttırı 

}
