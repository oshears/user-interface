using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OSGames.UserInterface {

    public class ImageMaterialChanger : MonoBehaviour {
        public Material m_Material_A;
        public Material m_Material_B;

        Image m_TargetImage;

        public void Awake(){
            m_TargetImage = GetComponent<Image>();
        }

        public void ChangeMaterial(bool active){
            m_TargetImage.material = active ? m_Material_A : m_Material_B;
        }
    }

}