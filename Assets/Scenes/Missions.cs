using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Missions : MonoBehaviour
{
public int theMission1,theMission2,theMission3;

public float coolDown,timerforFreegold;
public GameObject Car;
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
         Car = Instantiate(Car , new Vector2(-18,-8) , Quaternion.identity );

        Car.transform.DOLocalMoveX( 0 , coolDown );
        
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
    if( !missionComplete ){ StartCoroutine(Checker()); }
 }
IEnumerator CompleteMission()
 {
    // araba gider görev paneli gider
   Car.transform.DOLocalMoveX( 18, coolDown );
    yield return new WaitForSeconds(coolDown);
     
    gameManager.inventoryspace[theMission1] -= 1;
    gameManager.inventoryspace[theMission2] -= 1;
    gameManager.inventoryspace[theMission3] -= 1;
    // para verir
    missionComplete = false;
    Debug.Log("A");
    StartCoroutine(MissionMaker());
    yield break;
 }
 void Start()
 {
 gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
 StartCoroutine(MissionMaker());
 }
 void FixedUpdate()
 {
    timerforFreegold += Time.deltaTime;
    if(timerforFreegold >= 60)
    {
        timerforFreegold = 0;
        gameManager.Gold += 50;
    }
 }

}
