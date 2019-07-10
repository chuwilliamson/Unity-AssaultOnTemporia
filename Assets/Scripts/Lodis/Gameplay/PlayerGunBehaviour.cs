﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lodis.Gameplay
{
    public class PlayerGunBehaviour : MonoBehaviour
    {
        [SerializeField]
        private GameObject BulletEmitter1;
        [SerializeField]
        private GameObject BulletEmitter2;
        [SerializeField]
        private GameObject BulletEmitter3;
        [SerializeField]
        private bool HasSpreadshot;
        [SerializeField]
        private bool HasLongshot;
        [SerializeField]
        private bool HasQuickshot;
        [SerializeField]
        private bool HasNormalShot;
        [SerializeField]
        private float BulletLimit;
        private float Timer;
        private GunBehaviour Gun1;
        private GunBehaviour Gun2;
        private GunBehaviour Gun3;
        [SerializeField]
        private GunMode CurrentMode;
        private int Counter;
        private enum GunMode
        {
            Normal,
            Longshot,
            SpreadShot,
            QuickShot
        }

        private void Start()
        {
            Gun1 = BulletEmitter1.GetComponent<GunBehaviour>();
            Gun2 = BulletEmitter2.GetComponent<GunBehaviour>();
            Gun3 = BulletEmitter3.GetComponent<GunBehaviour>();
        }
        public void PullTrigger()
        {
            
            switch (CurrentMode)
            {
                case GunMode.Normal:
                    {
                        NormalShot();
                        break;
                    }
                    
                case GunMode.Longshot:
                    {
                        LongShot();
                        break;
                    }
                case GunMode.SpreadShot:
                    {
                        SpreadShot();
                        break;
                    }
                    
                case GunMode.QuickShot:
                    {
                        QuickShot();
                        break;
                    }
                    
            }
        }
        public void Restart()
        {
            CurrentMode = 0;
            Counter = 0;
        }
        public void SpreadShot()
        {
            var newtime = Timer + Time.deltaTime;
            if (newtime >= BulletLimit)
            {
                Gun1.Player = tag;
                Gun1.DespawnTime = .3f;
                Gun2.DespawnTime = .3f;
                Gun3.DespawnTime = .3f;
                Gun1.Fire();
                Gun2.Fire();
                Gun3.Fire();
                Timer = 0;
            }
                
            else
            {
                Timer = newtime;
            }
        }
        public void LongShot()
        {
            var newtime = Timer + Time.deltaTime;
            if (newtime >= BulletLimit)
            {
                Gun1.Player = tag;
                Gun1.DespawnTime = 20;
                Gun1.Fire();
                Timer = 0;
            }
            else
            {
                Timer = newtime;
            }
        }
        public void QuickShot()
        {
            Gun1.Player = tag;
            Gun1.DespawnTime = 20;
            Gun1.Fire();
        }
        public void NormalShot()
        {
            var newtime = Timer + Time.deltaTime;
            if (newtime >= BulletLimit)
            {
                Gun1.Player = tag;
                Gun1.DespawnTime = .5f;
                Gun1.Fire();
                Timer = 0;
            }
            else
            {
                Timer = newtime;
            }
        }
        public void Upgrade()
        {
            if (Counter >= 3)
            {
                return;
            }
            CurrentMode++;
            Counter++;
        }
        public void Downgrade()
        {
            if (CurrentMode == 0)
            {
                return;
            }
            CurrentMode--;
            Counter--;
        }
    }
}