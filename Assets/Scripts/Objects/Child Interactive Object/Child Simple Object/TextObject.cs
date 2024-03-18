using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextObject : SimpleObject
{
    [TextArea]
    public string description;
    private StateMode stateScript;
    public TextMeshProUGUI currentInteractionText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stateScript.GetPuzzleMode())
        {
        
        }
    }


    public override void Interact()
    {
        Debug.Log(description);
        //Afficher sur l'UI la description de l'objet
        //Prevoir plusieurs variantes

    }

}
