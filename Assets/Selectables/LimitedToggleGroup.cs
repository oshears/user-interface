using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OSGames.UserInterface.Selectables {

    public class LimitedToggleGroup : ToggleGroup {

        // void Start(){
            
        // }

        // void OnEnable(){

        // }

        // void OnDisable(){

        // }


        // /// <summary>
        // /// Notify the group that the given toggle is enabled.
        // /// </summary>
        // /// <param name="toggle">The toggle that got triggered on.</param>
        // /// <param name="sendCallback">If other toggles should send onValueChanged.</param>
        // override public void NotifyToggleOn(Toggle toggle, bool sendCallback = true)
        // {
        //     base.ValidateToggleIsInGroup(toggle);
        //     // disable all toggles in the group
        //     for (var i = 0; i < m_Toggles.Count; i++)
        //     {
        //         if (m_Toggles[i] == toggle)
        //             continue;

        //         if (sendCallback)
        //             m_Toggles[i].isOn = false;
        //         else
        //             m_Toggles[i].SetIsOnWithoutNotify(false);
        //     }

        //     //TODO: disable extra toggles if too many selected
        // }
        
    }

}
