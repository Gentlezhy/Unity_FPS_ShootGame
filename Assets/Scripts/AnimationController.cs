using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator; // Animator 组件

    // 动画参数
    private readonly int _inputXParam = Animator.StringToHash("inputX");
    private readonly int _inputYParam = Animator.StringToHash("inputY");
    private readonly int _jumpParam = Animator.StringToHash("IsJumping");
    private readonly int _attackParam = Animator.StringToHash("IsAttacking");
    private readonly int _aimParam = Animator.StringToHash("IsAiming");

    // 单例实例
    private static AnimationController _instance;

    public static AnimationController Instance
    {
        get
        {
            if (_instance == null)
            {
                // 尝试在场景中查找一个实例
                _instance = FindObjectOfType<AnimationController>();

                if (_instance == null)
                {
                    // 如果找不到实例，则创建一个新的空对象并附加组件
                    GameObject singletonObject = new GameObject("AnimationController");
                    _instance = singletonObject.AddComponent<AnimationController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // 如果已有实例且不是当前实例，销毁当前实例以确保单例唯一性
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        // 如果需要跨场景保持，取消注释以下行
        // DontDestroyOnLoad(gameObject);

        // 获取 Animator 组件
        _animator = GetComponent<Animator>();
    }

    private void SetAnimation(int parameterName, bool state)
    {
        _animator.SetBool(parameterName, state);
    }

    private void SetAnimation(int parameterName, int parameterName2, float value, float value2)
    {
        _animator.SetFloat(parameterName, value);
        _animator.SetFloat(parameterName2, value2);
    }

    // 提供快速调用常用动画参数的方法
    public void SetMoving(float inputX, float inputY)
    {
        SetAnimation(_inputXParam, _inputYParam, inputX, inputY);
    }

    public void SetJumping(bool isJumping)
    {
        SetAnimation(_jumpParam, isJumping);
    }

    public void SetAttacking(bool isAttacking)
    {
        SetAnimation(_attackParam, isAttacking);
    }
    
    public void SetAiming(bool isAiming)
    {
        SetAnimation(_aimParam, isAiming);
    }
}