using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fight1 : MonoBehaviour {

    // Start is called before the first frame update
    void Start () {

    }
    private void OnTriggerEnter (Collider col) {
        Transform aa = Most (col.gameObject.transform);
        if (col.gameObject.tag == "body") {
            if (aa.tag == "kind" || aa.tag == "unkind") {
                aa.GetComponent<manc> ().change (10f);
            } else {
                aa.GetComponent<man1> ().change (5f);
            }
        }
        if (col.gameObject.tag == "leg") {
            if (aa.tag == "kind" || aa.tag == "unkind") {
                aa.GetComponent<manc> ().change (5f);
            } else {
                aa.GetComponent<man1> ().change (5f);

            }
        }
    }
    // Update is called once per frame
    void Update () {

    }
    Transform Most (Transform a) {
        if (a.parent == null) {
            return a;
        } else {
            return Most (a.parent);
        }
    }
}