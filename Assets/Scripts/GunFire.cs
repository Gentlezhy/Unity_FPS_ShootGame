using UnityEngine;

public class GunFire : MonoBehaviour
{
    public Transform playerGun;
    public Transform firePoint;
    public GameObject bulletPrefab;
    
    private bool _isFire;

    private void Update()
    {
        GetInput();
        
    }

    private void FixedUpdate()
    {
        //必须把此方法放在FixedUpdate中,否则子弹位置会出现问题,也就是说游戏的所有信息都是依赖于FixedUpdate进行更新的,如果Update晚于更新FixedUpdate,这会导致用户实际的界面的子弹信息可能是好久之前的了
        Fire();
    }

    private void Fire()
    {
        if (_isFire)
        {
            // 创建子弹实例
            // GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    
            // 确保子弹已经初始化完成后再触发事件
            GameEvent.OnFire.Invoke("Player", "M4_8", firePoint);
            // 创建实例由BulletManager处理
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(firePoint.position, 0.05f);
    }

    private void GetInput()
    {
        _isFire = Input.GetMouseButton(0);
    }
}
