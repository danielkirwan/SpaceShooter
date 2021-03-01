using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    [SerializeField]
    private GameObject _laser;
    [SerializeField]
    private GameObject _enemyLaser;

    private Player player;

    private Animator anim;
    private bool _isAlive = true;

    [SerializeField]
    private Collider2D _collider;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if (transform.position.y < -9f)
        {
            //float randomNumber = Random.Range(-9f, 10f);
            transform.position = new Vector3(Random.Range(-9f, 10f), 7f, transform.position.z);
        }
        
    }

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
        if(anim == null)
        {
            Debug.Log("Animator is null");
        }
        StartCoroutine(FireLaser());
    }

    private IEnumerator FireLaser()
    {
        while (_isAlive)
        {
            float randNum = Random.Range(1, 5);
            Debug.Log("Random number: " + randNum);
            yield return new WaitForSeconds(randNum);
            Instantiate(_enemyLaser, transform.position + new Vector3(0, -1.05f, 0), Quaternion.identity);
            Debug.Log("Enemy firing laser");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            anim.SetTrigger("EnemyDeath");
            _collider.enabled = !_collider.enabled;
            Player.sfx[2].Play();
            _isAlive = false;
            Destroy(this.gameObject,1.5f);
        }

        if (other.gameObject.tag == "Laser")
        {
            int randomNumber = Random.Range(10, 20);
            Destroy(other.gameObject);
            if(player != null)
            {
                player.UpdateScore(randomNumber);
            }
            anim.SetTrigger("EnemyDeath");
            _collider.enabled = !_collider.enabled;
            Player.sfx[2].Play();
            _isAlive = false;
            Destroy(this.gameObject, 1.5f);
        }
    }

    private void OnEnable()
    {
        _collider.enabled = !_collider.enabled;
    }
}
