using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using TMPro;
using Yarn; 

public class ShowCharacter : MonoBehaviour
{
    public Image portrait;
    public TextMeshProUGUI SpeakerName;
    private EmotionList _em;
    private Animator _anim;
    // Start is called before the first frame update
    private void Start()
    {
        portrait = GetComponent<Image>();
        _em = GetComponent<EmotionList>();
        
    }

    [YarnCommand("show")]
    public void Show(string Name)
    {
        _anim = GetComponent<Animator>();
        portrait.enabled = true;
        _anim.Play("Pop In");
        SpeakerName.text = Name;
    }


    private void Update()
    {
        portrait.sprite = GetComponent<SpriteRenderer>().sprite;
    }

    [YarnCommand("hide")]
    public void Hide(string Name)
    {
        portrait.enabled = false;
    }
}
