using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using RecyclerViewDifferentTemplates.Core.ViewModels;

namespace RecyclerViewDifferentTemplates.Droid.Views
{
    [Activity(Label = "My Pets", Theme = "@style/Theme.AppCompat.Light")]
    public class FirstView : MvxAppCompatActivity<FirstViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

            var petList = FindViewById<MvxRecyclerView>(Resource.Id.recyclerView);
            var btnType = FindViewById<Button>(Resource.Id.btnType);
            var btnAge = FindViewById<Button>(Resource.Id.btnAge);

            btnType.Click += (s,e) => petList.ItemTemplateSelector = new TypeTemplateSelector();
            btnAge.Click += (s,e) => petList.ItemTemplateSelector = new AgeTemplateSelector();
        }
    }
}
