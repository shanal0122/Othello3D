using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Title
{
  public class TextFlashing : MonoBehaviour
  {

    [SerializeField] private float flashSpeed = 5.0f;
    private float time = 0f;
    private Text text;

    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }

    void Update()
    {
        text.color = GetColor(text.color);
    }

    private Color GetColor(Color color)
    {
      time += Time.deltaTime * flashSpeed;
      color.a = Mathf.Abs(Mathf.Sin(time));
      return color;
    }
  }
}
