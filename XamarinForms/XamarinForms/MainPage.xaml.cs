using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinForms
{
	public partial class MainPage : ContentPage
	{
        public ObservableCollection<string> Data { get; set; }

        public MainPage()
		{
			InitializeComponent();

            Data = new ObservableCollection<string>
            {
                "Něco",
                "Nic",
                "Vše",
            };
            //BtnAdd.
            //ListViewData.ItemsSource = Data;
        }

        void BtnAdd_Clicked_Handler(object sender, EventArgs eventArgs)
        {
            Data.Add(EditorNewItem.Text);
            EditorNewItem.Text = string.Empty;
        }

        private void ListViewData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Data.RemoveAt(Data.IndexOf(e.SelectedItem.ToString()));
        }
    }
}
