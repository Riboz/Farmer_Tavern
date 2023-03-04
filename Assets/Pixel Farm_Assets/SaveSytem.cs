
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveSytem : MonoBehaviour
{
    public Buyable cow,sheep,chicken,tomato,patato,carrot,turp;

    
    public static List<Buyable> buyables=new List<Buyable>();
    const string build_Sub = "/build";
    const string build_Count_Sub = "/build.count";
    void Awake()
    {
        LoadBuild();
    }
    void OnApplicationQuit()
    {
        SaveBuild();
    }
    void SaveBuild()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + build_Sub + SceneManager.GetActiveScene().buildIndex;
        
        string Countpath = Application.persistentDataPath + build_Count_Sub + SceneManager.GetActiveScene().buildIndex;
        
        FileStream countStream = new FileStream(Countpath,FileMode.Create);
        
        formatter.Serialize(countStream,buyables.Count);
        
        countStream.Close();
        
            for(int i = 0 ; i < buyables.Count ; i++)
            {
                FileStream stream = new FileStream( path + i , FileMode.Create);
                // burada sıkıntı var
                BuyableData data = new BuyableData( buyables[i] );
                formatter.Serialize( stream , data );
                stream.Close();
            }
    }
    void LoadBuild()
    {
        BinaryFormatter formatter = new BinaryFormatter();
     
        string Countpath = Application.persistentDataPath + build_Count_Sub + SceneManager.GetActiveScene().buildIndex;    
     
        string path = Application.persistentDataPath + build_Sub + SceneManager.GetActiveScene().buildIndex;
     
        int buyableCount=0;
     
            if(File.Exists(Countpath))
            {
                FileStream countStream = new FileStream(Countpath,FileMode.Open);
                buyableCount = (int)formatter.Deserialize(countStream);
                countStream.Close();
            }
            else
            {
                Debug.LogError("Path not found");
            }
            for (int i = 0 ; i < buyableCount ; i++)
            {
                if(File.Exists(path+i))
                {
                    FileStream stream = new FileStream( path + i , FileMode.Open );
            
                    BuyableData data = formatter.Deserialize(stream) as BuyableData;

                    stream.Close();

                    Vector3 position = new Vector3(data.position[0] , data.position[1] , data.position[2]);
                   
                    
                    if(data.which==0)
                    {
                        
                        Buyable buyable = Instantiate(chicken,position,Quaternion.identity);
                        
                        
                    }
                    else if(data.which==1)
                    {
                         
                        Buyable buyable = Instantiate(cow,position,Quaternion.identity);
                       
                    }
                    else if(data.which==2)
                    {
                        Buyable buyable = Instantiate(sheep,position,Quaternion.identity);
                    
                        
                    }
                    else if(data.which==3)
                    {
                        
                        Buyable buyable = Instantiate(tomato,position,Quaternion.identity);
                      
                    }
                    else if(data.which==4)
                    {
                          
                        Buyable buyable = Instantiate(carrot,position,Quaternion.identity);
                        
                    }
                    else if(data.which==5)
                    {
                         
                        Buyable buyable = Instantiate(patato,position,Quaternion.identity);
                       
                    }
                    else if(data.which==6)
                    {
                          
                        Buyable buyable = Instantiate(turp,position,Quaternion.identity);
                       
                    }
                   

                    
                    
                    
                }
                else
                {
                     Debug.LogError("Path not found in"+path+i);
                }
       
            }
    }

}

