using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWPClient.Service;
using UWPClient.Model;
using System.Threading.Tasks;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPClient.View
{
	/// <summary>
	/// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
	/// </summary>
	public sealed partial class Flights : Page
	{
		public string s = "All Flights";
		private FlightService fs;
		public Flight[] list;

		public Flights()
		{
			this.InitializeComponent();
			fs = new FlightService();
			list = fs.GetAll().Result;
		}

		private Flight _selected;
		public Flight selected
		{
			get {				
				return _selected;
			}
			set
			{
				_selected = value;
				if (selected != null)
				{
					ColumnDefinition cd = new ColumnDefinition();
					RowDefinition rd0 = new RowDefinition();
					RowDefinition rd1 = new RowDefinition();
					RowDefinition rd2 = new RowDefinition();
					RowDefinition rd3 = new RowDefinition();
					RowDefinition rd4 = new RowDefinition();
					RowDefinition rd5 = new RowDefinition();
					RowDefinition rd6 = new RowDefinition();

					rd0.Height = GridLength.Auto;
					rd1.Height = GridLength.Auto;
					rd2.Height = GridLength.Auto;
					rd3.Height = GridLength.Auto;
					rd4.Height = GridLength.Auto;
					rd5.Height = GridLength.Auto;
					rd6.Height = GridLength.Auto;
					cd.Width = GridLength.Auto;					

					gr.ColumnDefinitions.Add(cd);
					gr.RowDefinitions.Add(rd0);
					gr.RowDefinitions.Add(rd1);
					gr.RowDefinitions.Add(rd2);
					gr.RowDefinitions.Add(rd3);
					gr.RowDefinitions.Add(rd4);
					gr.RowDefinitions.Add(rd5);
					gr.RowDefinitions.Add(rd6);

					TextBlock t0 = new TextBlock { Text = "Id: " + _selected.FlightNum };
					TextBlock t1 = new TextBlock { Text = "Departure: " + _selected.DeperturePlace };
					TextBlock t2 = new TextBlock { Text = "Time: " + _selected.DepartureTime };
					TextBlock t3 = new TextBlock { Text = "Arrival: " + _selected.ArrivalPlace };
					TextBlock t4 = new TextBlock { Text = "Time: " + _selected.ArrivalTime };

					Button delete = new Button { Name = "delete", Content = "Del", Width = 100 };
					delete.Click += (sender, e) => DeleteById(selected.FlightNum);
					Button edit = new Button { Name = "edit", Content = "Ed", Width = 100 };

					gr.Children.Clear();

					gr.Children.Add(t0);
					gr.Children.Add(t1);
					gr.Children.Add(t2);
					gr.Children.Add(t3);
					gr.Children.Add(t4);
					gr.Children.Add(delete);
					gr.Children.Add(edit);

					Grid.SetRow(t0, 0);
					Grid.SetRow(t1, 1);
					Grid.SetRow(t2, 2);
					Grid.SetRow(t3, 3);
					Grid.SetRow(t4, 4);
					Grid.SetRow(delete, 5);
					Grid.SetRow(edit, 6);
				}					
			}
		}

		public async Task DeleteById(int id)
		{
			await fs.Delete(id);
			this.Frame.Navigate(typeof(Flights));
		}
	}
}
