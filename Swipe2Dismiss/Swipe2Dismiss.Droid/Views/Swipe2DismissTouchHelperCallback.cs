using System;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Swipe2Dismiss.Core.ViewModels;

namespace Swipe2Dismiss.Droid.Views
{
    public class Swipe2DismissTouchHelperCallback : ItemTouchHelper.SimpleCallback
    {
        public Swipe2DismissTouchHelperCallback(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public Swipe2DismissTouchHelperCallback() : base(0, ItemTouchHelper.Left | ItemTouchHelper.Right)
        {
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            return false;
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            var holder = (MvxRecyclerViewHolder)viewHolder;
            var vm = (MyItemViewModel)holder.DataContext;
            vm.Delete();
        }
    }
}