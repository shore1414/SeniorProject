using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObj : MonoBehaviour
{
    
    public void spawnFab(GameObject fab) {
        // Vector3 mousPos = Input.mousePosition;
        Instantiate(fab,new Vector3( 0, 0, 0), Quaternion.identity);
    }
  
   
}
