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
	public sealed partial class Stewardesses : Page
	{
		public string s = "All Stews";
		private StewardessService ss;
		public Stewardess[] list;


		public Stewardesses()
		{
			this.InitializeComponent();
			ss = new StewardessService();
			list = ss.GetAll().Result;
		}

		private Stewardess _selected;
		public Stewardess selected
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
					

					rd0.Height = GridLength.Auto;
					rd1.Height = GridLength.Auto;
					rd2.Height = GridLength.Auto;
					rd3.Height = GridLength.Auto;
					rd4.Height = GridLength.Auto;
					rd5.Height = GridLength.Auto;					
					cd.Width = GridLength.Auto;

					gr.ColumnDefinitions.Add(cd);
					gr.RowDefinitions.Add(rd0);
					gr.RowDefinitions.Add(rd1);
					gr.RowDefinitions.Add(rd2);
					gr.RowDefinitions.Add(rd3);
					gr.RowDefinitions.Add(rd4);
					gr.RowDefinitions.Add(rd5);

					TextBlock t0 = new TextBlock { Text = "Id: " + _selected.Id };
					TextBlock t1 = new TextBlock { Text = "Name: " + _selected.Name };
					TextBlock t2 = new TextBlock { Text = "Surname: " + _selected.Surname };
					TextBlock t3 = new TextBlock { Text = "Birth: " + _selected.Birth.Date };

					Button delete = new Button { Name = "delete", Content = "Delete", Width = 100 };
					delete.Click += (sender, e) => DeleteById(_selected.Id);
					Button edit = new Button { Name = "edit", Content = "Ed", Width = 100 };

					gr.Children.Clear();

					gr.Children.Add(t0);
					gr.Children.Add(t1);
					gr.Children.Add(t2);
					gr.Children.Add(t3);					
					gr.Children.Add(delete);
					gr.Children.Add(edit);

					Grid.SetRow(t0, 0);
					Grid.SetRow(t1, 1);
					Grid.SetRow(t2, 2);
					Grid.SetRow(t3, 3);					
					Grid.SetRow(delete, 4);
					Grid.SetRow(edit, 5);

				}
			}
		}

		public async Task DeleteById(int id)
		{
			await ss.Delete(id);
			this.Frame.Navigate(typeof(Stewardesses));
		}
	}
}
