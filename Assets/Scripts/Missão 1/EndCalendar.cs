using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCalendar : MonoBehaviour
{

    public int count;
    public GameObject vitoria; 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 5)
        {
            vitoria.SetActive(true);
        }
    }
}
