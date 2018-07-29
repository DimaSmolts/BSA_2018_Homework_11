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

			Add.Click += (sender, e) => Create();
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

					Button delete = new Button { Name = "delete", Content = "Delete", Width = 100 };
					delete.Click += async (sender, e) => await DeleteById(selected.FlightNum);
					delete.Margin = new Thickness(0, 10, 0, 10);
					Button edit = new Button { Name = "edit", Content = "Edit", Width = 100 };
					edit.Click += (sender, e) => EditById(selected.FlightNum);
					edit.Margin = new Thickness(0, 10, 0, 10);

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

		public void EditById(int id)
		{
			gr.Children.Clear();

			TextBox Departure = new TextBox();
			Departure.Header = "Departure Place";
			Departure.Text = selected.DeperturePlace;
			//model.Width = 300;
			DatePicker dDate = new DatePicker();
			dDate.Header = "Departure Date";
			dDate.Date = selected.DepartureTime;
			dDate.MinWidth = 150;
			TextBox Arrival = new TextBox();
			Arrival.Header = "Arrival place";
			Arrival.Text = selected.ArrivalPlace;
			//carCap.Width = 300; ;
			DatePicker aDate = new DatePicker();
			aDate.Header = "Arrival Date";
			aDate.MinWidth = 150;
			aDate.Date = selected.ArrivalTime;


			Button submit = new Button { Name = "submit", Content = "Submit Edit", Width = 150 };
			submit.Margin = new Thickness(0, 10, 0, 10);
			submit.Click += async (sender, e) => await SubmitEdit(id, Departure.Text, dDate.Date.Date, Arrival.Text, aDate.Date.Date);

			ColumnDefinition cd = new ColumnDefinition();
			RowDefinition rd0 = new RowDefinition();
			RowDefinition rd1 = new RowDefinition();
			RowDefinition rd2 = new RowDefinition();
			RowDefinition rd3 = new RowDefinition();
			RowDefinition rd4 = new RowDefinition();

			gr.Children.Add(Departure);
			gr.Children.Add(dDate);
			gr.Children.Add(Arrival);
			gr.Children.Add(aDate);
			gr.Children.Add(submit);

			Grid.SetRow(Departure, 0);
			Grid.SetRow(dDate, 1);
			Grid.SetRow(Arrival, 2);
			Grid.SetRow(aDate, 3);
			Grid.SetRow(submit, 4);
		}

		public async Task SubmitEdit(int id, string dep, DateTime depDate, string arr, DateTime arrDate)
		{
			Flight flight = new Flight();

			flight.DeperturePlace = dep;
			flight.DepartureTime = depDate;
			flight.ArrivalPlace = arr;
			flight.ArrivalTime = arrDate;			

			await fs.Update(id, flight);
			this.Frame.Navigate(typeof(Flights));
		}

		public void Create()
		{

			this.selected = new Flight();
			

			TextBox Departure = new TextBox();
			Departure.Header = "Departure Place";
			//model.Width = 300;
			DatePicker dDate = new DatePicker();
			dDate.Header = "Departure Date";
			dDate.MinWidth = 150;
			TextBox Arrival = new TextBox();
			Arrival.Header = "Arrival place";
			//carCap.Width = 300; ;
			DatePicker aDate = new DatePicker();
			aDate.Header = "Arrival Date";
			aDate.MinWidth = 150;


			Button submit = new Button { Name = "submit", Content = "Submit Create", Width = 150 };
			submit.Margin = new Thickness(0, 10, 0, 10);
			submit.Click += async (sender, e) => await SubmitCreate(Departure.Text, dDate.Date.Date, Arrival.Text, aDate.Date.Date);

			gr.Children.Clear();

			ColumnDefinition cd = new ColumnDefinition();
			RowDefinition rd0 = new RowDefinition();
			RowDefinition rd1 = new RowDefinition();
			RowDefinition rd2 = new RowDefinition();
			RowDefinition rd3 = new RowDefinition();
			RowDefinition rd4 = new RowDefinition();

			gr.Children.Add(Departure);
			gr.Children.Add(dDate);
			gr.Children.Add(Arrival);
			gr.Children.Add(aDate);
			gr.Children.Add(submit);

			Grid.SetRow(Departure, 0);
			Grid.SetRow(dDate, 1);
			Grid.SetRow(Arrival, 2);
			Grid.SetRow(aDate, 3);
			Grid.SetRow(submit, 4);
		}

		public async Task SubmitCreate( string dep, DateTime depDate, string arr, DateTime arrDate)
		{
			Flight flight = new Flight();

			flight.DeperturePlace = dep;
			flight.DepartureTime = depDate;
			flight.ArrivalPlace = arr;
			flight.ArrivalTime = arrDate;

			await fs.Create(flight);
			this.Frame.Navigate(typeof(Flights));
		}
	}
}
