using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activation : MonoBehaviour
{

    private bool foundHit;
    private RaycastHit hit;
    public Camera cam;
    public LayerMask layer;
    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        // cam = GetComponent<Camera>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay (Input.mousePosition);
        int layerMask = 1 << 8;

           Debug.DrawRay(ray.origin, ray.direction * 60f, Color.yellow);
       
        // trying to use a boolean
        //activate the object to manipulate it
        if (Input.GetMouseButtonDown(0)){
            //swap boolean like a switch
            active = !active;
            if(Physics.Raycast(ray, out hit, 100f,layer)) {
                
                Debug.Log("Hit the Window");
                hit.collider.GetComponent<manipulateWindow>().enabled = active;
                
        }
        }
       //original that works
        // if (Input.GetMouseButton(0)){
        //     if(Physics.Raycast(ray, out hit, 100f,layer)) {
        //         // if(Physics.Raycast(ray, out hit, 100f) && hit.transform.tag == "window"){
        //          Debug.Log("Hit the Window");
        //         hit.collider.GetComponent<manipulateWindow>().enabled = true;
        //         // hit.collider.GetComponent<MeshRenderer>().enabled = false;
        //         // hit.transform.position = hit.point;
        //     }
        // }
        // if (Input.GetMouseButtonUp(0)){
        //     if(Physics.Raycast(ray, out hit, 100f,layer)) {
        //         Debug.Log("Hit the Window");
        //         hit.collider.GetComponent<manipulateWindow>().enabled = false;
        //         //  hit.collider.GetComponent<MeshRenderer>().enabled = true;
        //     }
        // }
        
        
    }

    
}
