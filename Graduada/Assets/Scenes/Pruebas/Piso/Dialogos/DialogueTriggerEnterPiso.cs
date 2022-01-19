using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerEnterPiso : MonoBehaviour
{
   [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool haIniciado;
    private void Update() {
     if(!haIniciado){
     DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
     }
     haIniciado = true;
    }

    private void Awake() {
        haIniciado = false;
    }
}
