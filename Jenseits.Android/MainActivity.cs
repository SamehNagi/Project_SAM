﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using RoundedBoxView.Forms.Plugin.Droid;

namespace Jenseits.Droid
{
    [Activity(Label = "Jenseits",
              Icon = "@mipmap/icon",
              Theme = "@style/MainTheme",
              MainLauncher = true,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);

            global::Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");
            Xamarin.Forms.Forms.Init(this, bundle);
            RoundedBoxViewRenderer.Init();

            LoadApplication(new App());
        }
    }
}

