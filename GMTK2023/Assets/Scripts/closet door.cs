using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closetdoor : MonoBehaviour,IInteraction
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

    public string text;

    Animator anim;

    void Start()
    {
        anim = this.transform.GetComponent<Animator>();
        interactable = interactionStatus;
        EventSystem.current.dialougeHide += setDialogueInActive;
    }


    public float interaction(FirstPersonController player)
    {
        dialogue.text = text;
        dialogue.gameObject.SetActive(true);
        anim.Play("closet door open");
        interactable = false;
        return displayTime;
    }


    public void setDialogueInActive()
    {
        dialogue.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

    }
}