using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
        //1. access level: public of private
        //2. type: int (e.g., 2, 4, 123, 3456, etc.), float(e,g, 2.5, 3.67, etc.)
        //3. name (1) start w/ lowercase (2) if it is multiple words, then the other words start with uppercase and written together
        //optional: give it an initial value

    private float horizontalInput;
    private float verticalInput;
    private float speed;
    public int lives;
    private int score;

    public GameObject bullet;

    

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        lives = 3;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Shooting();
    }

    void Moving()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);

        //if my x position is bigger than  11.5f, then I am outside the screen from the right
        if (transform.position.x >= 11.5f || transform.position.x <= -11.5f)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);

        }
        if (transform.position.y >= 8f || transform.position.y <= -8f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);

        }
    }

    void Shooting()
    {
        //if SPACE key is pressed, then create a bullet; what is a bullet?
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //create a bullet object at my position with my rotation
            Instantiate(bullet, transform.position + new Vector3(0,1,0), Quaternion.identity); 
        }

    }

    
    
    public void LoseALife()
    {
        lives = lives - 1;
        if (lives == 0)
        {
            Destroy(this.gameObject);
        }
        GameObject.Find("GameManager").GetComponent<GameManager>().LifeDisplay(1);

    }

    private void OnTriggerEnter2D(Collider2D coinCollect)
    {
        if (coinCollect.tag == "Coin")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(1);
        }
    }

    

}
