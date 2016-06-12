using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using RecyclerViewDifferentTemplates.Core.ViewModels.Items;

namespace RecyclerViewDifferentTemplates.Droid
{
    public class AgeTemplateSelector : MvxTemplateSelector<PetViewModelBase>
    {
        public override int GetItemLayoutId(int fromViewType)
        {
            return fromViewType;
        }

        protected override int SelectItemViewType(PetViewModelBase forItemObject)
        {
            if (forItemObject.Age <= 1)
                return Resource.Layout.pet_age_young;
            else if (forItemObject.Age <= 10)
                return Resource.Layout.pet_age_adult;
            return Resource.Layout.pet_age_old;
        }
    }
}