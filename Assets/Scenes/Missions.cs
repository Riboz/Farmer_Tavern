using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Missions : MonoBehaviour
{
public int theMission1,theMission2,theMission3;

public float coolDown,timerforFreegold;
public GameObject Car,missionPanel;

public Image mission1I,mission2I,mission3I;
public Sprite[] Sprites;
 // 0 egg/ 1 milk/ 2 cotton /3 tomato/ 4 carrot/ 5 turp /6 potato
GameManager gameManager;
public bool missionComplete;
  IEnumerator MissionMaker()
 {
    // 3 tane tür ve her türde random sayıda çeşit

    theMission1 = Random.Range(0,7);

    theMission2 = Random.Range(0,7);
    
    theMission3 = Random.Range(0,7);
    
    if(theMission1 != theMission2 && theMission2 != theMission3 && theMission1 != theMission3)
    {
        //araba gelir
         Car = Instantiate(Car , new Vector2(-18,-6.5f) , Quaternion.identity );

         mission1I.GetComponent<Image>().sprite=Sprites[theMission1];

         mission2I.GetComponent<Image>().sprite=Sprites[theMission2];

         mission3I.GetComponent<Image>().sprite=Sprites[theMission3];
         

        Car.transform.DOLocalMoveX( 0 , coolDown/2 );

        missionPanel.transform.DOMoveY(+50,coolDown/2);
        //panel burada açığa çıksın
        
        
        yield return new WaitForSeconds(coolDown);
        
        Debug.Log("b");
        
        StartCoroutine(Checker());
        
        yield break;
    }
    else
    {
        StartCoroutine(MissionMaker());
    }
   
 }
IEnumerator Checker()
 {
    if(gameManager.inventoryspace[theMission1] > 0 && gameManager.inventoryspace[theMission2] > 0 && gameManager.inventoryspace[theMission3] > 0)
    {
        missionComplete = true;
        StartCoroutine(CompleteMission());

        yield break;
    }
    yield return new WaitForSeconds(1f);
    if( !missionComplete )
        {
         
            StartCoroutine(Checker());
        }
 }
IEnumerator CompleteMission()
 {
    // araba gider görev paneli gider ve imageler daha canlı gözükür
    missionPanel.transform.DOMoveY(-150,coolDown/3);

    Car.transform.DOLocalMoveX( 18, coolDown / 2 );
    yield return new WaitForSeconds(coolDown / 2 );
    gameManager.Gold+=50;  
    yield return new WaitForSeconds(coolDown / 2 );
     
    gameManager.inventoryspace[theMission1] -= 1;
    gameManager.inventoryspace[theMission2] -= 1;
    gameManager.inventoryspace[theMission3] -= 1;
    saveinventory();
    
    // para verir
    missionComplete = false;
    
    Debug.Log("A");
    StartCoroutine(MissionMaker());
    yield break;
 }
 public void saveinventory()
 {
    PlayerPrefs.SetInt("inventory.length",gameManager.inventoryspace.Length);
    PlayerPrefs.SetInt("money",gameManager.Gold);
    for(int i=0;i<gameManager.inventoryspace.Length;i++)
    {
        PlayerPrefs.SetInt("inventory"+i,gameManager.inventoryspace[i]);
    }
 }
 public void Getinventory()
 {
    gameManager.Gold=PlayerPrefs.GetInt("money");
    gameManager.Gold_Display.text=""+gameManager.Gold;
    for(int i=0;i<PlayerPrefs.GetInt("inventory.length",0);i++)
    {
        gameManager.inventoryspace[i]=PlayerPrefs.GetInt("inventory"+i);
    }
 }
 void Start()
 {
 gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
 StartCoroutine(MissionMaker());
 Getinventory();
 }
 void FixedUpdate()
 {
    timerforFreegold += Time.deltaTime;
    if(timerforFreegold >= 60)
    {
        saveinventory();
        timerforFreegold = 0;
        gameManager.Gold += 10;
    }
 }

}
