using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class inputpaper : MonoBehaviour,IInteraction
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

    public GameObject getoutPaper;

    public InputField inputfield;

    public Font villain;
    public Font MC;


    public string wrongAnswerText;
    public string correctAnswerText;

    public string target;
    public string target1;

    public string input;

    public bool reading = false;

    void Start()
    {
        interactable = interactionStatus;
        EventSystem.current.dialougeHide += setDialogueInActive;
    }


    public float interaction(FirstPersonController player)
    {
        dialogue.text = "";
        dialogue.gameObject.SetActive(true);
        getoutPaper.gameObject.SetActive(true);
        reading = true;
        inputfield.gameObject.SetActive(true);
        return displayTime;
 
    }


    public void setDialogueInActive()
    {
        dialogue.gameObject.SetActive(false);
    }

    public bool searchForTarget()
    {
        int targetLength = target.Length;
        char firstChar = target[0];
        int index = input.IndexOf(firstChar);
        bool found = false;
        while (index != -1 && !found) 
        {
            if (index + targetLength > input.Length)
            {
                return found;
            }
            else
            {
                if (input.Substring(index, targetLength).Equals(target))
                {
                    found = true;
                }
                else
                {
                    input = input.Substring(index + 1);
                    index = input.IndexOf(firstChar);
                }
            }
        }

        targetLength = target1.Length;
        firstChar = target1[0];
        index = input.IndexOf(firstChar);
        found = false;
        while (index != -1 && !found)
        {
            if (index + targetLength > input.Length)
            {
                return found;
            }
            else
            {
                if (input.Substring(index, targetLength).Equals(target1))
                {
                    found = true;
                }
                else
                {
                    input = input.Substring(index + 1);
                    index = input.IndexOf(firstChar);
                }
            }
        }
        return found;
    }

    public void ReadStringInput(string s)
    {
        input = s;
        bool result = searchForTarget();
        if (result) 
        {
            reading = false;
            getoutPaper.gameObject.SetActive(false);
            inputfield.gameObject.SetActive(false);
            dialogue.font = villain;
            dialogue.text = correctAnswerText;

        }
        else
        {
            dialogue.font = MC;
            dialogue.text = wrongAnswerText;
            dialogue.gameObject.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(reading == true && Input.GetKeyDown(KeyCode.Escape))
        {
            reading = false;
            getoutPaper.gameObject.SetActive(false);
            inputfield.gameObject.SetActive(false);
        }
    }
}
