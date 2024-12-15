using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Rigidbody _rigidbody;
    
    protected virtual void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }
}
