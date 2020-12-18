// Not Used

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public InputField Red;
    public InputField Green;
    public InputField Blue;

    public Material Side1;
    public Material Side2;
    public Material Side3;
    public Material Side4;
    public Material Side5;
    public Material Side6;

    public Material SelectedMaterial;

    public void ChangeMaterialColor(string name)
    {
        switch(name)
        {
            case "Side1":
                SelectedMaterial = Side1;
                break;

            case "Side2":
                SelectedMaterial = Side2;
                break;

            case "Side3":
                SelectedMaterial = Side3;
                break;

            case "Side4":
                SelectedMaterial = Side4;
                break;

            case "Side5":
                SelectedMaterial = Side5;
                break;

            case "Side6":
                SelectedMaterial = Side6;
                break;
        }

        Red.interactable = true;
        Green.interactable = true;
        Blue.interactable = true;

        Red.text = (SelectedMaterial.color.r * 255).ToString();
        Green.text = (SelectedMaterial.color.g * 255).ToString();
        Blue.text = (SelectedMaterial.color.b * 255).ToString();
    }

    public void UpdateMaterialColor()
    {
        if (int.TryParse(Red.text, out int r) && int.TryParse(Green.text, out int g) && int.TryParse(Blue.text, out int b))
        {
            r /= 255;
            g /= 255;
            b /= 255;

            SelectedMaterial.color = new Color(r, g, b);
        }
    }
}
