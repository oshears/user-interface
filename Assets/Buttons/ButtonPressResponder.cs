using UnityEngine;
using UnityEngine.UI;

namespace OSGames.UserInterface {

    [RequireComponent(typeof(Button))]
    public abstract class ButtonPressResponder : MonoBehaviour {

        Button m_Button;

        protected virtual void Awake(){
            m_Button = GetComponent<Button>();
            m_Button.onClick.AddListener(OnButtonPress);
        }

        public abstract void OnButtonPress();
        
    }
}
