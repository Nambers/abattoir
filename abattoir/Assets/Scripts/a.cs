using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    public GameObject all;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag== "kill")
        {
            print("kill");
            if(this.tag=="player1")all.GetComponent<all>().die(2);
            if (this.tag == "player2") all.GetComponent<all>().die(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
