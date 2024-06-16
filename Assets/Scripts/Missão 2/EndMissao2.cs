using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMissao2 : MonoBehaviour
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
        if (count == 4)
        {
            vitoria.SetActive(true);
        }
    }

}
