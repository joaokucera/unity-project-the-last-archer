using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Transform _transform;

    [SerializeField]
    [Range(0.1f, 10f)]
    private float _movementSpeed;

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.Translate(Vector2.left * _movementSpeed * Time.deltaTime);
    }
}