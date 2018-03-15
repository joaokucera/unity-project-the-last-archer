using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Arrow : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rigibody;

    [SerializeField]
    private float _movementSpeed;

    public delegate void AfterArrowHit(bool hit);
    public AfterArrowHit OnAfterArrowHit;

	private void OnEnable()
	{
        if (!_transform) {
            _transform = transform;
        }
        if (!_rigibody) {
            _rigibody = GetComponent<Rigidbody2D>();
        }

        _rigibody.velocity = Vector2.right * _movementSpeed;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
        bool isEnemy = other.CompareTag("Enemy");

        if (isEnemy) {
            var enemy = other.GetComponent<EnemyHealth>();

            if (enemy) {
                enemy.Hit();
            }
        }

        if (OnAfterArrowHit != null) {
            OnAfterArrowHit(isEnemy);
        }

        gameObject.SetActive(false);
	}
}