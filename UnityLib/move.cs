using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	// Use this for initialization
    Vector3 va = new Vector3();
    Vector3 vb = new Vector3();
    Vector3 vc = new Vector3();
	void Start () {
        qa = Quaternion.Euler(300, 300, 300);
        qb = Quaternion.Euler(12, 13, 14);
        va = qa.eulerAngles;
        vb = qb.eulerAngles;
        vc = va + vb;
        this.transform.rotation = Quaternion.Euler(vc);
	}
    Quaternion qa = new Quaternion();
    Quaternion qb = new Quaternion();
    Quaternion qc = new Quaternion();
    int count = 0;
	// Update is called once per frame
	void Update () {
        count++;
        //this.transform.rotation = Quaternion.Euler(count, 145, 155);

	}
}
