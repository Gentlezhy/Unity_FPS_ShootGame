using UnityEngine;


public class CharacterMovement : PlayerController
{
    private static readonly float WalkVelocity = 2f;
    private static readonly float RunVelocity = 4.5f;
    
    private float _speed;
    
    private bool _isAiming;
    private bool _isRunning;
    private Vector2 _input;
    private Vector2 _smoothInput; // 用于平滑输入
    private float _moveIntensity;
    private readonly float _smoothFactor = 0.05f; // 控制平滑过渡的速度，调小平滑因子

    private void Update()
    {
        GetInput();
        SetAnimation();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // 根据角色朝向调整输入方向
        Vector3 direction = transform.forward * _smoothInput.y + transform.right * _smoothInput.x;

        // 根据角色的朝向计算速度
        Vector3 velocity = new Vector3(direction.x * _speed, _rigidbody.velocity.y, direction.z * _speed);

        // 应用到 Rigidbody
        _rigidbody.velocity = velocity;
    }


    private void GetInput()
    {
        // 获取水平和垂直方向上的输入
        Vector2 targetInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // 使用 Lerp 平滑过渡输入
        _smoothInput = Vector2.Lerp(_smoothInput, targetInput, _smoothFactor);

        // 调整移动强度
        _isRunning = Input.GetKey(KeyCode.LeftShift);
        // 动态调整 _moveIntensity
        float targetIntensity = _isRunning ? 1f : 0.5f; // 目标强度
        _moveIntensity = Mathf.Lerp(_moveIntensity, targetIntensity, 5f * Time.deltaTime);// 此变量用于设置动画Blend的强度
        _speed = _isRunning ? RunVelocity : WalkVelocity;

        _isAiming = Input.GetMouseButton(1);
    }

    private void SetAnimation()
    {
        // 使用平滑输入值来控制动画
        //float inputMagnitude = _smoothInput.magnitude;
        AnimationController.Instance.SetMoving(_smoothInput.x, _smoothInput.y * _moveIntensity);
        AnimationController.Instance.SetAiming(_isAiming);
        //_animator.SetFloat("speed", inputMagnitude);  // 控制速度动画
    }
}