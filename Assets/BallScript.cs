using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float radio = 0.5f;
    [SerializeField] private float scale = 1f;
    [SerializeField] private Vector3 speed;
    // [SerializeField] private PaletaScript paletaDerecha;
    //Paletas
    private float paredHorizontal = 5f;
    private float paredVertical = 9.5f;
    private Vector2 _wallLocation;
    private float paletaLocation = 8.5f;
    void Start()
    {
    }

    void Update()
    {
        WallDetectionX(transform.position.x,_wallLocation.x);
        WallDetectionY(transform.position.y,_wallLocation.y);
        Move();
        #region Deprecado

        // if (transform.position.x >= paletaLocation - radio)
        // {
        //     float paletaD = paletaDerecha.transform.position.y; //Saco posicion paleta derecha en Y
        //     //Si entro dentro del rango de la Paleta Derecha (teniendo encuenta su posicion y la altura de ella)
        //     if (transform.position.y <= paletaD + paletaDerecha.altura && transform.position.y >= paletaD - paletaDerecha.altura)
        //     {
        //         velocidad.x = -Mathf.Abs(velocidad.x);  //Va en el sentido contrario
        //     }
        // } 
        
        // if(transform.position.x >= paredVertical - radio) //Si toque la pared Vertical Derecha, hize punto con la Izquierda
        // {
        //     OnIzquierdaPoints?.Invoke();
        //     pointsSound.Play();
        //     ResetPosition();
        // }
        //
        //
        // if(transform.position.x <= -paredVertical + radio)         //Si toque la Pared Vertical Izquierda, hice punto con Derecha
        // {
        //     OnDerechaPoints?.Invoke();
        //     pointsSound.Play();
        //     ResetPosition();
        // }
        //
        // if (canMove) //MOVIMIENTO
        // {
        //     //La gravedad es una aceleracion, no una fuerza 
        //     //La gravedad me modifica a la velocidad, la velocidad me modifica a la posicion
        //     //gravedad -> velocidad -> posicion
        //
        //     //Formula de velocidad instanea: v = v + a * time
        //     velocidad += gravedad * Time.deltaTime; 
        //
        //     //Formula MRUV: Xf = Xi + Vi * time + 1/2 a * t^2 
        //     transform.position += velocidad * Time.deltaTime + 0.5f * gravedad * Time.deltaTime * Time.deltaTime;
        // }

        #endregion

    }

    public void AssignProperties(Vector2 wallLocation)
    {
        _wallLocation = wallLocation;
    }
    void WallDetectionX(float position, float wallLocationPosition)
    {
        //REBOTE EN X: Calculo la posicion en y de la pelota vs. la posicion de la pared horizontal menos/más el radio de la pelota. 
        if (position >= wallLocationPosition - radio)
            speed.x = -Mathf.Abs(speed.x); //Invierto la velocidad, haciendo que vaya en el sentido contrario

        if (position <= -wallLocationPosition + radio)
            speed.x = Mathf.Abs(speed.x);      

    }

    void WallDetectionY(float position, float wallLocationPosition)
    {        //REBOTE EN X: Calculo la posicion en y de la pelota vs. la posicion de la pared horizontal menos/más el radio de la pelota. 
        if (position >= wallLocationPosition - radio)
            speed.y = -Mathf.Abs(speed.y); //Invierto la velocidad, haciendo que vaya en el sentido contrario

        if (position <= -wallLocationPosition + radio)
            speed.y = Mathf.Abs(speed.y);
        
    }
    void ResetPosition() //Reseteo posicion de la pelota e inicio el timer para poder moverme
    {
        transform.position = Vector3.zero; //Vuelvo al lugar inicial
    }

    void Move()
    {
        transform.position += speed * Time.deltaTime;
    }
    
}
