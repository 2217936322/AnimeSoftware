﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using hazedumper;

namespace AnimeSoftware
{
    class BHop
    {
        public static bool strafe = false;
        public static void Start()
        {
            while (true)
            {
                Thread.Sleep(1);

                if (!Properties.Settings.Default.bhop)
                    continue;
                if (!LocalPlayer.InGame)
                    continue;
                if (LocalPlayer.Health <= 0)
                    continue;
                if (LocalPlayer.Speed <= 0)
                    continue;

                Vector3 oldAngle = LocalPlayer.ViewAngle;

                while ((DllImport.GetAsyncKeyState(0x20) & 0x8000) != 0)
                {
                    Thread.Sleep(1);

                    if (Properties.Settings.Default.autostrafe)
                    {
                        strafe = true;
                        Vector3 cuurentAngle = LocalPlayer.ViewAngle;
                        if (cuurentAngle.y > oldAngle.y)
                        {
                            LocalPlayer.MoveLeft();
                        }
                        else if (cuurentAngle.y < oldAngle.y)
                        {
                            LocalPlayer.MoveRight();
                        }
                    }

                    if (LocalPlayer.Flags == 257 || LocalPlayer.Flags == 263)
                    {
                        LocalPlayer.Jump();
                    }
                    oldAngle = LocalPlayer.ViewAngle;
                }
                if (strafe)
                {
                    LocalPlayer.MoveClearY();
                    strafe = false;
                } 

                
            }
        }
    }
}
