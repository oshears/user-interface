using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


namespace OSGames.UserInterface {

    public class MaintainGridSelectableNavigation : MonoBehaviour {
        
        List<Selectable> m_Selectables;

        int previousCount;

        [SerializeField] 

        private void Awake() {
            m_Selectables = new List<Selectable>();
        }

        void Update(){

            if (transform.childCount != 0 && transform.childCount != previousCount){
                GetComponentsInChildren(false,m_Selectables);
                SetupNavigation();
            }

            // if ()

        }

        /// <summary>
        /// Basic left and right navigation of child selectables.
        /// TODO: setup grid traversal (up, down, left and right)
        /// </summary>
        void SetupNavigation(){
            if (m_Selectables == null){
                Debug.LogWarning("Setup navigation was called but no selectables available to configure.");
                return;
            }
            for(int i = 0; i < m_Selectables.Count; i++){
                Navigation nav = new Navigation();
                nav.selectOnLeft = i > 0 ? m_Selectables[i - 1] : m_Selectables[m_Selectables.Count - 1]; 
                nav.selectOnUp = nav.selectOnLeft;
                nav.selectOnRight = i < m_Selectables.Count - 1 ? m_Selectables[i + 1] : m_Selectables[0]; 
                nav.selectOnDown = nav.selectOnRight;
            }
        }
    }
}