﻿using Acr.UserDialogs;

using Android.App;
using Android.Runtime;

namespace SOHome.Fitness
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
            UserDialogs.Init(this);
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}