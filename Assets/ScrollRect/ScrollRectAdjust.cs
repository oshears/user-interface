using System.Collections.Generic;
using Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollRectAdjuster : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    private RectTransform contentRect;
    private List<Transform> elements;

    [SerializeField] Transform m_ParentTransform;


    void Start()
    {
        contentRect = scrollRect.content;


        elements = new List<Transform>();


        for(int i = 0; i < m_ParentTransform.childCount; i++){
            elements.Add(m_ParentTransform.GetChild(i));
        }
            



        // for (int k = 0; k < 15; k++)
        // {
        //     GameObject go = Instantiate(ElementPrefab, contentRect.transform);
        //     go.GetComponentInChildren<TextMeshProUGUI>().text = k.ToString();
        //     elements.Add(go);
        // }
        
        foreach (Transform go in elements)
        {
            Debug.Log($"Adding event trigger for select for: {go}");
            EventTrigger eventTrigger = go.GetComponent<EventTrigger>();

            eventTrigger.AddListener(EventTriggerType.Select, OnMove);
        }
        scrollRect.verticalNormalizedPosition = 0;
        // EventSystem.current.SetSelectedGameObject(elements[0]);
    } 

    private void OnDestroy()
    {
        foreach (Transform go in elements)
        {
            EventTrigger eventTrigger = go.GetComponentInChildren<EventTrigger>();
            // eventTrigger.RemoveListener(EventTriggerType.Select, OnSelect);
            // eventTrigger.RemoveListener(EventTriggerType.UpdateSelected, OnSelect);
            eventTrigger.RemoveListener(EventTriggerType.Move, OnMove);
        }
    }  

    private void OnMove(BaseEventData baseEventData)
    {
        // Debug.Log($"new object selected: {baseEventData}");
        RectTransform selectedRectTransform = baseEventData.selectedObject.GetComponent<RectTransform>();

        // contentRect.anchoredPosition = new Vector2(contentRect.anchoredPosition.x, -1 * selectedRectTransform.position.y);
        // contentRect.position = new Vector2(contentRect.anchoredPosition.x, -1 * selectedRectTransform.position.y);
        contentRect.anchoredPosition = new Vector2(contentRect.anchoredPosition.x, -1 * selectedRectTransform.anchoredPosition.y - 50f);
        
        // var height = scrollRect.GetComponent<RectTransform>().rect.height;
        // var contentHeight = contentRect.rect.height;
        // var overflow = (contentHeight - height) / 2f; 
        
        // var bottomBorder = overflow - selectedRectTransform.offsetMin.y;
        // var topBorder = -(overflow + (selectedRectTransform.offsetMax.y - contentHeight));

        // if (bottomBorder > contentRect.anchoredPosition.x)
        //     contentRect.anchoredPosition = new Vector2(contentRect.anchoredPosition.x, leftBorder);
        // else if (topBorder < contentRect.anchoredPosition.x)
        //     contentRect.anchoredPosition = new Vector2(contentRect.anchoredPosition.x, rightBorder);
    }
}
