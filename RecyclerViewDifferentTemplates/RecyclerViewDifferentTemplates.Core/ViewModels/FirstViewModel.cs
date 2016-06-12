using System;
using System.Collections.ObjectModel;
using System.Globalization;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Converters;
using RecyclerViewDifferentTemplates.Core.ViewModels.Items;

namespace RecyclerViewDifferentTemplates.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        public ObservableCollection<PetViewModelBase> Pets { get; }

        public FirstViewModel()
        {
            Pets = new ObservableCollection<PetViewModelBase>
            {
                new CatViewModel {Age = 10, LifesLeft = 6, Name = "Paul"},
                new CatViewModel {Age = 1, LifesLeft = 9, Name = "Horst"},
                new FishViewModel {Age = 1, Fins = 2, Name = "Nemo"},
                new CatViewModel {Age = 16, LifesLeft = 4, Name = "Erna"},
                new CatViewModel {Age = 5, LifesLeft = 6, Name = "Nougat"},
                new FishViewModel {Age = 12, Fins = 2, Name = "Marlin"},
                new FishViewModel {Age = 9, Fins = 5, Name = "Sharky"},
                new CatViewModel {Age = 7, LifesLeft = 1, Name = "Tirebiter"},
                new CatViewModel {Age = 8, LifesLeft = 6, Name = "Moritz"},
                new FishViewModel {Age = 2, Fins = 5, Name = "Barsch"},
                new FishViewModel {Age = 4, Fins = 20, Name = "Finny"},
                new FishViewModel {Age = 8, Fins = 3, Name = "Klaus"},
                new FishViewModel {Age = 1, Fins = 1, Name = "Pirat"},
                new CatViewModel {Age = 3, LifesLeft = 9, Name = "Mickey"}
            };
        }
    }
}
