using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.SimpleAndroidNotifications { 

    public class NotificationScript : MonoBehaviour {
        
        public void SendNotification() {
            NotificationManager.Send(TimeSpan.FromSeconds(5),
                "FoodSmash",
                "Speel een nieuw spel met je vrienden!",
                Color.white);
            CloseApplication();
        }

        private void CloseApplication() {
            Application.Quit();
        }
    }
}