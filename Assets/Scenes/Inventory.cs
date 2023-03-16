using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gameManager;
    [SerializeField]private Button[] inventoryspace; 
    [SerializeField]private GameObject inventoryPanel,missionPanel;
    [SerializeField]public Button inventoryButton,shopButton,delayButton;
    // shop açıkken invent açık olamaz bu durumu düzelt yarın
    // 0 egg/ 1 milk/ 2 cotton /3 tomato/ 4 carrot/ 5 turp /6 potato
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }
     public void OnTriggerEnter2D(Collider2D Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            InArea();
        }
    }
  
    public void InArea()
    {
     inventoryPanel.transform.DOMoveY(550, 0.2f);

     inventoryButton.gameObject.SetActive(false);

     shopButton.gameObject.SetActive(false);
     
    

     delayButton.gameObject.SetActive(false);

     for(int i = 0 ; i < inventoryspace.Length ; i ++)
     {
        inventoryspace[i].transform.Find("Text").GetComponent<Text>().text=""+gameManager.inventoryspace[i];
     }


    }
    public void OutArea()
    {
        inventoryButton.gameObject.SetActive(true);

        shopButton.gameObject.SetActive(true);
     
        

        delayButton.gameObject.SetActive(true);

        inventoryPanel.transform.DOMoveY(2000,0.2f);

    }

    public void MissionPanelOut()
    {
      missionPanel.transform.DOMoveX(1670,0.2f);
      
     inventoryButton.gameObject.SetActive(false);

     shopButton.gameObject.SetActive(false);
     
     

     delayButton.gameObject.SetActive(false);

    }
    public void MissionPanelIn()
    {
         missionPanel.transform.DOMoveX(2300,0.2f);
         
        inventoryButton.gameObject.SetActive(true);

        shopButton.gameObject.SetActive(true);
     
        

        delayButton.gameObject.SetActive(true);

    }

   
     
   
}
