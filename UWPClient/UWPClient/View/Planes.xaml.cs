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
	public sealed partial class Planes : Page
	{
		public string s = "All Planes";
		private PlaneService ps;
		public Plane[] list;

		public Planes()
		{
			this.InitializeComponent();
			ps = new PlaneService();
			list = ps.GetAll().Result;

			Add.Click += (sender, e) => Create();
		}

		private Plane _selected;
		public Plane selected
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

					TextBlock t0 = new TextBlock { Text = "Id: " + _selected.Id };
					TextBlock t1 = new TextBlock { Text = "Name: " + _selected.Name };
					TextBlock t2 = new TextBlock { Text = "Time: " + _selected.Made };
					TextBlock t3 = new TextBlock { Text = "Exploitation: " + _selected.Exploitation };
					TextBlock t4 = new TextBlock { Text = "Type: " + _selected.Type.Model };

					Button delete = new Button { Name = "delete", Content = "Delete", Width = 100 };
					delete.Margin = new Thickness(0, 10, 0, 10);
					delete.Click += async (sender, e) =>  await DeleteById(selected.Id);
					Button edit = new Button { Name = "edit", Content = "Edit", Width = 100 };
					edit.Margin = new Thickness(0, 10, 0, 10);
					edit.Click += (sender, e) => EditById(selected.Id);

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
			await ps.Delete(id);
			this.Frame.Navigate(typeof(Planes));
		}

		public void EditById(int id)
		{
			gr.Children.Clear();

			TextBox Name = new TextBox();
			Name.Header = "Name";
			Name.Text = selected.Name;

			TextBox Exp = new TextBox();
			Exp.Header = "Exp.";
			Exp.Text = selected.Exploitation.Seconds.ToString();


			DatePicker Made = new DatePicker();
			Made.Header = "Made";
			Made.MinWidth = 150;
			Made.Date = selected.Made;

			TextBox Type = new TextBox();
			Type.Header = "Type";
			Type.Text = selected.Type.Id.ToString();
			Type.IsEnabled = false;




			Button submit = new Button { Name = "submit", Content = "Submit Edit", Width = 150 };
			submit.Margin = new Thickness(0, 10, 0, 10);
			submit.Click += async (sender, e) => await SubmitEdit(id, Name.Text, Made.Date.Date, Convert.ToInt32(Type.Text), new TimeSpan(Convert.ToInt32(Exp.Text)));

			ColumnDefinition cd = new ColumnDefinition();
			RowDefinition rd0 = new RowDefinition();
			RowDefinition rd1 = new RowDefinition();
			RowDefinition rd2 = new RowDefinition();
			RowDefinition rd3 = new RowDefinition();
			RowDefinition rd4 = new RowDefinition();

			gr.Children.Add(Name);
			gr.Children.Add(Exp);
			gr.Children.Add(Made);
			gr.Children.Add(Type);
			gr.Children.Add(submit);

			Grid.SetRow(Name, 0);
			Grid.SetRow(Exp, 1);
			Grid.SetRow(Made, 2);
			Grid.SetRow(Type, 3);
			Grid.SetRow(submit, 4);
		}

		public async Task SubmitEdit(int id, string name, DateTime made, int type, TimeSpan exp)
		{
			InputPlane plane = new InputPlane();

			plane.Name = name;
			plane.Made = made;
			plane.Exploitation = exp;
			plane.Type = type;						

			await ps.Update(id, plane);
			this.Frame.Navigate(typeof(Planes));
		}

		public void Create()
		{
			selected = new Plane()
			{
				Type = new Model.PlaneType()
			};

			gr.Children.Clear();

			TextBox Name = new TextBox();
			Name.Header = "Name";
			//Name.Text = selected.Name;

			TextBox Exp = new TextBox();
			Exp.Header = "Exp.";
			//Exp.Text = selected.Exploitation.Seconds.ToString();


			DatePicker Made = new DatePicker();
			Made.Header = "Made";
			Made.MinWidth = 150;
			//Made.Date = selected.Made;

			TextBox Type = new TextBox();
			Type.Header = "Type";
			//Type.Text = selected.Type.Id.ToString();
			//Type.IsEnabled = false;




			Button submit = new Button { Name = "submit", Content = "Submit Create", Width = 150 };
			submit.Margin = new Thickness(0, 10, 0, 10);
			submit.Click += async (sender, e) => await SubmitCreate( Name.Text, Made.Date.Date, Convert.ToInt32(Type.Text), new TimeSpan(Convert.ToInt32(Exp.Text)));

			ColumnDefinition cd = new ColumnDefinition();
			RowDefinition rd0 = new RowDefinition();
			RowDefinition rd1 = new RowDefinition();
			RowDefinition rd2 = new RowDefinition();
			RowDefinition rd3 = new RowDefinition();
			RowDefinition rd4 = new RowDefinition();

			gr.Children.Add(Name);
			gr.Children.Add(Exp);
			gr.Children.Add(Made);
			gr.Children.Add(Type);
			gr.Children.Add(submit);

			Grid.SetRow(Name, 0);
			Grid.SetRow(Exp, 1);
			Grid.SetRow(Made, 2);
			Grid.SetRow(Type, 3);
			Grid.SetRow(submit, 4);
		}

		public async Task SubmitCreate( string name, DateTime made, int type, TimeSpan exp)
		{
			InputPlane plane = new InputPlane();

			plane.Name = name;
			plane.Made = made;
			plane.Exploitation = exp;
			plane.Type = type;

			await ps.Create(plane);
			this.Frame.Navigate(typeof(Planes));
		}


	}
}
