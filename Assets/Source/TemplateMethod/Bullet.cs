using UnityEngine;

namespace TemplateMethod
{
    public class Bullet : MonoBehaviour
    {
        [Tooltip("Время жизни пули в секундах")]
        [SerializeField] private float lifeTime = 5f;

        private void Start()
        {
            Destroy(gameObject, lifeTime);
        }
    }
}