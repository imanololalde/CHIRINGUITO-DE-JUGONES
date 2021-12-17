using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marcador : MonoBehaviour {
    
    public static int value = 10;
    Text score;

    // Start is called before the first frame update
    void Start() {
        score = GetComponent<Text> ();   
    }

    // Update is called once per frame
    void Update() {
        score.text = "Balones restantes: " + value;   
    }
}
