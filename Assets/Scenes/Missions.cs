using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSuccesClass : MonoBehaviour
{
 public bool MissionSucces()
        {
         StopCoroutine(MissionCheck());
         
         StartCoroutine(MissionCheck());
         // random bir şekilde bir sayı seçer o sayıya denk gelen araba gameobjectini çağırır gerekli yere koyar ve bir süre başlatır o süreyi geçince araba yok olur 
         //ve enumratorun sonunda yine mission voidi çağırılır ayrıca görevi yapınca da yine otomatik aynı şeyler olur.
         return true;
        }
        public IEnumerator MissionCheck()
        {
            yield return new WaitForSeconds(300);
            StartCoroutine(MissionCheck());
        
        }    
}
