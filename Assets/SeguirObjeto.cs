using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirObjeto : MonoBehaviour {
    public Transform player;
    public Vector3 offset = new Vector3(0, 1, -5);
    public bool OlharPara = true;
    void Start() {

    }

    void Update() {
        transform.position = player.transform.position + offset;

        if (OlharPara) {
            transform.LookAt(player);
        }
    }
}
