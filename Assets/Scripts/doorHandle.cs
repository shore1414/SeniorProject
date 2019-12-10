using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorHandle : MonoBehaviour
{
  
    private bool selected;
    public float moveSpeed;
    public float rotateSpeed;
    private float rotation;
    private Vector3 mOffset;
    private float zCoord;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.2f;
        rotateSpeed = 8f;
    }
    
    // Update is called once per frame
    void Update()
    {
        rotateWindow();
       // movePiece();
       // mouseMove();
    //    transform.position = getCursorPositionOnFloor();

    }
 
    private void rotateWindow() {
        if(Input.GetKey(KeyCode.LeftArrow)){
           transform.Rotate(0,  rotateSpeed * Time.deltaTime,0, Space.Self);
           
        }
        if(Input.GetKey(KeyCode.RightArrow)){
              transform.Rotate(0,  -rotateSpeed * Time.deltaTime,0, Space.Self);
        }
        

    }
    private void movePiece() {

        if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(0,moveSpeed,0);
        }

        if(Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(0, 0, -moveSpeed);
        }
    }

    
    void OnMouseDown() {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - getMousePos();
    }

    private Vector3 getMousePos() {
       Vector3 mousPoint = Input.mousePosition;
       mousPoint.z = zCoord;
       return Camera.main.ScreenToWorldPoint(mousPoint);
    }
    void OnMouseDrag() {
       transform.position = getMousePos() + mOffset;
    }
     Vector3 getCursorPositionOnFloor() {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
        //  if(EventSystem.current.IsPointerOverGameObject()) {
            if(Physics.Raycast(ray,out hit)) {
                return hit.point;
            }
        //  }
        return Vector3.zero;
    }
}
