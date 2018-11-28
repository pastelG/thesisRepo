using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question {

    [TextArea (3, 10)]
    public string question;

    public string ansC;
    public string ansW1, ansW2, ansW3;

    
}
