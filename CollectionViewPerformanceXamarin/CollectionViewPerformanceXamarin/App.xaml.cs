using CollectionViewPerformanceXamarin.Services;
using CollectionViewPerformanceXamarin.ViewModels;
using CollectionViewPerformanceXamarin.Views;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace CollectionViewPerformanceXamarin
{
	public partial class App : Application {
		public App() {


            //===================
            //toggle projects
            //===================
            bool testSimpleLayout = false;

			//============================================
			//1) ORIGINAL PROJECT USING MAUI SYSTEM
			//============================================
			if (!testSimpleLayout) {

				InitializeComponent();

				var dataService = new DataService();
				var viewModel = new DataViewModel(dataService);
				var view = new DataView(viewModel);
		
                MainPage = new NavigationPage(view);

            }
            //============================================
            //2) SIMPLE PROJECT USING BASIC LAYOUTS
            //============================================
            else {
                ContentPage mainPage = new();
                MainPage = mainPage;

                int numNested = 10; //set number of extra layouts to nest from 0-n, does not change result

                List<StackLayout> layoutList = new(); //can try alternative layout types here
                StackLayout layout = new(); //can try alternative layout types here
                
                mainPage.Content = layout;
                layoutList.Add(layout);

                for (int i = 0; i < numNested; i++) {
                    layout = new();
                    layoutList[layoutList.Count - 1].Children.Add(layout);
                    layoutList.Add(layout);
                }

                Label label = new();
                label.Text = "HELLO HELLO HELLO HELLO HELLO HELLO HELLO HELLO HELLO HELLO HELLO HELLO";
                layoutList[layoutList.Count - 1].Children.Add(label);

                mainPage.SizeChanged += delegate {
                    UpdateCounter.resetCounters();
                    Debug.WriteLine("====================RESET COUNTERS ON RESIZE");
                    if (mainPage.Width > 0) {
                        for (int i = 0; i < layoutList.Count; i++) {
                            layoutList[i].WidthRequest = mainPage.Width;
                            layoutList[i].HeightRequest = mainPage.Height;
                        }
                    }
                };

                //ABSOLUTE LAYOUT:
                //== android maui - measure 3x, layout 2x | android xamarin - measure 1x, layout 1x
                //== iOS maui - layout 2x, draw 1x | iOS xamarin - layout 2x, draw 1x

                //VERTICAL STACK LAYOUT & STACK LAYOUT:
                //== android maui - measure 3x, layout 2x | android xamarin - measure 1x, layout 1x
                //== iOS maui - layout 3x, draw 1x | iOS xamarin - layout 2x, draw 1x
            }

            //============================================
            //to find resources for test photos
            foreach (string currentResource in System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames()) {
                //Debug.WriteLine(currentResource);
            }

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
