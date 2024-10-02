using System.Collections.Generic;
using Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

namespace OSGames.UserInterface{
    public class ResetAnchoredPositionOnEnable : MonoBehaviour
    {

        void OnEnable(){
            Vector2 pos = GetComponent<RectTransform>().anchoredPosition;
            GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, 0);
        }

    }

}
