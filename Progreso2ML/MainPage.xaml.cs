using Newtonsoft.Json;
using Progreso2ML.Models;
using Progreso2ML.ViewModel;

namespace Progreso2ML
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ViewModelML();

        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as ViewModelML;
            if (viewModel != null)
            {
                await viewModel.GetInfo();
            }
        }
    }

}
