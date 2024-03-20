using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TextObject : SimpleObject
{
    [TextArea]
    public string description;

    void Start()
    {
        typeOfPuzzle = "Text";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        Debug.Log(description);
        //Afficher sur l'UI la description de l'objet
        //Prevoir plusieurs variantes

    }

}
