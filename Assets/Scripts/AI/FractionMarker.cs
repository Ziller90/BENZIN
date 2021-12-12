using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class FractionMarker : MonoBehaviour
{
    public enum Fraction
    {
        Red,
        Blue,
        Green,
        None
    }
    public Fraction objectFraction;

    public Material red;
    public Material blue;
    public Material green;
    public Material grey;
    public List<MeshRenderer> bodyParts;

    Fraction OldFraction;
    private void Start()
    {
        OldFraction = objectFraction;
    }
    private void Update()
    {
        Fraction NewFraction = objectFraction;
        if (NewFraction != OldFraction)
        {
            ChangeColor();
            OldFraction = NewFraction;
        }
    }
    public void ChangeColor()
    {
        switch (objectFraction)
        {
            case Fraction.Blue:
                SetFractionColor(blue);
                break;
            case Fraction.Red:
                SetFractionColor(red);
                break;
            case Fraction.Green:
                SetFractionColor(green);
                break;
            case Fraction.None:
                SetFractionColor(grey);
                break;
        }
    }
    public void SetFractionColor(Material newMaterial)
    {
        foreach(MeshRenderer bodyPart in bodyParts)
        {
            bodyPart.material = newMaterial;
        }
    }

}
