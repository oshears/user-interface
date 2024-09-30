using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OSGames.UserInterface.Selectables {

    public class LimitedToggleGroup {

        // TODO: good polish to later have this unselect old toggles
        // Queue<Toggle> m_ToggleActivationQueue;

        List<Toggle> m_Toggles;
        public List<Toggle> toggles {
            get {
                return m_Toggles;
            }
        }

        int m_MaxToggles = 1;
        public int MaxToggles{
            get { return m_MaxToggles;}
            set { m_MaxToggles = value; }
        }

        public LimitedToggleGroup(int maxToggles = 1){
            m_MaxToggles = maxToggles;
            m_Toggles = new List<Toggle>();
        } 

        public void AddAndSubscribeToToggle(Toggle tg){
            m_Toggles.Add(tg);
            tg.onValueChanged.AddListener(OnValueChanged);
        }

        public void SubsribeToToggles(){
            foreach (Toggle tg in m_Toggles){
                tg.onValueChanged.AddListener(OnValueChanged);
            }
        }

        public void UnsubscribeFromToggles(){
            foreach (Toggle tg in m_Toggles){
                tg.onValueChanged.RemoveListener(OnValueChanged);
            }
        }

        public List<Toggle> GetActiveToggles(){
            List<Toggle> activeToggles = new List<Toggle>();
            
            foreach(Toggle tg in m_Toggles){
                if (tg.isOn){
                    activeToggles.Add(tg);
                }
            }

            return activeToggles;
        }

        public void DestroyToggles(){
            foreach (Toggle tg in m_Toggles){
                // check if object is destroyed before accessing it
                if (tg) {
                    Object.Destroy(tg.gameObject);
                }
            }
            m_Toggles.Clear();
        }

        public void OnValueChanged(bool isOn){
            
        }
        
        
    }

}
