using CustomUpdateManagerNSP;
using UnityEngine;
using Utilities;

public class BallScript : GameplayUpdateBehaviour
{
    public float radio { get; private set; }
    [SerializeField] private float speed;
    public float Speed => speed;
    private Slider _slider;
    private PhysicsManager _physicsManager;
    private Vector2 dir;
    public Vector3 Dir => dir;
    private Transform _tr;
    public Vector2 Pos => _tr.position;
    private Vector3 _NextDir;
    [SerializeField] private float radioScaler;

    private Vector2 prevDir;

    private void Awake() //TODO take out awake, start, update. move them to a CustomUpdater
    {

        _tr = transform;
        radio = _tr.localScale.x * radioScaler;
        print("Radio " + radio);
    }

    protected override void Start()
    {
        base.Start();
        Initialize();
    }

    void Initialize()
    {
        dir = new Vector2(1, 1);
        prevDir = dir;
    }

    public void ChangeDir(float currDirX, float currDirY)
    {
        dir.x = currDirX ;
        dir.y = currDirY;
        AudioManager.instance.PlaySFXSound(AudioManager.instance.soundReferences.ballBounce);
    }

    protected override void UpdateItems()
    {
        base.UpdateItems();
        Move();
        PhysicsManager.Instance.BrickCollisionCheck(this);
        PhysicsManager.Instance.SliderCollision(this);
    }

    void Move()
    {
        Vector3 nextPosition = _tr.position;
        PhysicsManager.Instance.WallCollision(this,nextPosition + Dir * (Speed * Time.deltaTime));

       nextPosition += Dir * (Speed * Time.deltaTime);
       _tr.position = nextPosition;
    }
    
}
