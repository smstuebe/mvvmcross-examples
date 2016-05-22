using Android.App;
using Android.OS;
using Android.Support.V7.Widget.Helper;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Swipe2Dismiss.Core.ViewModels;

namespace Swipe2Dismiss.Droid.Views
{
    [Activity(Label = "Swipe2Dismiss Demo", Theme = "@style/Theme.AppCompat.Light")]
    public class FirstView : MvxAppCompatActivity<FirstViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

            var cardView = FindViewById<MvxRecyclerView>(Resource.Id.recyclerView);
            var itemTouchHelper = new ItemTouchHelper(new Swipe2DismissTouchHelperCallback());
            itemTouchHelper.AttachToRecyclerView(cardView);
        }
    }
}
