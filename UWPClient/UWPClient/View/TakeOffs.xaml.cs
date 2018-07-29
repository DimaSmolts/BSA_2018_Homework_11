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
using UWPClient.Model.InputModels;
using System.Threading.Tasks;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPClient.View
{
	/// <summary>
	/// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
	/// </summary>
	public sealed partial class TakeOffs : Page
	{
		public string s = "All TakeOffs";
		private TakeOffService tos;
		public TakeOff[] list;


		public TakeOffs()
		{
			this.InitializeComponent();
			tos = new TakeOffService();
			list = tos.GetAll().Result;

			Add.Click += (sender, e) => Create();
		}

		private TakeOff _selected;
		public TakeOff selected
		{
			get { return _selected; }
			set
			{
				_selected = value;
				if (_selected != null)
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
					TextBlock t1 = new TextBlock { Text = "Date: " + _selected.Date };
					TextBlock t2 = new TextBlock { Text = "Departure: " + _selected.FlightNum.DeperturePlace };
					TextBlock t3 = new TextBlock { Text = "Arrival: " + _selected.FlightNum.ArrivalPlace };
					TextBlock t4 = new TextBlock { Text = "Crew: " + _selected.CrewId.Id };
					TextBlock t5 = new TextBlock { Text = "Plane: " + _selected.PlaneId.Name };

					Button delete = new Button { Name = "delete", Content = "Delete", Width = 100 };
					delete.Margin = new Thickness(0, 10, 0, 10);
					delete.Click += async (sender, e) => await DeleteById(selected.Id);
					Button edit = new Button { Name = "edit", Content = "Edit", Width = 100 };
					edit.Margin = new Thickness(0, 10, 0, 10);
					edit.Click += (sender, e) => EditById(selected.Id);

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
			await tos.Delete(id);
			this.Frame.Navigate(typeof(TakeOffs));
		}

		public void EditById(int id)
		{
			gr.Children.Clear();

			DatePicker dDate = new DatePicker();
			dDate.Header = "Departure Date";
			dDate.MinWidth = 150;
			dDate.Date = selected.Date;

			TextBox Crew = new TextBox();
			Crew.Header = "Crew";
			Crew.Text = selected.CrewId.Id.ToString();
			//model.Width = 300;
			
			TextBox Flight = new TextBox();
			Flight.Header = "Flight";
			Flight.Text = selected.FlightNum.FlightNum.ToString();

			TextBox Plane = new TextBox();
			Plane.Header = "Plane";
			Plane.Text = selected.PlaneId.Id.ToString();


			Button submit = new Button { Name = "submit", Content = "Submit Edit", Width = 150 };
			submit.Margin = new Thickness(0, 10, 0, 10);
			submit.Click += async (sender, e) => await SubmitEdit(id,dDate.Date.Date, Convert.ToInt32( Crew.Text), Convert.ToInt32(Plane.Text), Convert.ToInt32(Flight.Text));

			ColumnDefinition cd = new ColumnDefinition();
			RowDefinition rd0 = new RowDefinition();
			RowDefinition rd1 = new RowDefinition();
			RowDefinition rd2 = new RowDefinition();
			RowDefinition rd3 = new RowDefinition();
			RowDefinition rd4 = new RowDefinition();

			gr.Children.Add(dDate);
			gr.Children.Add(Crew);
			gr.Children.Add(Flight);
			gr.Children.Add(Plane);
			gr.Children.Add(submit);

			Grid.SetRow(dDate, 0);
			Grid.SetRow(Crew, 1);
			Grid.SetRow(Flight, 2);
			Grid.SetRow(Plane, 3);
			Grid.SetRow(submit, 4);
		}

		public async Task SubmitEdit(int id, DateTime date, int crew, int plane, int flight)
		{
			InputTakeOff inputTakeOff = new InputTakeOff();

			inputTakeOff.Date = date;
			inputTakeOff.CrewId = crew;
			inputTakeOff.PlaneId = plane;
			inputTakeOff.FlightNum = flight;

			await tos.Update(id, inputTakeOff);
			this.Frame.Navigate(typeof(TakeOffs));
		}

		public void Create()
		{
			selected = new TakeOff()
			{
				CrewId = new Crew(),
				FlightNum = new Flight(),
				PlaneId = new Plane()
			};

			gr.Children.Clear();

			DatePicker dDate = new DatePicker();
			dDate.Header = "Departure Date";
			dDate.MinWidth = 150;
			//dDate.Date = selected.Date;

			TextBox Crew = new TextBox();
			Crew.Header = "Crew";
			//Crew.Text = selected.CrewId.Id.ToString();
			//model.Width = 300;

			TextBox Flight = new TextBox();
			Flight.Header = "Flight";
			//Flight.Text = selected.FlightNum.FlightNum.ToString();

			TextBox Plane = new TextBox();
			Plane.Header = "Plane";
			//Plane.Text = selected.PlaneId.Id.ToString();


			Button submit = new Button { Name = "submit", Content = "Submit Create", Width = 150 };
			submit.Margin = new Thickness(0, 10, 0, 10);
			submit.Click += async (sender, e) => await SubmitCreate( dDate.Date.Date, Convert.ToInt32(Crew.Text), Convert.ToInt32(Plane.Text), Convert.ToInt32(Flight.Text));

			ColumnDefinition cd = new ColumnDefinition();
			RowDefinition rd0 = new RowDefinition();
			RowDefinition rd1 = new RowDefinition();
			RowDefinition rd2 = new RowDefinition();
			RowDefinition rd3 = new RowDefinition();
			RowDefinition rd4 = new RowDefinition();

			gr.Children.Add(dDate);
			gr.Children.Add(Crew);
			gr.Children.Add(Flight);
			gr.Children.Add(Plane);
			gr.Children.Add(submit);

			Grid.SetRow(dDate, 0);
			Grid.SetRow(Crew, 1);
			Grid.SetRow(Flight, 2);
			Grid.SetRow(Plane, 3);
			Grid.SetRow(submit, 4);
		}

		public async Task SubmitCreate( DateTime date, int crew, int plane, int flight)
		{
			InputTakeOff inputTakeOff = new InputTakeOff();

			inputTakeOff.Date = date;
			inputTakeOff.CrewId = crew;
			inputTakeOff.PlaneId = plane;
			inputTakeOff.FlightNum = flight;

			await tos.Create(inputTakeOff);
			this.Frame.Navigate(typeof(TakeOffs));
		}

	}
}
