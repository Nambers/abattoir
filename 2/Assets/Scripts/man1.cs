using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class man1 : MonoBehaviour
{
    private float health = 100f;
    public GameObject all;
    float l;
    public GameObject health_c;
    public Animator ani;
    private Rigidbody rb;
    public float speed = 1f;
    public GameObject target;
    public GameObject player;
    private bool ong;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ground")
        {
            ong = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "ground")
        {
            ong = false;
        }
    }
    public void change(float a)
    {
        health -= a;
        if (health <= 0)
        {
            if (this.tag == "player2") all.GetComponent<all>().die(1);
            if (this.tag == "player1") all.GetComponent<all>().die(2);
        }
        print(health);
        l = 0.0118f * health;
        health_c.transform.localScale = new Vector3(0.007875001f, 0.07390626f, l);
    }
    // Start is called before the first frame update
    void Start()
    {

        Vector3 tar = player.transform.position;
        tar.y = transform.position.y;
        this.transform.LookAt(tar);
    }

    // Update is called once per frame
    void Update()
    {
        string tag = this.tag;
        if (all.GetComponent<all>().start) return;
        if (this.name == all.GetComponent<all>().g1.name || this.name == all.GetComponent<all>().g2.name)
        {
            if (all.GetComponent<all>().IsGamePaused == false)
            {
                ani = this.GetComponent<Animator>();
                ani.SetBool("walk", true);
                ani.SetBool("att", true);
                rb = this.GetComponent<Rigidbody>();
                if (tag == "player1") target = all.GetComponent<all>().g2;
                if (tag == "player2") target = all.GetComponent<all>().g1;
                Vector3 tar = target.transform.position;
                tar.y = transform.position.y;
                this.transform.LookAt(tar);
                float moveHorizontal = 0;
                float moveVertical = 0;
                ani.SetBool("walk", true);
                if (tag == "player1")
                {
                    if (Input.GetKey("w"))
                    {
                        moveVertical = +1;
                        ani.SetBool("walk", false);
                    }
                    if (Input.GetKey("s"))
                    {
                        moveVertical = -1;
                        ani.SetBool("walk", false);
                    }
                    if (Input.GetKey("a"))
                    {
                        moveHorizontal = -1;
                        ani.SetBool("walk", false);
                    }
                    if (Input.GetKey("g"))
                    {
                        if (ong) rb.AddForce(Vector3.up * 700);
                    }
                    if (Input.GetKey("d"))
                    {
                        moveHorizontal = +1;
                        ani.SetBool("walk", false);
                    }
                    if (!all.GetComponent<all>().only_c)
                    {
                        if (Input.GetKey(KeyCode.F))
                        {
                            ani.SetBool("att", false);
                        }
                        else { ani.SetBool("att", true); }
                    }
                }
                if (tag == "player2")
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        moveVertical = +1;
                        ani.SetBool("walk", false);
                    }
                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        moveVertical = -1;
                        ani.SetBool("walk", false);
                    }
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        moveHorizontal = -1;
                        ani.SetBool("walk", false);
                    }
                    if (Input.GetKey("."))
                    {
                        if (ong) rb.AddForce(Vector3.up * 700);
                    }
                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        moveHorizontal = +1;
                        ani.SetBool("walk", false);
                    }

                    if (!all.GetComponent<all>().only_c)
                    {
                        if (Input.GetKey("/"))
                        {
                            ani.SetBool("att", false);
                        }
                        else { ani.SetBool("att", true); }
                    }
                }
                this.transform.Translate(new Vector3(speed * moveHorizontal, 0f, speed * moveVertical), Space.Self);
            }
        }

    }
}

