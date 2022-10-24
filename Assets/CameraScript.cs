using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;
    [SerializeField] private float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        float hsp = transform.position.y * speed * Input.GetAxis("Horizontal");
        float vsp = transform.position.y * speed * Input.GetAxis("Vertical");

        float scrollSpd = Mathf.Log(transform.position.y) * -zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

        if ((transform.position.y >= maxHeight) && (scrollSpd > 0))
        {
            scrollSpd = 0;
        }
        else if ((transform.position.y <= minHeight) && (scrollSpd < 0))
        {
            scrollSpd = 0;
        }

        if ((transform.position.y + scrollSpd) > maxHeight)
        {
            scrollSpd = maxHeight - transform.position.y;
        }
        else if ((transform.position.y + scrollSpd) < minHeight)
        {
            scrollSpd = minHeight - transform.position.y;
        }

        Vector3 verticalMove = new Vector3(0, scrollSpd, 0);
        Vector3 lateralMove = hsp * transform.right;
        Vector3 forwardMove = transform.forward;
        forwardMove.y = 0;
        forwardMove.Normalize();
        forwardMove *= vsp;

        Vector3 move = verticalMove + lateralMove + forwardMove;

        transform.position += move;
        GetCameraRotation();
    }

    void GetCameraRotation()
    {
        float p1 = 0;
        if (Input.GetKey(KeyCode.Q))
        {
            p1 = -2;
            Debug.Log("Keypressed");
        }
        if (Input.GetKey(KeyCode.E))
        {
            p1 = 2;
        }
        float dx = p1 * rotationSpeed;
        transform.rotation *= Quaternion.Euler(new Vector3(0, dx, 0));
    }
}
