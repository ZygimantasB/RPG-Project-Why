using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGAdventure
{
    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public float roatationSpeed;

        private Vector3 m_Movement;
        private Rigidbody m_Rb;
        private Quaternion m_Rotation; // Rotacija yra laikoma Quaternion



        private void Start()
        {
            m_Rb = GetComponent<Rigidbody>();

            var camera = GetComponent<FollowCamera>(); //Neveikia

        }
        void FixedUpdate()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            m_Movement = new Vector3(horizontalInput, 0, verticalInput);
            m_Movement.Normalize();

            Vector3 desiredForward = Vector3.RotateTowards( // Mano Player stengsis žiūrėti į priekį
                transform.forward,
                m_Movement,
                Time.fixedDeltaTime * roatationSpeed,
                0);


            m_Rotation = Quaternion.LookRotation(desiredForward);

            m_Rb.MovePosition(m_Rb.position + m_Movement * speed * Time.deltaTime); //MovePostition naudojamas, kai yra
            m_Rb.MoveRotation(m_Rotation);                                          //pridedamas ridgetbody ir norima kad mano player
                                                                                    //suktūsi aplinkui x ir negali pasisukti, nes 
                                                                                    // kitu atvėju nugriūs (aš padariau frozen)


            

        }
    }
}


