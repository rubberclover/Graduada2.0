using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]

    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private TextMeshProUGUI dialogueText;
    private static DialogueManager instance;

    private Story currentStory;

    private bool dialogueIsPlaying;

    private void Awake() {

        if(instance != null){

            Debug.LogWarning("ERROR");
        }
        instance = this;
    }

    private void Update(){

        if(!dialogueIsPlaying){
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
            StartCoroutine(Esperar());
        }
    }
    public static DialogueManager GetInstance(){
        return instance;
    }

    private void Start(){
      dialogueIsPlaying = false;
      dialoguePanel.SetActive(false); 
    }

    public void EnterDialogueMode(TextAsset inkJSON){

        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
        
    }

    private void ExitDialogueMode(){
        
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void ContinueStory(){

        if(currentStory.canContinue){
            dialogueText.text = currentStory.Continue();
        }
        else{

            ExitDialogueMode();
        }
    }

    IEnumerator Esperar(){
        yield return new WaitForSeconds(1f);
    }
}