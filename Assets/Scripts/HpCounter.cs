using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HpCounter : MonoBehaviour
{
    protected GameObject textObject;
    protected TextMeshPro textMeshPro;
    public int currentHpCounter;
    // Start is called before the first frame update
    void Start()
    {
        currentHpCounter = this.gameObject.GetComponent<ObjectLife>().currentHp;
        textObject = new GameObject();
        textMeshPro = textObject.AddComponent<TextMeshPro>();
        textMeshPro.text = currentHpCounter.ToString();
        textMeshPro.fontSize = 2f;
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
        rectTransform.localPosition = new Vector3(0.918f,-0.85f, 1f);
        rectTransform.localRotation = new Quaternion(0, 0, 0, 0);
        
    }

    //  Update is called once per frame
    void Update()
    {
        currentHpCounter = this.gameObject.GetComponent<ObjectLife>().currentHp;
        textMeshPro.text = currentHpCounter.ToString();
    }
}
