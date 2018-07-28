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
	public sealed partial class Tickets : Page
	{
		public string s = "All Tickets";
		private TicketService ts;
		public Ticket[] list;


		public Tickets()
		{
			this.InitializeComponent();
			ts = new TicketService();
			list = ts.GetAll().Result;
		}

		private Ticket _selected;
		public Ticket selected
		{
			get { return _selected;}
			set
			{
				_selected = value;
				if(_selected != null)
				{
					ColumnDefinition cd = new ColumnDefinition();
					RowDefinition rd0 = new RowDefinition();
					RowDefinition rd1 = new RowDefinition();
					RowDefinition rd2 = new RowDefinition();
					RowDefinition rd3 = new RowDefinition();
					RowDefinition rd4 = new RowDefinition();
					RowDefinition rd5 = new RowDefinition();
					RowDefinition rd6 = new RowDefinition();
					RowDefinition rd7 = new RowDefinition();

					rd0.Height = GridLength.Auto;
					rd1.Height = GridLength.Auto;
					rd2.Height = GridLength.Auto;
					rd3.Height = GridLength.Auto;
					rd4.Height = GridLength.Auto;
					rd5.Height = GridLength.Auto;
					rd6.Height = GridLength.Auto;
					rd7.Height = GridLength.Auto;
					cd.Width = GridLength.Auto;

					gr.ColumnDefinitions.Add(cd);
					gr.RowDefinitions.Add(rd0);
					gr.RowDefinitions.Add(rd1);
					gr.RowDefinitions.Add(rd2);
					gr.RowDefinitions.Add(rd3);
					gr.RowDefinitions.Add(rd4);
					gr.RowDefinitions.Add(rd5);
					gr.RowDefinitions.Add(rd6);
					gr.RowDefinitions.Add(rd7);

					TextBlock t0 = new TextBlock { Text = "Id: " + _selected.Id };
					TextBlock t1 = new TextBlock { Text = "Price: " + _selected.Price };
					TextBlock t2 = new TextBlock { Text = "Departure: " + _selected.FlightNum.DeperturePlace };
					TextBlock t3 = new TextBlock { Text = "Time: " + _selected.FlightNum.DepartureTime };
					TextBlock t4 = new TextBlock { Text = "Arrival: " + _selected.FlightNum.ArrivalPlace };
					TextBlock t5 = new TextBlock { Text = "Time: " + _selected.FlightNum.ArrivalTime };

					Button delete = new Button { Name = "delete", Content = "Delete", Width = 100 };
					delete.Click += (sender, e) => DeleteById(selected.Id);
					Button edit = new Button { Name = "edit", Content = "Edit", Width = 100 };

					gr.Children.Clear();

					gr.Children.Add(t0);
					gr.Children.Add(t1);
					gr.Children.Add(t2);
					gr.Children.Add(t3);
					gr.Children.Add(t4);
					gr.Children.Add(t5);
					gr.Children.Add(delete);
					gr.Children.Add(edit);

					Grid.SetRow(t0, 0);
					Grid.SetRow(t1, 1);
					Grid.SetRow(t2, 2);
					Grid.SetRow(t3, 3);
					Grid.SetRow(t4, 4);
					Grid.SetRow(t5, 5);
					Grid.SetRow(delete, 6);
					Grid.SetRow(edit, 7);
				}
			}
		}

		public async Task DeleteById(int id)
		{
			await ts.Delete(id);
			this.Frame.Navigate(typeof(Tickets));
		}


	}
}
