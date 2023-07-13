using UnityEngine;
using Utilities;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float radio = 0.5f;
    [SerializeField] private Vector2 speed;
    public Vector2 Speed => speed;
    private Vector2 _wallLocation;

    private float _bricksY;
    // private Brick[] _bricks;
    private Slider _slider;
    private PhysicsManager _physicsManager;
    private Vector2 dir;
    private MeshRenderer _renderer;
    public Vector2 Dir => dir;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        radio = _renderer.bounds.extents.magnitude;
    }

    void Start()
    {
        dir = new Vector2(1, 1);
        
    }

    void ChangeDir(float currDirX, float currDirY)
    {
        dir.x = currDirX ;
        dir.y = currDirY;
    }
    void Update()
    {
        CollisionCheck();
        Move();
    }

    public void AssignProperties(Vector2 wallLocation, float bricksY, Slider slider, PhysicsManager manager)
    {
        _wallLocation = wallLocation;
        _bricksY = bricksY;
        // _bricks = bricks;
        _slider = slider;
        _physicsManager = manager;
    }
    // void BrickDetection()
    // {
    //     foreach (Brick brick in _bricks)
    //     {
    //         if (brick.gameObject.activeInHierarchy)
    //         {
    //             if (BrickCollisionCheck(brick))
    //             {
    //                 if (brick.isBreakable)
    //                 {
    //                     brick.Hit();
    //                 }
    //             }
    //         }
    //
    //     }
    // }
    

    void CollisionCheck()
    {
        WallCollision();
        DetectSlider();
        // DetectBricks();
    }

    #region Deprecated
    // void SliderCollision()
    // {
    //     if (transform.position.y - radio <= _slider.transform.position.y)
    //     {
    //         if (transform.position.x + radio <= _slider.transform.position.x - _slider.Size.x/2) // Si toco la mitad del lado izquierdo (negativo) me voy para x en el lado izquierdo
    //         {
    //             speed.x = Math.Abs(speed.x) * -1;
    //         }
    //         if (transform.position.x + radio >= _slider.transform.position.x  + _slider.Size.x / 2)
    //         {
    //             speed.x = Math.Abs(speed.x);
    //         }
    //         speed.y = Math.Abs(speed.y);
    //     }
    // }
    

    #endregion

    void DetectSlider()
    {
        if (transform.position.y + radio <= _slider.transform.position.y + _slider.Size.y)
        {
            ChangeDir(_physicsManager.SliderCollision(this,radio).x, _physicsManager.SliderCollision(this,radio).y);
        }

    }
    void DetectBricks()
    {
        if(transform.position.y < _bricksY){return;}
        
        ChangeDir(dir.x * _physicsManager.BrickCollisionCheck(this, radio).x, dir.y * _physicsManager.BrickCollisionCheck(this, radio).y);
    }
    void WallCollision()
    {
        if (transform.position.x - radio <= 0 || transform.position.x + radio >= _wallLocation.x)
        {
            ChangeDir(dir.x * -1, dir.y);
        }

        if (transform.position.y - radio <= 0 ||transform.position.y + radio >= _wallLocation.y)
        {
            ChangeDir(dir.x, dir.y * -1);
        }
    }

    void Move()
    {
        transform.position += new Vector3(speed.x* dir.x, speed.y * dir.y, 0)  * Time.deltaTime;
    }
    
}
