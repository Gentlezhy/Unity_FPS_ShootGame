using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private float _bulletForce = 2000f;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.forward * _bulletForce, ForceMode.Force);

        Destroy(gameObject, 5f);
    }
}
