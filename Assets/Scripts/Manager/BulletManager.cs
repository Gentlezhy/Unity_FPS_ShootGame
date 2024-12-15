using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private string _bulletPrefabPath = "Prefabs/Bullet";
    private GameObject _bulletPrefab;
    private float _fireRate = 0.05f; // 每发子弹的间隔时间
    private float _lastFireTime; // 上一次发射的时间

    private void OnEnable()
    {
        GameEvent.OnFire += HandleFire;
        _bulletPrefab = Resources.Load<GameObject>(_bulletPrefabPath);
    }

    private void OnDisable()
    {
        GameEvent.OnFire -= HandleFire;
    }

    private void HandleFire(string playerName, string weaponType, Transform firePoint)
    {
        // 当前时间
        float currentTime = Time.time;

        // 如果距离上次发射时间大于或等于发射间隔，则发射子弹
        if (currentTime - _lastFireTime >= _fireRate)
        {
            _lastFireTime = currentTime; // 更新上一次发射时间
            // 实例化子弹
            GameObject bullet = Instantiate(_bulletPrefab, firePoint.position, firePoint.rotation);
            //Debug.Log($"firePoint Position: {firePoint.position}");
        }
    }
}