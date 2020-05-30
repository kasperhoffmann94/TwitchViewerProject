using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Java.Lang.Reflect;
using TwitchViewerApp.Interfaces;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(TwitchViewerApp.Droid.RandomImageService))]
namespace TwitchViewerApp.Droid
{
    public class RandomImageService : IRandomImage
    {

        Random random = new Random();
        int drawableFolderCount = (from file in Directory.EnumerateFiles(@"C:\Users\kaspe\source\repos\TwitchViewerProject\TwitchViewerApp\TwitchViewerApp.Android\Resources\drawable", "*.jpg", SearchOption.AllDirectories) select file).Count();


        public int GetRandomImageIndex()
        {
            int randomIndex = random.Next(0, drawableFolderCount);
            string name = "Image" + randomIndex;
            int resourceId = (int)typeof(Resource.Drawable).GetField(name + randomIndex).GetValue(null);
            return resourceId;
        }


    }
}