using UnityEngine;

public class AimPosition : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float defaultDistance = 100f; // 默认的射线距离

    private void FixedUpdate()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit rayCastHit))
        {
            // 如果射线击中了物体
            transform.position = rayCastHit.point;
        }
        else
        {
            // 如果没有击中任何物体，设置目标点为射线默认方向上的某个远点
            transform.position = ray.GetPoint(defaultDistance);
        }
    }
}