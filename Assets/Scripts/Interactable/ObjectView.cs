using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ObjectView : Interactable
{
    
    [SerializeField] private string _objectSubscribe;
    
    [SerializeField] private Text _objectText;

    private void Awake()
    {
        _objectText = GameObject.Find("ObjectNameText").GetComponent<Text>();
    }

    public override void Interactive()
    {
        if (_objectText.color.a >0)
        {
            StartCoroutine(Fade(_objectText, 0, .2f));
        }
        else
        {
            base.Interactive();
            _objectSubscribe = this.gameObject.name;
            _objectText.text = _objectSubscribe;
            StartCoroutine(Fade(_objectText, 1, .2f));
        }
    }
    
    IEnumerator Fade(Text text, float targetAlpha, float time)
    {
        Color currentColor = text.color;
        while (true)
        {
            if (currentColor.a < targetAlpha)
            {
                currentColor.a += Time.deltaTime / time;
                if (currentColor.a > targetAlpha)
                {
                    currentColor.a = targetAlpha;
                    break;
                }
            }
            else
            {
                currentColor.a -= Time.deltaTime / time;
                if (currentColor.a < targetAlpha)
                {
                    currentColor.a = targetAlpha;
                    break;
                }
            }
            text.color = currentColor;
            yield return null;
        }
        text.color = currentColor;
    }
}
