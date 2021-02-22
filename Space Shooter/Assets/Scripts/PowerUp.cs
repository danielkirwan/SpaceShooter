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
            if(player != null)
            {
                //if(powerUpID == 0)
                //{
                //    player.ActivateTripleShot();
                    
                //}else if(powerUpID == 1)
                //{
                //    player.ActivateSpeedIncrease();
                //}else if (powerUpID == 2)
                //{
                //    //shield stuff TODO
                //}

                switch (powerUpID)
                {
                case 0 : 
                    player.ActivateTripleShot();
                    break;
                case 1:
                    player.ActivateSpeedIncrease();
                    break;
                case 2:
                    Debug.Log("Collected shields");
                    break;
                }
                
            }
            Destroy(this.gameObject);
        }
    }

}
