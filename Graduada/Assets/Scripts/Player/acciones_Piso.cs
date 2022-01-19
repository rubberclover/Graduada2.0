using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acciones_Piso : MonoBehaviour
{
    public GameObject portatil;
    private bool portatilActivo = false;
    ChangeLevelLogic level = new ChangeLevelLogic();


    void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && !portatilActivo){
            Exit();
        }
    }
    void OnTriggerStay (Collider col)
    {
        if (Input.GetButton("Action"))
        {
            if(col.CompareTag("zonaSalida")) level.goStreets();
            if(col.CompareTag("portatil")){
                 portatil.SetActive(true);
                 portatilActivo = true;
            }
            
        }
        if(Input.GetKey(KeyCode.Escape)){ //Despues con el escape
            if(col.CompareTag("portatil")){
                portatil.SetActive(false);
                Debug.Log(portatilActivo);
                StartCoroutine(esperar(3));
                Debug.Log(portatilActivo);
            }
                
        }
    }

    void Exit(){
        level.goMainMenu();
    }

    private IEnumerator esperar(int segundos){
        yield return new WaitForSeconds(segundos);
        portatilActivo = false;
        Debug.Log("mirameeeee");
    }

}
