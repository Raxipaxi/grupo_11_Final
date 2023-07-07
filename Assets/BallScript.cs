using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

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
    private Brick[] _bricks;
    void Start()
    {
    }

    void Update()
    {
        // WallDetectionX(transform.position.x,_wallLocation.x);
        CollisionCheck(transform.position, _wallLocation);
        BrickDetection();
        // WallDetectionY(transform.position.y,_wallLocation.y);
        // CheckForCollsion(_wallLocation);
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

    public void AssignProperties(Vector2 wallLocation, Brick[] bricks)
    {
        _wallLocation = wallLocation;
        _bricks = bricks;
    }
    void CollisionCheck(Vector3 position, Vector3 objectPos)
    {
        if (position.x >= objectPos.x - radio || position.x <= -objectPos.x + radio)
        {
            speed.x *= -1;
        }
        if (position.y >= objectPos.y - radio || position.y <= -objectPos.y + radio)
        {
            speed.y *= -1;
        }
    }
    void BrickDetection()
    {
        foreach (var brick in _bricks)
        {
            if (brick.gameObject.activeInHierarchy)
            {
                if (Vector3.Distance(transform.position, brick.transform.position) < radio)
                {
                    brick.gameObject.SetActive(false);
                    speed *= -1;
                }
            }

        }
    }

    void Move()
    {
        transform.position += speed * Time.deltaTime;
    }
    
}
