using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Tüm Animal objelerinde olucak olan class
public class Animal : MonoBehaviour
{
    [Header("Animal animation")]
   public Animator animator;

   [Header("Animal_Voice")]
   public AudioSource animal_Audiosource;
   public AudioClip animal_Audioclip;

   [Header("Animal Dropping")]
   [SerializeField] public int cooldown_Drop;
   [SerializeField] public GameObject spawning_Item;

   [Header("animal is active ?")]
   bool active_animal;

   // alt classta active bool methodunun içini istenilen değerlerle doldurup çalıştır
    public bool active(int animal_cooldown_drop,GameObject drop_Item,AudioClip audio_animal)
    {
               
        // methodda Doldurulan değerler gerekli olan coroutinlere aktar ve corotinleri çalıştır

        StartCoroutine(Animal_Drop(animal_cooldown_drop,drop_Item));   

        StartCoroutine(Animal_Voice(audio_animal));
        // eğer 54. satır çalışmazsa buranın altına bak
        return active_animal=true;
    
    }
    IEnumerator Animal_Drop(int animal_cooldown_drop,GameObject drop_Item)
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
                Instantiate(spawning_Item,this.transform.position,Quaternion.identity);
                Timer=0;

            }
        }
   }

    IEnumerator Animal_Voice(AudioClip audio_animal)
    {
        // alt classdan alınan asıl hayvanın audio clipi eşleniyor

        // eğer yanlış çalışırsa buraya (active_animal=true;) ve 31. satırdaki retun active_animal=true yu sil düz return true yap
        animal_Audioclip=audio_animal;

        while(active_animal)
        {
            //4-9 saniyeler arasında ineği bağırttırıyor
            yield return new WaitForSeconds((int)Random.Range(4,10));

            animal_Audiosource.PlayOneShot(animal_Audioclip);
        }
    }
}
