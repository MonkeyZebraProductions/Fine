using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ShowCharacter : MonoBehaviour
{
    public Image portrait;
    // Start is called before the first frame update
    private void Start()
    {
        portrait = GetComponent<Image>();
        
    }

    [YarnCommand("show")]
    public void Show()
    {
        portrait.enabled = true;
    }

    [YarnCommand("hide")]
    public void Hide()
    {
        portrait.enabled = false;
    }
}
