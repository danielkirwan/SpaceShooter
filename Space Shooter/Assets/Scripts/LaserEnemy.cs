using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * _speed * Time.deltaTime);
        if (transform.position.y < -8)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            DestroyLaser();
        }

    }

    void DestroyLaser()
    {
        Destroy(this.gameObject);
    }
}
