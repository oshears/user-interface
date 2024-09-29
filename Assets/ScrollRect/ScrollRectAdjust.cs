using System.Collections.Generic;
using Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

namespace OSGAmes.UserInterface{
    public class ScrollRectAdjuster : MonoBehaviour
    {
        [SerializeField] private ScrollRect scrollRect;
        private RectTransform contentRect;
        private List<Transform> elements;

        [SerializeField] Transform m_ParentTransform;

        [SerializeField] float m_ContentHeight;


        void Start()
        {
            
        } 

        void OnEnable(){
            ConfigureScrollAdjust();
        }

        public void ConfigureScrollAdjust(){
            contentRect = scrollRect.content;


            elements = new List<Transform>();


            for(int i = 0; i < m_ParentTransform.childCount; i++){
                elements.Add(m_ParentTransform.GetChild(i));
            }
                
            foreach (Transform go in elements)
            {
                Debug.Log($"Adding event trigger for select for: {go}");
                EventTrigger eventTrigger = go.GetComponent<EventTrigger>();

                eventTrigger.AddListener(EventTriggerType.Select, OnMove);
            }
            scrollRect.verticalNormalizedPosition = 0;
        }

        void OnDisable(){
            ReleaseScrollAdjust();
        }

        public void ReleaseScrollAdjust(){
            foreach (Transform go in elements)
            {
                EventTrigger eventTrigger = go.GetComponentInChildren<EventTrigger>();
                // eventTrigger.RemoveListener(EventTriggerType.Select, OnSelect);
                // eventTrigger.RemoveListener(EventTriggerType.UpdateSelected, OnSelect);
                eventTrigger.RemoveListener(EventTriggerType.Move, OnMove);
            }
        }

        private void OnDestroy()
        {
            
        }  

        private void OnMove(BaseEventData baseEventData)
        {
            RectTransform selectedRectTransform = baseEventData.selectedObject.GetComponent<RectTransform>();


            // contentRect.anchoredPosition = new Vector2(contentRect.anchoredPosition.x, -1 * selectedRectTransform.anchoredPosition.y - 50f);
            Vector2 newContentPosition = new Vector2(contentRect.anchoredPosition.x, -1 * selectedRectTransform.anchoredPosition.y);
            DOTween.To(GetAnchoredPosition,SetAnchoredPosition,newContentPosition,0.25f);
            // contentRect.anchoredPosition = 
        }

        Vector2 GetAnchoredPosition(){
            return contentRect.anchoredPosition;
        }

        void SetAnchoredPosition(Vector2 newPosition){
            contentRect.anchoredPosition = newPosition;
        }
    }
}