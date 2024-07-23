using CollectionViewPerformanceXamarin.Services;
using CollectionViewPerformanceXamarin.ViewModels;
using CollectionViewPerformanceXamarin.Views;
using System.Diagnostics;
using Xamarin.Forms;

namespace CollectionViewPerformanceXamarin
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			var dataService = new DataService();
			var viewModel = new DataViewModel(dataService);
			var view = new DataView(viewModel);

			//to find resources for test photos
            //foreach (string currentResource in System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames()) {
                //Debug.WriteLine(currentResource);
            //}

            MainPage = new NavigationPage(view);
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
