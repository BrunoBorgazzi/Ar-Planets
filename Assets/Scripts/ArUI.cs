using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ARUI : MonoBehaviour
{

    public List<string> infoText = new List<string>();
    public List<AudioClip> infoAudio = new List<AudioClip>();
    public List<Texture2D> imageList = new List<Texture2D>();

    public Canvas canvas;
    public TMP_Text infoBox;
    public RawImage rawImage;
    

    int infoPointer = -1;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        canvas.enabled = false;

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.tag == "mars")
                {
                    displayCanvas();
                    infoPointer = 0;
                    displayAndPlayInfo();
                    rawImage.texture = imageList[0];
                    
                }
        
                if(hit.transform.tag == "earth")
                {
                   displayCanvas();
                    infoPointer = 3;
                    displayAndPlayInfo();
                    rawImage.texture = imageList[1];
                }
            }
         }

        
        
    }
 


    void displayAndPlayInfo()
    {
        infoBox.text = infoText[infoPointer];
       if(audio.isPlaying)
        {
            audio.Stop();
        }
        audio.PlayOneShot(infoAudio[infoPointer], 1f);
    }

    public void nextInfo()
    {
        infoPointer++;  
        displayAndPlayInfo();
    }

    public void lastInfo()
    {

    }

    public void displayCanvas()
    {
        canvas.enabled = true;
    }

    public void hideCanvas()
    {
        canvas.enabled = false;
    }



}