using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour {
    public float speed = 5;

    void Start() {

    }
    void Update() {
        Move();
    }
    public void Move() {

        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.position += Movement * speed * Time.deltaTime;

    }
}
