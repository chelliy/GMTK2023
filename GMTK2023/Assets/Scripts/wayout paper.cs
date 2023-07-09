using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class wayoutpaper : MonoBehaviour,IInteraction
{
    // Start is called before the first frame update

    [SerializeField]
    private Text dialougueUIReference;
    public Text dialogue => dialougueUIReference;


    [SerializeField]
    private float dialogueDisplayTime;
    public float displayTime => dialogueDisplayTime;

    [SerializeField]
    private bool interactionStatus = true;
    public bool interactable { get; set; }

    public GameObject wayoutPaper;

    public string text;


    public bool reading = false;

    void Start()
    {
        interactable = interactionStatus;
        EventSystem.current.dialougeHide += setDialogueInActive;
    }


    public float interaction(FirstPersonController player)
    {
        dialogue.text = text;
        dialogue.gameObject.SetActive(true);
        wayoutPaper.gameObject.SetActive(true);
        reading = true;
        return displayTime;
 
    }


    public void setDialogueInActive()
    {
        dialogue.gameObject.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        if(reading == true && Input.GetKeyDown(KeyCode.Escape))
        {
            reading = false;
            wayoutPaper.gameObject.SetActive(false);
        }
    }
}
