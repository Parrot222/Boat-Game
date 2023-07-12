using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public float speed, rotate;
    private float move;
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        float dir = ((Input.GetKey("w")?1:0) - (Input.GetKey("s")?1:0));
        move = Mathf.Lerp(move, dir, Time.deltaTime);
        transform.position += transform.forward * move * speed * Time.deltaTime;

        //Rotation
        if (move < 0.1f) return;
        if(Input.GetKey("d")) transform.eulerAngles += transform.up * rotate * Time.deltaTime;
        else if (Input.GetKey("a")) transform.eulerAngles -= transform.up * rotate * Time.deltaTime;

        //Shader
        Shader.SetGlobalVector("_Player", transform.position);
        cam.transform.position = transform.position + Vector3.up * 10;
    }
}
