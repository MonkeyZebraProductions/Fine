using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float FadeTime;
    public float Alpha;

    private bool _isFading;
    private SpriteRenderer spriteRenderer;
    private Interactable interactable;
    //private Color color;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Alpha<=0)
        {
            interactable.ButtonPrompt.SetActive(false);
            interactable.enabled = false;
        }
    }

    public void Fading()
    {
        _isFading = true;
        StartCoroutine(fadeOut(spriteRenderer, FadeTime));
    }

    IEnumerator fadeOut(SpriteRenderer MyRenderer, float duration)
    {
        float counter = 0;
        //Get current color
        Color spriteColor = MyRenderer.material.color;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            Alpha = Mathf.Lerp(1, 0, counter / duration);
            Debug.Log(Alpha);

            //Change alpha only
            MyRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, Alpha);
            //Wait for a frame
            yield return null;
        }
    }

    
}
