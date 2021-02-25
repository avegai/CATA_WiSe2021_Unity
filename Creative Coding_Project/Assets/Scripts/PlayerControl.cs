using UnityEngine;


public class PlayerControl : MonoBehaviour {

    public float flySpeedBase = 10f;
    public float mouseSensitivity = 500f;
    public float smoothTime = 10f;
    public Vector3 positionSaved2;
    public Vector3 rotationSaved2;
    public Vector3 positionSaved3;
    public Vector3 rotationSaved3;

    private float speedFactorMove;
    private float speedFactorMoveDelta;
    private float speedFactorRot;
    private float speedFactorRotDelta;
    private Vector3 smoothVelocity = Vector3.zero;
    private Vector3 smoothAngularVelocity = Vector3.zero;
    private Vector3 positionInit;
    private Vector3 rotationInit;

    void Start () 
    {
        speedFactorMove = speedFactorRot = 1f;
        speedFactorMoveDelta = 0.01f;
        speedFactorRotDelta = 0.001f;
        rotationInit = transform.eulerAngles;
        positionInit = transform.position;
    }

    void Update () 
    {
        var flySpeed = flySpeedBase * speedFactorMove;

        // Base Settings
        var deltaXTarget = Input.GetAxis("Horizontal") * flySpeed;
        var deltaZTarget = Input.GetAxis("Vertical") * flySpeed;
        var deltaYTarget = Input.GetAxis("Vertical Y") * flySpeed / 3;

        var mouseX = Input.GetAxis("Mouse Y") * mouseSensitivity * speedFactorRot;
        var mouseY = Input.GetAxis("Mouse X") * mouseSensitivity * speedFactorRot;

        // Set speed
        if ( Input.GetButton( "Speed Up" ) ) 
        {
            speedFactorMove *= (1 + speedFactorMoveDelta);
            speedFactorRot *= (1 + speedFactorRotDelta);
        } 
        else if ( Input.GetButton( "Speed Down" ) ) 
        {
            speedFactorMove *= (1 - speedFactorMoveDelta);
            speedFactorRot *= (1 - speedFactorRotDelta);
        } 
        else if ( Input.GetButton( "Speed Reset" )) 
        {
            speedFactorMove = speedFactorRot = 1f;
        } 
        speedFactorMove = Mathf.Clamp(speedFactorMove, speedFactorMoveDelta, 100);
        speedFactorRot = Mathf.Clamp(speedFactorRot, speedFactorRotDelta, 10);


        // Reset to saved positions
        if (
            Input.GetButtonDown( "Button Y" ) ||
            Input.GetButtonDown( "Button B" ) ||
            Input.GetButtonDown( "Button A" )
        ) 
        {
            if ( Input.GetButtonDown( "Button Y") ) 
            {
                transform.position = positionInit;
                transform.eulerAngles = rotationInit;
            } 
            else if ( Input.GetButtonDown( "Button B" )  ) 
            {
                transform.position = positionSaved2;
                transform.eulerAngles = rotationSaved2;
            } 
            else if ( Input.GetButtonDown( "Button A" )) 
            {
                transform.position = positionSaved3;
                transform.eulerAngles = rotationSaved3;
            }
            Input.ResetInputAxes();
            smoothAngularVelocity = Vector3.zero;
            smoothVelocity = Vector3.zero;
        }
        // move
        else 
        {
            //Rotation of Character and Camera
            Vector3 delta = transform.TransformDirection(new Vector3(deltaXTarget, deltaYTarget, deltaZTarget));
            transform.position += Vector3.SmoothDamp(
                            Vector3.zero, delta,
                            ref smoothVelocity, smoothTime);
            Vector3 angular_delta = new Vector3(mouseX, mouseY, 0);
            Vector3 angular_delta_smooth = Vector3.SmoothDamp(
                            Vector3.zero, angular_delta,
                            ref smoothAngularVelocity, smoothTime);

            angular_delta_smooth.x = Mathf.Clamp(angular_delta_smooth.x, -180, 180);
            angular_delta_smooth.y = Mathf.Clamp(angular_delta_smooth.y, -180, 180);
            transform.eulerAngles = new Vector3(
                    MyClamp((transform.eulerAngles.x + angular_delta_smooth.x) % 360),
                    (transform.eulerAngles.y + angular_delta_smooth.y) % 360,
                    transform.eulerAngles.z
            );
        }
        Camera.main.transform.eulerAngles = transform.eulerAngles;
    }

    // Clamp rotation to reasonable values
    float MyClamp(float x) {
        if (x > 89 && x < 91) { x = 89; }
        else if (x > 269 && x < 271) { x = 271; }
        return x;
    }
}
