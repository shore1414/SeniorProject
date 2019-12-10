using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class walling : MonoBehaviour
{
    public GameObject startPole;
    public GameObject endPole;
    public GameObject wallFab;
    GameObject mid;
    public GameObject topRail;
    GameObject top;
    public GameObject botRail;
    GameObject bot;
    public float speed;
    Camera cam;
    Transform camTransform;
    private bool creating;

    private int count;
    public Text prodEstimate;
    public long price;

    //camer control stuff
    private float X;
    private float Y;
    public float sensitivity;
    // Start is called before the first frame update
    void Start()
    {
      
        cam = GetComponent<Camera>();
        camTransform = Camera.main.gameObject.transform;
        count = 0;
        //price = 4;
        // prodEstimate.text = "Product Estimation: " + count.ToString() + " $" + price.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    void getInput() {
        buildWall();
        cameraControls();
    }

    void buildWall() {
        // if (Input.GetMouseButtonDown(0)) {
        if (Input.GetKeyDown(KeyCode.E)){
            startWall();
        }
        // else if (Input.GetMouseButtonUp(0)){
          else  if (Input.GetKeyUp(KeyCode.E)){
            completeWall();
            // prodEstimate.text = "Product Estimation: " + count.ToString() + " $" + price.ToString();
        }
        else {
            if(creating) {
                adjustPoles();
            }
        }
    }
    
    
    void startWall() {
        creating = true;
        startPole.transform.position = getCursorPositionOnFloor();
    }
    void adjustPoles() {
        endPole.transform.position = getCursorPositionOnFloor();

        //correct rotation for poles
        startPole.transform.LookAt(endPole.transform.position);
        endPole.transform.LookAt(startPole.transform.position);
    }

    void completeWall() {
        creating = false;
        endPole.transform.position = getCursorPositionOnFloor();

        Vector3 topPos = new Vector3(startPole.transform.position.x, 1.4f, startPole.transform.position.z);
        float wallLength = Vector3.Distance(startPole.transform.position, endPole.transform.position);

        //create the midPoles and make them face the right way
        for (float i = 0; i <= wallLength; i += 0.9f) {
            mid = Instantiate(wallFab, startPole.transform.position, Quaternion.identity);
            mid.transform.position = startPole.transform.position + i * startPole.transform.forward;
            mid.transform.LookAt(endPole.transform.position);
            //acount for rails
            if(i%1.2 == 0){
                count+=2;
            }
            count++;
           
        }
        price = 5;
        price*=count;
        prodEstimate.text = "Product Count: " + count.ToString() + 
            " Estimated Cost $" + price.ToString();
        //last pole for weird distances
        mid = Instantiate(wallFab, endPole.transform.position, Quaternion.identity);

        //create the top and bottom rails
        top = Instantiate(topRail, topPos, Quaternion.identity);
        bot = Instantiate(botRail, startPole.transform.position, Quaternion.identity);

        //make rails face direction of the wall
        top.transform.rotation = startPole.transform.rotation;
        bot.transform.rotation = startPole.transform.rotation;

        //move rails to correct position and scale
        top.transform.position = startPole.transform.position + wallLength/2 * startPole.transform.forward;
        top.transform.position = new Vector3(top.transform.position.x, top.transform.position.y + 2.2f, top.transform.position.z);
        top.transform.localScale = new Vector3(top.transform.localScale.x, top.transform.localScale.y, wallLength + 0.3f);

        bot.transform.position = startPole.transform.position + wallLength/2 * startPole.transform.forward;
        bot.transform.localScale = new Vector3(top.transform.localScale.x, top.transform.localScale.y, wallLength + 0.3f);
    }

   
    Vector3 getCursorPositionOnFloor() {
        Ray ray = cam.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
        //  if(EventSystem.current.IsPointerOverGameObject()) {
            if(Physics.Raycast(ray,out hit)) {
                return hit.point;
            }
        //  }
        return Vector3.zero;
    }
    void cameraControls() {
         if(Input.GetKey(KeyCode.W)){
             transform.Translate(Vector3.forward * speed * Time.deltaTime);
         }
         if(Input.GetKey(KeyCode.A)){
             transform.Translate(Vector3.left * speed * Time.deltaTime);
         }
         if(Input.GetKey(KeyCode.D)){
             transform.Translate(Vector3.right * speed * Time.deltaTime);
         }
         if(Input.GetKey(KeyCode.S)){
             transform.Translate(Vector3.back * speed * Time.deltaTime);
         }
         if(Input.GetMouseButton(1)) {
            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * sensitivity, Input.GetAxis("Mouse X") * sensitivity, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X,Y,0);
         }
    }
}
