using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]

    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] public GameObject persistent;

    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private TextMeshProUGUI displayNameText;
    private static DialogueManager instance;

    private Story currentStory;

    public bool dialogueIsPlaying {get; private set;}

    private const string SPEAKER_TAG = "speaker";

    private void Awake() {

        if(instance != null){

            Debug.LogWarning("ERROR");
        }
        instance = this;

        persistent = GameObject.Find("Persistent Inventory");

    }

    private void Update(){

        if(!dialogueIsPlaying || persistent.GetComponent<PersistentData>().dialogPlayed){
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

            HandleTags(currentStory.currentTags);
        }
        else{
            persistent.GetComponent<PersistentData>().dialogPlayed = true;
            ExitDialogueMode();
        }
    }

    private void HandleTags(List<string> currentTags){
        foreach(string tag in currentTags){

            string [] splitTag = tag.Split(':');
            if(splitTag.Length !=2){
                Debug.LogError("Error de TAG");
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch(tagKey){
                case SPEAKER_TAG:
                displayNameText.text = tagValue;
                break;
                default:
                Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                break;
            }
        }
    }

    IEnumerator Esperar(){
        yield return new WaitForSeconds(1f);
    }
}
