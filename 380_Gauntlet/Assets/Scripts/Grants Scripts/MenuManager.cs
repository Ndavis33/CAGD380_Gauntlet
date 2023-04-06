using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Material redMat; 
    public Material blueMat; 
    public Material yellowMat; 
    public Material greenMat; 
    public GameObject avatar1;
    public GameObject avatar2;
    public GameObject avatar3;
    public GameObject avator4;

    private Color _red;
    private Color _blue;
    private Color _yellow;
    private Color _green;

    private void Awake()
    {
        _red = redMat.color;
        _blue = blueMat.color;
        _yellow = yellowMat.color;
        _green = greenMat.color;
    }

    private Color NextMat(GameObject avatar)
    {
        Color avatarMat = avatar.GetComponent<Renderer>().material.color;

        if (avatarMat == _red)
            return _blue;
        else if (avatarMat == _blue)
            return _yellow;
        else if (avatarMat == _yellow)
            return _green;
        else return _red;       
    }

    public void Player1Forward()
    {
        avatar1.GetComponent<Renderer>().material.color = NextMat(avatar1);
    }
}
