using UnityEngine;
using UnityEngine.InputSystem;  

public class ModelControl : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float RotateSpeed = 90f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.isPressed == true)
        {
            transform.Translate(transform.forward * MoveSpeed * Time.deltaTime);
        }
        if (Keyboard.current.sKey.isPressed == true)
        {
            transform.Translate(transform.forward * -MoveSpeed * Time.deltaTime);
        }
        if (Keyboard.current.aKey.isPressed == true)
        {
            transform.Rotate(Vector3.up * -RotateSpeed * Time.deltaTime);
        }
        if (Keyboard.current.dKey.isPressed == true)
        {
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
        }

    }
}
