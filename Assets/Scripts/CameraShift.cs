using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShift : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public bool isFirstCameraActive=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        { 
            isFirstCameraActive = !isFirstCameraActive;
            if(isFirstCameraActive)
            {
                cam1.SetActive(true);
                cam2.SetActive(false);
            }
            else
            {
                cam2.SetActive(true);
                cam1.SetActive(false);
            }
        }
    }
}
