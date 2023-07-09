using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;
using UnityEditor.Experimental.RestService;

public class introControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float displayTime = 3f;

    public float textVillainDisplayTime = 14f;


    public float textMCDisplayTime = 14f;

    public GameObject postEffect;
    public string textVillain;
    public string textMC;

    public Font villain;
    public Font MC;

    [SerializeField]
    private Text dialougueUIReference;
    public Text dialogue => dialougueUIReference;

    private PostProcessVolume postProcessVolume;
    private Vignette targetV;
    private float targetIntensity = 0.45f;
    private float targetSmoothness = 0.15f;

    private bool played = false;
    private bool playedMC= false;

    void Start()
    {
        postProcessVolume = postEffect.GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out targetV);
        EventSystem.current.dialougeHide += setDialogueInActive;
    }

    // Update is called once per frame
    void Update()
    {
        if(displayTime > 0)
        {
            displayTime = displayTime - Time.deltaTime;
            targetV.intensity.value -=  (1f - targetIntensity) * Time.deltaTime / 3f;
            targetV.smoothness.value -=  (1f - targetSmoothness) * Time.deltaTime / 3f;
        }
        else if(textVillainDisplayTime > 0)
        {
            if (!played)
            {
                dialogue.font = villain;
                dialogue.text = textVillain;
                dialogue.gameObject.SetActive(true);
                this.GetComponent<AudioSource>().Play();
                played = true;
            }
            if (textVillainDisplayTime > 0)
            {
                textVillainDisplayTime = textVillainDisplayTime - Time.deltaTime;
            }
        }
        else
        {
            if (!playedMC)
            {
                dialogue.font = MC;
                dialogue.text = textMC;
                dialogue.gameObject.SetActive(true);

            }
            if (textMCDisplayTime > 0) 
            {
                textMCDisplayTime = textMCDisplayTime - Time.deltaTime;
            }
        }
    }


    public void setDialogueInActive()
    {
        dialogue.gameObject.SetActive(false);
    }
}
