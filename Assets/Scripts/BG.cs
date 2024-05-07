using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//this code is for the background
public class BG : MonoBehaviour
{
    public float scroll_speed = 0.1f;
    private MeshRenderer m_MeshRenderer;
    private float scroller;
    void Awake()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Scroll();
    }
    void Scroll()
    {
        scroller = Time.time * scroll_speed;
        Vector2 offset = new Vector2(scroller, 0f);
        m_MeshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
