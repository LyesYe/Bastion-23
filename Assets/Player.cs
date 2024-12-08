using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject flame;
    void Update()
    {
        flame.SetActive(Input.GetMouseButtonDown(0));
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit; 
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {

                if (hit.collider.CompareTag("Enemy"))
                {
                    hit.collider.gameObject.GetComponent<Enemy>().health--;
                }
            }

        }
    }
}
