using System;
using System.Collections.Generic;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using RecyclerViewDifferentTemplates.Core.ViewModels.Items;

namespace RecyclerViewDifferentTemplates.Droid
{
    public class TypeTemplateSelector : IMvxTemplateSelector
    {
        private readonly Dictionary<Type, int> _typeMapping;

        public TypeTemplateSelector()
        {
            _typeMapping = new Dictionary<Type, int>
            {
                {typeof(CatViewModel), Resource.Layout.pet_cat},
                {typeof(FishViewModel), Resource.Layout.pet_fish}
            };
        }

        public int GetItemViewType(object forItemObject)
        {
            return _typeMapping[forItemObject.GetType()];
        }

        public int GetItemLayoutId(int fromViewType)
        {
            return fromViewType;
        }
    }
}