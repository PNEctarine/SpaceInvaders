using UnityEngine;

public class WeaponDropComponent : MonoBehaviour
{
    public int WeaponIndex;
    [SerializeField] private float _speed;

    private void Update()
    {
        gameObject.transform.position += _speed * Time.deltaTime * Vector3.down;

        if (gameObject.transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }
}
