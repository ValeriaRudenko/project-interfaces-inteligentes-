using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenVideo : MonoBehaviour
{   
    private Material tvMaterial;

    private WebCamTexture webcamTexture;
    private bool activeCam;
    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        webcamTexture = new WebCamTexture();
        Renderer renderer = GetComponent<Renderer>();
        tvMaterial = GetComponent<Renderer>().material;
        activeCam = true;
        tvMaterial.mainTexture = webcamTexture;
        webcamTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey("o")) { // Active cam
        if (!activeCam)
          activeCam = true;
          tvMaterial.mainTexture = webcamTexture;
          webcamTexture.Play();
       }

       if (Input.GetKey("p")) { //Pause cam
         if (activeCam)
          activeCam = false;
          webcamTexture.Stop();
          webcamTexture = new WebCamTexture();
          tvMaterial.mainTexture = webcamTexture;
          tvMaterial.color = Color.white;
       }
       
    }
}
