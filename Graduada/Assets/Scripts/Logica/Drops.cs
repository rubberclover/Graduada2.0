using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    public List<GameObject> dropeableItems;

    private int idCalcetin;
    private int idRefresco;
    private int idVodka;
    private int idManifiesto;
    private int idMovil;

    private double chanceRefresco;
    private double chanceVodka;
    private double chanceManifiesto;
    private double chanceMovil;

    void Start()
    {
        idCalcetin = 0;
        idRefresco = 1;
        idVodka = 2;
        idManifiesto = 3;
        idMovil = 4;
        
        chanceRefresco =1f; //0.35
        chanceVodka = 1f; //0.60
        chanceManifiesto = 0f; //0.80
        chanceMovil = 1f; //0.95
    }

    public void Drop(Vector3 dropPosition){
        int numDrops = Random.Range(1,2);

        for( int j = 0; j< numDrops; j++){
            double dropChance = Random.Range(0.0f,1f);

            if(dropChance >= chanceMovil){
                print("Dropeado un " + "Movil");
                Instantiate(dropeableItems[idMovil], dropPosition  , Quaternion.identity);
            }
            if(dropChance >= chanceManifiesto){
                print("Dropeado un " + "Manifiesto");
                Instantiate(dropeableItems[idManifiesto], dropPosition  , Quaternion.identity);
            }
            if(dropChance >= chanceVodka){
                print("Dropeado un " + "Vodka");
                Instantiate(dropeableItems[idVodka], dropPosition  , Quaternion.identity);
            }
            if(dropChance >= chanceRefresco){
                print("Dropeado un " + "Refresco");
                Instantiate(dropeableItems[idRefresco], dropPosition  , Quaternion.identity);
            }
            else{
                print("Dropeado un " + "Calcetin");
                Instantiate(dropeableItems[idCalcetin], dropPosition  , Quaternion.identity);
            }
        }
    }
}
