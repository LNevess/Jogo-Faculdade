using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialog", menuName = "Dialog System/Dialog")]
public class Dialog : ScriptableObject
{
    [TextArea(3, 10)]
    public List<string> sentences;
}
