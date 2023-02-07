using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public float jump = 100f;
    public Rigidbody2D rb;
    public Transform ball;

    public string currentColor;
    public SpriteRenderer sr;

    public Color Blue;
    public Color Yellow;
    public Color Pink;
    public Color Purple;

    private void Start()
    {
        RandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = UnityEngine.Vector2.up * jump;
        }
        if (GameObject.Find("Ball").transform.position.y < -50f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(Input.GetKeyDown("d"))
        {
            ball.transform.position += new UnityEngine.Vector3(4, ball.position.y, ball.position.z).normalized;
        }
        if (Input.GetKeyDown("a"))
        {
            ball.transform.position += new UnityEngine.Vector3(-3, ball.position.y, ball.position.z).normalized;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name!=currentColor && collision.tag!="colorchanger")
        {
            UnityEngine.Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        if(collision.tag=="colorchanger")
            
        {
            RandomColor();
            Destroy(collision.gameObject);
        }
        if(collision.name=="changelevel2")
        {
            SceneManager.LoadScene("Level2");
        }
        if (collision.name == "changelevel3")
        {
            SceneManager.LoadScene("Level3");
        }
        if (collision.name == "return")
        {
            SceneManager.LoadScene("Level1");
        }
        
    }

    public void RandomColor()
    {
        int color = Random.Range(0, 3);
        switch(color)
        {
            case 0:
                currentColor = "Blue";
                sr.color = Blue;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = Yellow;
                break;
            case 2:
                currentColor = "Pink";
                sr.color = Pink;
                break;
            case 3:
                currentColor = "Purple";
                sr.color = Purple;
                break;
        }
    }

}
