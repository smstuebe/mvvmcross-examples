using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using MvvmCross.Binding.Droid;
using MvvmCross.Binding.Droid.Binders;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;

namespace Calligraphy.Droid.Views
{

    public class MyFactory : MvxAndroidViewFactory
    {
        private CalligraphyFactory _factory;

        public MyFactory()
        {
            _factory = new Calligraphy.CalligraphyFactory(Resource.Attribute.fontPath);
        }

        public override View CreateView(View parent, string name, Context context, IAttributeSet attrs)
        {
            var view = base.CreateView(parent, name, context, attrs);
            view = _factory.OnViewCreated(view, context, attrs);
            Console.WriteLine($"---- view: {name}");
            return view;
        }
    }


    class MyBindingBuilder : MvxAndroidBindingBuilder
    {
        protected override IMvxAndroidViewFactory CreateAndroidViewFactory()
        {
            return new MyFactory();
        }
    }

    [Activity(Label = "View for FirstViewModel", Theme = "@style/Theme.AppCompat.Light")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            CalligraphyConfig.InitDefault(new CalligraphyConfig.Builder()
               .SetDefaultFontPath("fonts/gtw.ttf")
               .SetFontAttrId(Resource.Attribute.fontPath)
               .DisablePrivateFactoryInjection()
               // Adding a custom view that support adding a typeFace
               // .AddCustomViewWithSetTypeface(Java.Lang.Class.FromType(typeof(CustomViewWithTypefaceSupport)))
               // Adding a custom style
               // .AddCustomStyle(Java.Lang.Class.FromType(typeof(TextField)), Resource.Attribute.textFieldStyle)
               .Build());

            //var originalInflater = LayoutInflater.From(this);
            //var newInflater = originalInflater.CloneInContext(originalInflater.Context);
            //newInflater.Factory = myCustomFactory;
            //Setin

            //var mvxFactory = LayoutInflaterCompat.GetFactory(LayoutInflater);
            //var myViewFactory = new MyViewFactory(mvxFactory);
            //LayoutInflaterCompat.SetFactory(LayoutInflater, myViewFactory);

            SetContentView(Resource.Layout.FirstView);
        }

        //protected override void AttachBaseContext(Android.Content.Context @base)
        //{

        //    base.AttachBaseContext(CalligraphyContextWrapper.Wrap(@base));
        //}

        //public override View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
        //{
        //    Console.WriteLine($">>>>> view: {name}");
        //    var view = base.OnCreateView(parent, name, context, attrs);
        //    var x = pullFontPathFromView(this, attrs, new[] {Resource.Attribute.fontPath});
        //    //attrs.GetAttributeValue(null, "lc")
        //    view = _factory.OnViewCreated(view, context, attrs);
        //    Console.WriteLine($"---- view: {name}");
        //    return view;
        //}
    }
}
