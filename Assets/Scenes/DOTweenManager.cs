using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class DOTweenManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Buttons")]
    [SerializeField]public Button shopButton;

    [Header("Places")]
    [SerializeField]private GameObject buyArea;
    
    

    // Update is called once per frame
    public void ShopButtonOpen()
    {
        
        buyArea.transform.DOMoveX(1040,0.2f);
        
        shopButton.gameObject.SetActive(false);
       
    }
    
    public void ShopButtonExit()
    {
        
        buyArea.transform.DOMoveX(-500,0.2f);
       
    }
    public void ShopButtonExitButton()
    {
        
        buyArea.transform.DOMoveX(-500,0.2f);
        shopButton.gameObject.SetActive(true);
       
    }
    public void TavernArea()
    {
        buyArea.transform.DOMoveX(-500,0.2f);
        shopButton.gameObject.SetActive(false);
    }
}
