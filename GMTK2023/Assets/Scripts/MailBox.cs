using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MailBox : MonoBehaviour,IInteraction
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

    public GameObject familyPicture;

    public string text;

    public GameObject door;

    public Font narrator;

    public bool firstTime = true;

    public bool reading = false;

    void Start()
    {
        interactable = interactionStatus;
        EventSystem.current.dialougeHide += setDialogueInActive;
    }


    public float interaction(FirstPersonController player)
    {
        if (firstTime)
        {
            dialogue.font = narrator;
            dialogue.text = text;
            dialogue.gameObject.SetActive(true);
            familyPicture.gameObject.SetActive(true);
            reading = true;
            firstTime = false;
            door.GetComponent<Door2>().locked = false;
            return displayTime;
        }
        else
        {
            familyPicture.gameObject.SetActive(true);
            reading = true;
            return 0;
        }
 
    }


    public void setDialogueInActive()
    {
        dialogue.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if(reading == true && Input.GetKeyDown(KeyCode.E))
        {
            reading = false;
            familyPicture.gameObject.SetActive(false);
        }
    }
}
