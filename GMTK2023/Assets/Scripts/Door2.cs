using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door2 : MonoBehaviour,IInteraction
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

    public string textLocked;

    private bool doorOpened = false;

    public bool locked = true;

    public Font MC;

    public float displayTimeUnLocked;

    Animator anim;

    void Start()
    {
        anim = this.transform.parent.GetComponent<Animator>();
        interactable = interactionStatus;
        EventSystem.current.dialougeHide += setDialogueInActive;
    }


    public float interaction(FirstPersonController player)
    {
        if (locked)
        {
            dialogue.font = MC;
            dialogue.text = textLocked;
            dialogue.gameObject.SetActive(true);
            return displayTime;
        }
        else
        {
            if (doorOpened)
            {
                anim.Play("door close");
            }
            else
            {
                anim.Play("door open");
            }
            doorOpened = !doorOpened;
            return displayTimeUnLocked;
        }
 
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
