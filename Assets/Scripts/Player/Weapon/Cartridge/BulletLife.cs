using UnityEngine;

public class BulletLife : MonoBehaviour, ICartridge
{
    [SerializeField] private float _speed;

    private int _damage;

    public void Init(int damage)
    {
        _damage = damage;
    }

    private void Update()
    {
        if (GameplayController.IsPlaying) transform.position += Vector3.right * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<IEnemyLife>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Zone")) Destroy(gameObject);
    }
}
