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
    [SerializeField]private GameObject inventoryPanel;
   
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
    public void OnTriggerExit2D(Collider2D Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            OutArea();
        }
    }
    void InArea()
    {
     inventoryPanel.transform.DOMoveY(550, 0.2f);
     for(int i = 0 ; i < inventoryspace.Length ; i ++)
     {
        inventoryspace[i].transform.Find("Text").GetComponent<Text>().text=""+gameManager.inventoryspace[i];
     }

    }
    void OutArea()
    {
     inventoryPanel.transform.DOMoveY(2000,0.2f);

    }
     
      
    void Update()
    {
        
    }
}
