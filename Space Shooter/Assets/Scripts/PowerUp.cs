using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private int powerUpID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            //Player.sfx[3].Play();
            if(player != null)
            {
                switch (powerUpID)
                {
                case 0 : 
                    player.ActivateTripleShot();
                        Player.sfx[6].Play();
                        break;
                case 1:
                    player.ActivateSpeedIncrease();
                        Player.sfx[5].Play();
                        break;
                case 2:
                        player.ActivateShield();
                        Player.sfx[4].Play();
                        break;
                }
                
            }
            Destroy(this.gameObject);
        }
    }

}
