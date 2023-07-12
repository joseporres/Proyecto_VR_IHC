using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HpCounter : MonoBehaviour
{
    protected GameObject textObject;
    protected TextMeshPro textMeshPro;
    public int currentHpCounter;
    public Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        currentHpCounter = this.gameObject.GetComponent<ObjectLife>().currentHp;
        textObject = new GameObject();
        textMeshPro = textObject.AddComponent<TextMeshPro>();
        textMeshPro.text = currentHpCounter.ToString();
        textMeshPro.fontSize = 1.3f;
        textMeshPro.alignment = TextAlignmentOptions.Center;
        textMeshPro.color = Color.white;

        GameObject canvasObj = new GameObject("Canvas");
        canvasObj.transform.SetParent(transform);
        canvasObj.transform.localPosition = Vector3.zero;
        canvasObj.transform.localRotation = Quaternion.identity;
        canvasObj.transform.localScale = Vector3.one;
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        canvasObj.AddComponent<RectTransform>();
        textMeshPro.transform.SetParent(canvas.transform);
        RectTransform rectTransform = textMeshPro.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-39.588f,47.31f, 1.08f);
        rectTransform.localRotation = new Quaternion(0, 0, 0, 0);
        //anchor
        rectTransform.anchorMin = new Vector2(1, 0);
        rectTransform.anchorMax = new Vector2(1, 0);
        //pivot
        rectTransform.pivot = new Vector2(1, 0);

        //Add Image next to text (to the left)
        GameObject imageObj = new GameObject("Image");
        imageObj.transform.SetParent(canvas.transform);
        imageObj.transform.localPosition = new Vector3(-39.588f, 46.959f, 0.6600075f);
        imageObj.transform.localRotation = new Quaternion(0, 0, 0, 0);
        imageObj.transform.localScale = Vector3.one;
        Image image = imageObj.AddComponent<Image>();
        image.sprite = sprite;
        image.color = Color.white;
        RectTransform imageRectTransform = imageObj.GetComponent<RectTransform>();
        imageRectTransform.localPosition = new Vector3(-49.7267f, 49.75126f, 1.08f);
        imageRectTransform.localRotation = new Quaternion(0, 0, 0, 0);

        //anchor
        imageRectTransform.anchorMin = new Vector2(1, 0);
        imageRectTransform.anchorMax = new Vector2(1, 0);
        //pivot
        imageRectTransform.pivot = new Vector2(1, 0);
        //size
        imageRectTransform.sizeDelta = new Vector2(0.1f,0.1f);

        
        
    }

    //  Update is called once per frame
    void Update()
    {
        currentHpCounter = this.gameObject.GetComponent<ObjectLife>().currentHp;
        textMeshPro.text = currentHpCounter.ToString();
    }
}
