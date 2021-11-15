using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // ruch wokół osi Y będzie wykonywany na obiekcie gracza, więc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;
    private Vector3 oldRotation;

    void Start()
    {
        // zablokowanie kursora na środku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
        oldRotation = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        oldRotation.x = transform.rotation.eulerAngles.x;
        oldRotation.y = transform.rotation.eulerAngles.y;
        // pobieramy wartości dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        //print(transform.rotation.eulerAngles.x+  " " + transform.rotation.eulerAngles.y +  " " +transform.rotation.eulerAngles.z + " " + mouseYMove);
        if(transform.rotation.eulerAngles.z == 180) //&& mouseYMove > 0
        {
            transform.rotation = Quaternion.Euler(oldRotation);
        }
        // wykonujemy rotację wokół osi Y
        player.Rotate(Vector3.up * mouseXMove);

        // a dla osi X obracamy kamerę dla lokalnych koordynatów
        // -mouseYMove aby uniknąć ofektu mouse inverse
        transform.Rotate(new Vector3(-mouseYMove, 0f, 0f), Space.Self);
       
    }
}
