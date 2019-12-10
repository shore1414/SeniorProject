using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMesh : MonoBehaviour
{

     void OnTriggerEnter(Collider other) {
         gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerExit(Collider other) {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
