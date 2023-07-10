using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector2 mousePos;
    private float Speed = 5f;
    private float Minx = -7f;
    private float Maxx = 2.7f;
    private float Miny = 3.4f;
    private float Maxy = -3.4f;
    void Start()
    {
        
             mousePos = transform.position;
    }

    void Update()
    {
        Control();
    }

    public  void Control()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        float clampedX = Mathf.Clamp(mousePos.x, Minx, Maxx); 
        float clampedY = Mathf.Clamp(mousePos.y, Miny, Maxy); 
        //Vector3 clampedMousePos = new Vector3(clampedX, clampedY, transform.position.z); 
        transform.position = Vector3.Lerp(transform.position, mousePos,Speed * Time.deltaTime);
    }
     
}
