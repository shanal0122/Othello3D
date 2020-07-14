using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Review : MonoBehaviour
{

    public void OpenReview()
    {
      Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSe8WEYdxBFFnxRkGotibx-VfGlPFrJ6Ik5VTWN3MRh90nscRQ/viewform?usp=sf_link");
    }
}
