using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerHeadGrip;
    public Transform playerBody;

    [SerializeField]
    private Camera mainCamera;
    
    private readonly float _mouseSensitivity = 600f;
    private float _xRotation;
    private float _yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }
    
    void Update()
    {
        LookAt();
    }

    private void LookAt()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        // 更新视角旋转 原点在屏幕正中心
        _xRotation -= mouseY;
        _yRotation += mouseX;
        _xRotation = Mathf.Clamp(_xRotation, -60f, 60f);
        
        playerHeadGrip.localRotation = Quaternion.Euler(_xRotation, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
        playerBody.localRotation = Quaternion.Euler(gameObject.transform.rotation.x, _yRotation, gameObject.transform.rotation.z);
        

        // 设置相机旋转（相对角色头部的旋转）
        mainCamera.transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
    }
}