using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Yarn.Unity;
using Yarn;

public class Nametag : MonoBehaviour
{
    public TextMeshProUGUI SpeakerName;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    [YarnCommand("SetName")]
    public void SetName(string speakerName)
    {
        SpeakerName.text = speakerName;
    }
}
