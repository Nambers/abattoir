using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manc : MonoBehaviour {
    public GameObject player;
    public GameObject all;

    private Animator ani;
    public float life = 50f;
    public void recover () {
        life = 50f;
        ani.SetBool ("die", true);
        this.GetComponent<BoxCollider> ().isTrigger = false;
    }
    public void change (float a) {
        life = life - a;
        if (life <= 0f) {
            ani.SetBool ("walk", true);
            ani.SetBool ("att1", true);
            ani.SetBool ("die", false);
            //this.GetComponent<BoxCollider> ().isTrigger = true;
        } else {
            ani.SetBool ("walk", true);
            ani.SetBool ("att1", true);
            ani.SetBool ("hurt", false);
        }
    }
    // Start is called before the first frame update
    void Start () {
        ani = this.GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update () {
        if (ani.GetBool ("die") == false || all.GetComponent<all> ().start || all.GetComponent<all> ().IsGamePaused) return;
        ani.SetBool ("hurt", true);
        if (this.tag == "unkind") {
            player = all.GetComponent<all> ().kind;
        }
        if (this.tag == "kind") {
            player = all.GetComponent<all> ().unkind;
        }
        Vector3 tar = player.transform.position;
        tar.y = transform.position.y;
        this.transform.LookAt (tar);
        if (all.GetComponent<all> ().only_c == false) {
            if (Vector3.Distance (player.transform.position, this.transform.position) > 50f) {
                this.transform.Translate (new Vector3 (0f, 0f, 0.5f), Space.Self);
                ani.SetBool ("att1", true);
                ani.SetBool ("walk", false);
            }
            if (Vector3.Distance (player.transform.position, this.transform.position) <= 50f) {
                ani.SetBool ("walk", true);
                ani.SetBool ("att1", false);
            }
        } else {
            this.transform.Translate (new Vector3 (0f, 0f, 0.5f), Space.Self);
            ani.SetBool ("walk", false);
        }

    }
}