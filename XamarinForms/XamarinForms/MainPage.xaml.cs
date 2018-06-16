using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace XamarinForms
{
	//[ImplementPropertyChanged]
	public partial class MainPage : ContentPage
	{
        public ObservableCollection<DataRow> Data { get; set; }
		string tag = $"XamarinForms-{nameof(MainPage)}";

        public MainPage()
		{
			InitializeComponent();

            //Data = new ObservableCollection<string>
            //{
            //    "Něco",
            //    "Nic",
            //    "Vše",
            //};
			Data = new ObservableCollection<DataRow>
			{
				new DataRow { Val = "Něco" },
				new DataRow { Val = "Nic" },
				new DataRow { Val = "Vše" }
			};

			All = new List<DataRow>();
			foreach (var item in Data)
			{
				All.Add(item);
			}
			
			ListViewData.ItemsSource = Data;
		}

        void BtnAdd_Clicked_Handler(object sender, EventArgs eventArgs)
        {
            Data.Add(new DataRow { Val = EditorNewItem.Text });
            All.Add(new DataRow { Val = EditorNewItem.Text });

			Log.Warning(tag, $"{nameof(BtnAdd_Clicked_Handler)}: {EditorNewItem.Text} added");
			Log.Warning(tag, $"{nameof(BtnAdd_Clicked_Handler)}: Data.Count = {Data.Count()}");
			Console.WriteLine($"{nameof(BtnAdd_Clicked_Handler)}: {EditorNewItem.Text} added");
			Console.WriteLine($"{nameof(BtnAdd_Clicked_Handler)}: Data.Count = {Data.Count()}");

			DependencyService.Get<IToast>().Show($"'{EditorNewItem.Text}' bylo přidáno.");

			EditorNewItem.Text = string.Empty;
		}

        private void ListViewData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //Data.RemoveAt(Data.IndexOf(e.SelectedItem.ToString()));
            Data.RemoveAt(Data.IndexOf((e.SelectedItem as DataRow)));
            All.RemoveAt(All.IndexOf((e.SelectedItem as DataRow)));
        }

		public static IList<DataRow> All { private set; get; }

		private void ToastButton_Clicked(object sender, EventArgs e)
		{
			// samotná implementace zobrazení toastu je platform-specific
			DependencyService.Get<IToast>().Show("Toast Message");
		}
	}
}
