using Core;

namespace RunAndTagCore;

public class Player : IPlayer
{
    private float _direction;

    public float X { get; set; }
    public float Y { get; set; }
    public float RayStep;
    public float MaxRayDistance;
    public float Fov;
    public float RotationVelocity;
    public float MovementVelocity;

    public float Direction
    {
        set
        {
            if (value > 360f)
            {
                _direction = 0f;
                return;
            }

            if (value < 0f)
            {
                _direction = 360f;
                return;
            }

            _direction = value;
        }
        get => _direction;
    }

    public Player(
        float x,
        float y,
        float direction,
        float rayStep,
        float maxRayDistance,
        float fov,
        float rotationVelocity,
        float movementVelocity
    )
    {
        X = x;
        Y = y;
        Direction = direction;
        RayStep = rayStep;
        MaxRayDistance = maxRayDistance;
        Fov = fov;
        RotationVelocity = rotationVelocity;
        MovementVelocity = movementVelocity;
    }

    public Player Copy() => new Player(
        X,
        Y,
        Direction,
        RayStep,
        MaxRayDistance,
        Fov,
        RotationVelocity,
        MovementVelocity
    );
}