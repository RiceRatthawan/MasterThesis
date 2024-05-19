using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetParentColor : MonoBehaviour
{
    private Renderer renderColor;
    public GameObject parentObj;
    // Start is called before the first frame update
    void Start()
    {
        renderColor = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color parentColor = parentObj.GetComponent<Renderer>().material.color;
        renderColor.material.color = parentColor;
    }
}
