using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Missions : MonoBehaviour
{
public int theMission1,theMission2,theMission3,missionCount=0;

public float coolDown,timerforFreegold;
public Button Button;
public GameObject missionPanel;

public Image mission1I,mission2I,mission3I;
 public int countmission=1,countmission2=1,countmission3=1;
 public ParticleSystem wingold;
public Sprite[] Sprites;
public Text mis1,mis2,mis3;
 // 0 egg/ 1 milk/ 2 cotton /3 tomato/ 4 carrot/ 5 turp /6 potato
GameManager gameManager;
public bool missionComplete,a=true;
  IEnumerator MissionMaker()
 {
    // 3 tane tür ve her türde random sayıda çeşit
    if(missionCount>5)
    {
     theMission1 = Random.Range(0,7);

     theMission2 = Random.Range(0,7);
     
     theMission3 = Random.Range(0,7);
 
     countmission = Random.Range(1,4);

     countmission2 = Random.Range(1,4);

     countmission3 = Random.Range(1,4);
    

     
    }
    else
    {
        theMission1 = Random.Range(3,7);

        theMission2 = Random.Range(3,7);
    
        theMission3 = Random.Range(3,7);

       
        
    }
    
    if(theMission1 != theMission2 && theMission2 != theMission3 && theMission1 != theMission3)
    {
        //araba gelir
         
             mis1.text=""+countmission;
             mis2.text=""+countmission2;
             mis3.text=""+countmission3;
         mission1I.GetComponent<Image>().sprite=Sprites[theMission1];

         mission2I.GetComponent<Image>().sprite=Sprites[theMission2];

         mission3I.GetComponent<Image>().sprite=Sprites[theMission3];
         

      

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
    while(a)
    {

       if(gameManager.inventoryspace[theMission1] >= countmission  && gameManager.inventoryspace[theMission2] >= countmission2 && gameManager.inventoryspace[theMission3] >= countmission3)
            {
                if(gameManager.inventoryspace[theMission1]-countmission>=0  && gameManager.inventoryspace[theMission2]-countmission2>=0 && gameManager.inventoryspace[theMission3]-countmission3>=0 )
                {
                    missionComplete = true;
                 
                   Button.interactable=true;
                      // görselleri tikle
                   
                }
              
            }
            else
                {
                   
                    Button.interactable=false;
                    missionComplete=false;
                }
        yield return new WaitForSeconds(0.05f);
       
    }
   
    
   
 }
 

 public void MissionComplete()
 {
    if(missionComplete)
    {
        
        StartCoroutine(CompleteMission());
        Button.interactable=false;
        Instantiate(wingold,new Vector2(0,-7),Quaternion.identity);
        
    }
 }
IEnumerator CompleteMission()
 {
    // araba gider görev paneli gider ve imageler daha canlı gözükür
    


    gameManager.Gold+=75;  

    gameManager.inventoryspace[theMission1] -= countmission;
    gameManager.inventoryspace[theMission2] -= countmission2;
    gameManager.inventoryspace[theMission3] -= countmission3;
    missionComplete = false;
    missionPanel.transform.DOMoveY(-150,coolDown/3);
    yield return new WaitForSeconds(2f);
   
    saveinventory();
    
    // para verir
    
    
    Debug.Log("A");
    missionCount += 1;
    PlayerPrefs.SetInt("MissionCount",missionCount);
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
    missionCount=PlayerPrefs.GetInt("MissionCount");

    gameManager.Gold = PlayerPrefs.GetInt("money");

    gameManager.Gold_Display.text = ""+gameManager.Gold;
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
     if( gameManager.inventoryspace[theMission3]-countmission3<0 )
        {
            mission3I.GetComponent<Image>().color=Color.red;
        }
        else
        {
            mission3I.GetComponent<Image>().color=Color.white;
        }
     if( gameManager.inventoryspace[theMission2]-countmission2<0 )
        {
            mission2I.GetComponent<Image>().color=Color.red;
        }
         else
        {
            mission2I.GetComponent<Image>().color=Color.white;
        }
        if( gameManager.inventoryspace[theMission1]-countmission<0 )
        {
            mission1I.GetComponent<Image>().color=Color.red;
        }
         else
        {
            mission1I.GetComponent<Image>().color=Color.white;
        }
    timerforFreegold += Time.deltaTime;
    if(timerforFreegold >= 60)
    {
        saveinventory();
        timerforFreegold = 0;
        gameManager.Gold += 5;
    }
    
 }

}
