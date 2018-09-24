using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject player;
    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;
    //public GameObject wall;
    public Transform EndPositionGO;
    public Transform StartPositionGO;

    private Rigidbody rb;
    private int count;
    private int score;
    //private GameObject wall;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetAllText();
        //SetCountText ();
        winText.text = "";


    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();

        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);  // deletes yellow box
            count = count + 1;  // increments yellow count
            score = score + 1;  // increases score
            //SetCountText();
            SetAllText();   // refresh game text
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);  // deletes red box
            score = score - 1;  // decreaeses score
            SetAllText();
        }

        if (count == 12)
            {
            transform.position = new Vector3(20.0f, player.transform.position.y, 3.0f);
            }

    }

    void SetAllText() 
    //void SetCountText ()
    {
        scoreText.text = "Score: " + score.ToString();
        countText.text = "Count: " + count.ToString();
        if (count >= 18)
        {
            winText.text = "You Finished with a score of: " + score.ToString();
        }
    }

}