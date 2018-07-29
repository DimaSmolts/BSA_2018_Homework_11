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
	public sealed partial class Crews : Page
	{
		public string s = "All Crews";
		private CrewService cs;
		public Crew[] list;

		public Crews()
		{
			this.InitializeComponent();
			cs = new CrewService();
			list = cs.GetAll().Result;

			Add.Click += (sender, e) => Create();
		}

		private Crew _selected;
		public Crew selected
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

					rd0.Height = GridLength.Auto;
					rd1.Height = GridLength.Auto;
					rd2.Height = GridLength.Auto;
					rd3.Height = GridLength.Auto;
					rd4.Height = GridLength.Auto;
					cd.Width = GridLength.Auto;

					gr.ColumnDefinitions.Add(cd);
					gr.RowDefinitions.Add(rd0);
					gr.RowDefinitions.Add(rd1);
					gr.RowDefinitions.Add(rd2);
					gr.RowDefinitions.Add(rd3);
					gr.RowDefinitions.Add(rd4);

					TextBlock t0 = new TextBlock { Text = "Id: " + _selected.Id };
					TextBlock t1 = new TextBlock { Text = "Pilot: " + _selected.PilotId.Name +" " + _selected.PilotId.Surname };
					TextBlock t2 = new TextBlock { Text = "Stewardesses: " + _selected.StewardessIds.Count() };

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
					gr.Children.Add(delete);
					gr.Children.Add(edit);

					Grid.SetRow(t0, 0);
					Grid.SetRow(t1, 1);
					Grid.SetRow(t2, 2);
					Grid.SetRow(delete, 3);
					Grid.SetRow(edit, 4);
				}
			}
		}

		public async Task DeleteById(int id)
		{
			await cs.Delete(id);
			this.Frame.Navigate(typeof(Crews));
		}

		public void EditById(int id)
		{
			gr.Children.Clear();
			TextBlock textBlock = new TextBlock();
			textBlock.Text = "smth is wrong here";
			ColumnDefinition cd = new ColumnDefinition();
			RowDefinition rd0 = new RowDefinition();
			gr.Children.Add(textBlock);
			Grid.SetRow(textBlock, 0);
		}


		public void Create()
		{
			selected = new Crew()
			{
				PilotId = new Pilot(),
				StewardessIds = new Stewardess[2]
			};
			gr.Children.Clear();


			TextBox Pilot = new TextBox();
			Pilot.Header = "Pilot";
			TextBox Stew1 = new TextBox();
			Stew1.Header = "Stew1";
			TextBox Stew2 = new TextBox();
			Stew2.Header = "Stew2";

			

			Button submit = new Button { Name = "submit", Content = "Submit Create", Width = 150 };
			submit.Margin = new Thickness(0, 10, 0, 10);
			submit.Click += async (sender, e) => await SubmitCreate(Convert.ToInt32(Pilot.Text), Stew1.Text.ToString(), Stew2.Text.ToString());

			ColumnDefinition cd = new ColumnDefinition();
			RowDefinition rd0 = new RowDefinition();
			RowDefinition rd1 = new RowDefinition();
			RowDefinition rd2 = new RowDefinition();
			RowDefinition rd3 = new RowDefinition();

			gr.Children.Add(Pilot);
			gr.Children.Add(Stew1);
			gr.Children.Add(Stew2);
			gr.Children.Add(submit);

			Grid.SetRow(Pilot, 0);
			Grid.SetRow(Stew1, 1);
			Grid.SetRow(Stew2, 2);
			Grid.SetRow(submit, 3);
		}

		public async Task SubmitCreate(int pilot, string st1, string st2)
		{
			InputCrew inputCrew = new InputCrew();
			inputCrew.PilotId = pilot;
			int[] stews = { Convert.ToInt32(st1), Convert.ToInt32(st2) };
			inputCrew.StewardessIds = stews;

			await cs.Create(inputCrew);
			this.Frame.Navigate(typeof(Crews));
		}

	}
}
