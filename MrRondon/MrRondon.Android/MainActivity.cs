﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.Toasts;
using Xamarin;
using Xamarin.Forms;

namespace MrRondon.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.SetFlags("FastRenderers_Experimental");
            Forms.Init(this, bundle);

            //Map
            FormsMaps.Init(this, bundle);

             DependencyService.Register<ToastNotification>();
            ToastNotification.Init(this, new PlatformOptions { SmallIconDrawable = Android.Resource.Drawable.IcDialogInfo });

            LoadApplication(new App());
        }
    }
}