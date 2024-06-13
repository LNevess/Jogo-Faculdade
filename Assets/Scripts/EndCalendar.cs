using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCalendar : MonoBehaviour
{

    public int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 5)
        {
            Debug.Log("Escreve");
        }
    }
}
