using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //Toman los valores del Input Manager
    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";
    private string interactButton = "interact";


    //Variables que usamos para el controlador
    private float horizontal;
    private float vertical;
    public bool interactPressed;


    private void Update()
    {
        interactPressed = Input.GetButtonUp(interactButton);
        horizontal = Input.GetAxis(horizontalAxis);
        vertical = Input.GetAxis(verticalAxis);
    }

    //Devuelve un vector con la dirección de movimiento
    public Vector2 GetDirection()
    {
        return new Vector2(horizontal, vertical);
    }
}
