using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Tüm Animal objelerinde olucak olan class
public class Animal : MonoBehaviour
{
    [Header("Animal animation")]
    Animator animator;

   [Header("Animal_Voice")]
    AudioSource animal_Audiosource;
    AudioClip animal_Audioclip;

   [Header("Animal Dropping")]
   int cooldown_Drop,dropped_item_Count;
   GameObject spawned_Item,spawning_Item;

   [Header("animal is active ?")]
   bool drop_Cantook,  active_Animal;
   // private Player player;

   // alt classta active bool methodunun içini istenilen değerlerle doldurup çalıştır
    public bool active(int animal_cooldown_drop,GameObject drop_Item,AudioClip audio_animal,Vector3 AnimalT)
    {
               
        // methodda Doldurulan değerler gerekli olan coroutinlere aktar ve corotinleri çalıştır

        //

        // player=gameobject.findobjectwithtaq("Player");

        //

        StartCoroutine(Animal_Drop(animal_cooldown_drop,drop_Item,AnimalT));   

      //  StartCoroutine(Animal_Voice(audio_animal));

        // eğer 54. satır çalışmazsa buranın altına bak
        return true;
    
    }
    IEnumerator Animal_Drop(int animal_cooldown_drop,GameObject drop_Item,Vector3 AnimalT)
   {
        // parametreleri  eşitliyor
        cooldown_Drop=animal_cooldown_drop;

        spawning_Item=drop_Item;
        // bir timer yaptım cooldowna ulaşana kadar 1 saniye arayla timeri 1 arttırıyor sonra istenilen cooldowna gelince işlem yapıp timeri 0 a döndürüp tekrar ediyor
        for(int Timer=0;Timer<=cooldown_Drop;Timer++)
        {
           yield return new WaitForSeconds(1f);

            if(Timer==cooldown_Drop)
            {
                //itemini droplasın transfrom positionunu_ayarlarsın
               
                    if(dropped_item_Count<1)
                    {
                      dropped_item_Count+=1;
                      spawned_Item=Instantiate(spawning_Item,AnimalT,Quaternion.identity);
                      drop_Cantook=true;
                    }
                    
                // hayvanın loot functionu açılsın
                StartCoroutine(Animal_Drop(cooldown_Drop,drop_Item,AnimalT));
            }
        }
   }
   
   public void Takes_Items()
   {
        if(drop_Cantook)
        {
            Destroy(spawned_Item);
            dropped_item_Count=0;
            drop_Cantook=false;
            //forla dizinin null una eklesin
            
            //player.Earn_What(bu bir dizidir)+=egg;
        }
   }
  // ineğin olduğu gridi Otomatik olarak bulan bir function yarat ve bu functionu activein içine koy sonrasında ise 
  // ineğin olduğa gride tıklanıldığında inekdeki (animallardaki) Alınmaya hazır olan itemler bize gelsin ke gelirken ineğin altındaki item gitsin;
  // bunun için bütün animallar playere bağlı olmalı vb vb




    IEnumerator Animal_Voice(AudioClip audio_animal)
    {
        // alt classdan alınan asıl hayvanın audio clipi eşleniyor
        active_Animal=true;
        // eğer yanlı çalışırsa buraya (active_animal=true;) ve 31. satırdaki retun active_animal=true yu sil düz return true yap
        animal_Audioclip=audio_animal;

        while(active_Animal)
        {
            //4-9 saniyeler arasında ineği bağırttırıyor
            yield return new WaitForSeconds((int)Random.Range(4,10));

            animal_Audiosource.PlayOneShot(animal_Audioclip);
        }
    }
}
