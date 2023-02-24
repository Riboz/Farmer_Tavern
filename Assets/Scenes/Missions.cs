using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSuccesClass : MonoBehaviour
{

   int beforeChosed=0,newChosed;
   public int [] missionSpace;
 public bool MissionSucces()
        {
         StopCoroutine(MissionCheck());
         
         StartCoroutine(MissionCheck());
         //Gorev başarılı olunca araba gidiş ekle buraya 2 saniyede
         
         return true;
        }
        public IEnumerator MissionCheck()
        {
            // yeni görev gelicek araba gelsin
            
            yield return new WaitForSeconds(2f);

            RandomMission();

            yield return new WaitForSeconds(15);
            
            // görevin süresi biter araba gider

            yield return new WaitForSeconds(2f);

            StartCoroutine(MissionCheck());
        
        }    
        
        
        public void RandomMission()
        {
            

            bool missionbool = true;
    
            int i = 0;
    
            while( missionbool )
    {
        newChosed = Random.Range(0,6);
        
        if(newChosed != beforeChosed)
        {
           missionSpace[i] = newChosed;
           i += 1;
           beforeChosed = newChosed;
           if(i == missionSpace.Length)
           {
            missionbool = false;
           }
          
           
           
        }
    }
        }
    
}
