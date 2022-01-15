using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trueque : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> dialogos;
    public List<GameObject> todos;
    private List<GameObject> orden;
    private List<int> nums;
    private List<int> ordenContactos;
    private List<GameObject> contactos;
    private int anteriorIndex = 5;
    public List<GameObject> texto;
    
    void Start()
    {
       orden = new List<GameObject>();
       nums = new List<int>();
       ordenContactos = new List<int>();
       contactos = new List<GameObject>();
       for(int i = 0; i <4; i++){
           nums.Add(i);
       } 
       arrayNum(nums);
       activarContactos();
       ordenar(dialogos);
    }
    void Update(){
        if(orden.Count < 4) ordenar(dialogos);
    }


    void ordenar(List<GameObject> dialogos){
        int index = Random.Range(0, dialogos.Count);
        GameObject conver = dialogos[index];
        dialogos.RemoveAt(index);
        orden.Add(conver);
        if (dialogos.Count >= 1) {
            ordenar(dialogos);
        }
    }
    void arrayNum(List<int> nums){
        int index = Random.Range(0, nums.Count);
        int conver = nums[index];
        nums.RemoveAt(index);
        ordenContactos.Add(conver);
        if (nums.Count >= 1) {
            arrayNum(nums);
        }
    }
    void activarContactos(){
        int j = 0;
        for(int i=0; i<16; i += 4){
            contactos.Add(todos[i+ordenContactos[j]]);
            j++;
        }
        for(int i=0; i<4; i++){
            contactos[i].SetActive(true);
        }
    }
    void Awake(){
        DontDestroyOnLoad(gameObject);
    }

    public void contacto1(){
        if(anteriorIndex <=4){
            orden[anteriorIndex].SetActive(false);
        }
        orden[0].SetActive(true);
        anteriorIndex = 0;
    }
    public void contacto2(){
        if(anteriorIndex <=4){
            orden[anteriorIndex].SetActive(false);
        }
        orden[1].SetActive(true);
        anteriorIndex = 1;
    }
    public void contacto3(){
        if(anteriorIndex <=4){
            orden[anteriorIndex].SetActive(false);
        }
        orden[2].SetActive(true);
        anteriorIndex = 2;
    }
    public void contacto4(){
        if(anteriorIndex <=4){
            orden[anteriorIndex].SetActive(false);
        }
        orden[3].SetActive(true);
        anteriorIndex = 3;
    }

    public void accept(){
        Debug.Log("asdsfñkuaszdghfhase");
        GameObject.Find("Cruz").SetActive(false);
        GameObject.Find("Tick").SetActive(false);
        texto[anteriorIndex].SetActive(true);
    }
    public void cancel(){
        Debug.Log("aldiodufgta");
        GameObject.Find("Cruz").SetActive(false);
        GameObject.Find("Tick").SetActive(false);
        texto[anteriorIndex].SetActive(true);
    }
}
