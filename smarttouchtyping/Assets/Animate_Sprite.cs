using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animate_Sprite : MonoBehaviour
{
    public Sprite[] Frame;
    public Image Target;
    public bool Play = true;

    public float FPS = 2;

    // Start is called before the first frame update
    void Start()
    {
        Target = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Play) {
            var index = (Time.time * FPS) % Frame.Length;
            Target.sprite = Frame[(int)index];
        }
    }
}
