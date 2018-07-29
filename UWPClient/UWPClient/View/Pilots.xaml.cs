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
	public sealed partial class Pilots : Page
	{
		public string s = "All Pilots";
		private PilotService ps;
		public Pilot[] list;


		public Pilots()
		{
			this.InitializeComponent();
			ps = new PilotService();
			list = ps.GetAll().Result;

			Add.Click += (sender,e) => Create();
		}


		private Pilot _selected;
		public Pilot selected
		{
			get { return _selected; }
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
					TextBlock t2 = new TextBlock { Text = "Surname: " + _selected.Surname };
					TextBlock t3 = new TextBlock { Text = "Birth: " + _selected.Birth.Date };
					TextBlock t4 = new TextBlock { Text = "Experience: " + _selected.Experience };

					Button delete = new Button { Name = "delete", Content = "Delete", Width = 100 };
					delete.Margin = new Thickness(0, 10, 0, 10);
					delete.Click += async (sender, e) => await DeleteById(_selected.Id);				
					Button edit = new Button { Name = "edit", Content = "Edit", Width = 100 };
					edit.Margin = new Thickness(0, 10, 0, 10);
					edit.Click += (sender, e) => EditById(_selected.Id);

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
			this.Frame.Navigate(typeof(Pilots));
		}

		public void EditById(int id)
		{
			gr.Children.Clear();

			TextBox Name = new TextBox();
			Name.Header = "Name";
			Name.Text = selected.Name;
			TextBox Surname = new TextBox();
			Surname.Header = "Surname";
			Surname.Text = selected.Surname;
			DatePicker dDate = new DatePicker();
			dDate.Header = "Birthday";
			dDate.Date = selected.Birth;
			dDate.MinWidth = 150;
			TextBox Experience = new TextBox();
			Experience.Header = "Experience";
			Experience.Text = selected.Experience.TotalSeconds.ToString();


			Button submit = new Button { Name = "submit", Content = "Submit Edit", Width = 150 };
			submit.Margin = new Thickness(0, 10, 0, 10);
			submit.Click += async (sender, e) => await SubmitEdit(id, Name.Text, Surname.Text, dDate.Date.Date, new TimeSpan(Convert.ToInt32(Experience.Text)));

			ColumnDefinition cd = new ColumnDefinition();
			RowDefinition rd0 = new RowDefinition();
			RowDefinition rd1 = new RowDefinition();
			RowDefinition rd2 = new RowDefinition();
			RowDefinition rd3 = new RowDefinition();
			RowDefinition rd4 = new RowDefinition();

			gr.Children.Add(Name);
			gr.Children.Add(Surname);
			gr.Children.Add(dDate);
			gr.Children.Add(Experience);
			gr.Children.Add(submit);

			Grid.SetRow(Name, 0);
			Grid.SetRow(Surname, 1);
			Grid.SetRow(dDate, 2);
			Grid.SetRow(Experience, 3);
			Grid.SetRow(submit, 4);
		}

		public async Task SubmitEdit(int id, string name, string surname, DateTime birth, TimeSpan exp)
		{
			Pilot p = new Pilot();

			p.Name = name;
			p.Surname = surname;
			p.Birth = birth;
			p.Experience = exp;

			await ps.Update(id, p);
			this.Frame.Navigate(typeof(Pilots));
		}

		public void Create()
		{
			selected = new Pilot();

			gr.Children.Clear();

			TextBox Name = new TextBox();
			Name.Header = "Name";
			TextBox Surname = new TextBox();
			Surname.Header = "Surname";
			DatePicker dDate = new DatePicker();
			dDate.Header = "Birthday";
			dDate.MinWidth = 150;
			TextBox Experience = new TextBox();
			Experience.Header = "Experience";


			Button submit = new Button { Name = "submit", Content = "Submit Create", Width = 150 };
			submit.Margin = new Thickness(0, 10, 0, 10);
			submit.Click += async (sender, e) => await SubmitCreate(Name.Text, Surname.Text, dDate.Date.Date, new TimeSpan(Convert.ToInt32(Experience.Text)));

			ColumnDefinition cd = new ColumnDefinition();
			RowDefinition rd0 = new RowDefinition();
			RowDefinition rd1 = new RowDefinition();
			RowDefinition rd2 = new RowDefinition();
			RowDefinition rd3 = new RowDefinition();
			RowDefinition rd4 = new RowDefinition();

			gr.Children.Add(Name);
			gr.Children.Add(Surname);
			gr.Children.Add(dDate);
			gr.Children.Add(Experience);
			gr.Children.Add(submit);

			Grid.SetRow(Name, 0);
			Grid.SetRow(Surname, 1);
			Grid.SetRow(dDate, 2);
			Grid.SetRow(Experience, 3);
			Grid.SetRow(submit, 4);
		}

		public async Task SubmitCreate(string name, string surname, DateTime birth, TimeSpan exp)
		{
			Pilot p = new Pilot();

			p.Name = name;
			p.Surname = surname;
			p.Birth = birth;
			p.Experience = exp;

			await ps.Create(p);
			this.Frame.Navigate(typeof(Pilots));
		}
	}
}
