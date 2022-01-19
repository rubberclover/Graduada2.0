using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuCarga : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    //[SerializeField] GameObject spawner?;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Protagonista");
        player.GetComponent<IsometricPlayerMovement>().speed = 0;
        StartCoroutine(load());
    }

    
    void Update()
    {
        
    }
    
    private IEnumerator load(){
        yield return new WaitForSeconds(11);
        inventory.GetComponent<InventorySystem>().inventoryLoad();
        gameObject.SetActive(false);
        player.GetComponent<IsometricPlayerMovement>().speed = 12;
    }
}
