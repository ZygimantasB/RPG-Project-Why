using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] // priverčia public tapti private
    private Transform target; //Jei aš padarau private aš negaliu pasiketi target iš Unity

    // Update is called once per frame
    void LateUpdate()
    {
        if (!target) //Jei mes neturime taikinio mums jį reikia grąžinti, jei turi taikinį jį grąžink
        {
            return;
        }


        float currentRotationAngle = transform.eulerAngles.y; // kampas, kuriame esu // kamera sukasi rotacijoje
        float wanterRoatationAngle = target.eulerAngles.y;  // Rotacija į kurią aš nueiti (norima rotacija) // mūsų 

       

        //linijinis interpoliacijos metodas, kur tu gali interpeliuoti reik6mes, tarp dviejų reikšmių
        currentRotationAngle = Mathf.LerpAngle( // jis duos tarpines reikšmes tarp mano p[radinės reikšmės į reikšmė, kurioje norėčiau būti 
                                                // iš pradžių aš būsoi 90 > 95 > 100 > 105 > 110, visksa keisis po vieną kadrą,
                                                // iki mano reikšmės bus nueita per kelis žingsnius, net per vieną
                                                //tokiu atvėju mano judeliai taps daug lengvesniom švaresni
            currentRotationAngle, //a mūsų dabartinė reikšmė
            wanterRoatationAngle,  //b reikšmė, kurioje aš norėčiau būti
            0.5f);    // t koks didelis pakeitimas bus tarp dviejų reikšmių, kuo mažesnis skaičius, tuo mano kamera judės tolygiau švariau
                        // 0 mano rotacija nepasikeis
                        
        transform.position = new Vector3(
            target.position.x,
            5.0f,
            target.position.z);

        // currentRotationAngle laipsnis pasukamas aplink Y ašį
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0); // currentRotation norės pasakyti, kiek mes norėsime pasisukti. 

        //pasukta vektorių pirmyn currentRotationAngle kampo laipsniu aplink Y ašį
        Vector3 rotatedPosition = currentRotation * Vector3.forward; 

        transform.position -= rotatedPosition * 10; // mano kamera nuo žaidėjo bus atgal 10 vienetų

        transform.LookAt(target);
    }
}
 