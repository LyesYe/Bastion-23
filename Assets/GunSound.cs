using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSound : MonoBehaviour
{

    public AudioSource gunSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // add gun sound on left click

        if (Input.GetMouseButtonDown(0))
        {
            gunSound.enabled = true;
        }
        else
        {
            gunSound.enabled = false;
        }
        
    }
}



