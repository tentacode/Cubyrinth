using UnityEngine;
using System.Collections;

public class ButtonColor : MonoBehaviour
{
    public Color hoverColor = Color.red;
    private Color initialColor;
    private bool hit = false;

	void Start ()
    {
        initialColor = GetComponent<Renderer>().material.color;    
	}

    public void Hit()
    {
        hit = true;
    }

    void LateUpdate()
    {
        if (hit)
        {
            SetColor(hoverColor);
            hit = false;
        } else {
            ResetColor();
        }
    }

    void SetColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
	
	void ResetColor ()
    {
        GetComponent<Renderer>().material.color = initialColor;
    }
}
