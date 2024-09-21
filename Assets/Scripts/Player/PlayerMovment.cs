using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    [Range(-20, 20)]
    [SerializeField] public float speed = 6;
    [SerializeField] public ParticleSystem GreenParticles;
    [SerializeField] public ParticleSystem WhiteParticles;
    [SerializeField] public float jumpForce; //7
    [SerializeField] public float downForce; //4

    // Start is called before the first frame update
    void Start()
    {
        var emmision = GreenParticles.emission;
        emmision.enabled = false;
        var WhiteEmmision = WhiteParticles.emission;
        WhiteEmmision.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "GameOver")
        {
            SceneManager.LoadScene("Respawn");
        }
        if (col.gameObject.tag == "Platform")
        {
            var emmision = GreenParticles.emission;
            emmision.enabled = true;
            var WhiteEmmision = WhiteParticles.emission;
            WhiteEmmision.enabled = false;
        }
        else
        {
            //var emmision = GreenParticles.emission;
            //emmision.enabled = false;
            
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        var emmision = GreenParticles.emission;
        emmision.enabled = false;
        var WhiteEmmision = WhiteParticles.emission;
        WhiteEmmision.enabled = true;
    }

    void HandleMovement()
    {
        //Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2(-1, 0) * speed;
        }
        //Right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2(1, 0) * speed;
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        //Downforce
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.down / downForce, ForceMode2D.Impulse);
        }
    }
}
