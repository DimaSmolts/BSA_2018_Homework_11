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
using UWPClient.View;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace UWPClient
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

			myFrame.Navigate(typeof(Flights));
			//TitleTextBlock.Text = "Главная";
		}

		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (PlaneTypes.IsSelected)
			{
				myFrame.Navigate(typeof(PlaneType));
				TitleTextBlock.Text = "PlaneTypes";
			}
			else if (Flights.IsSelected)
			{
				myFrame.Navigate(typeof(Flights));
				TitleTextBlock.Text = "Flights";
			}
			else if (Pilots.IsSelected)
			{
				myFrame.Navigate(typeof(Pilots));
				TitleTextBlock.Text = "Pilots";
			}
			else if (Stewardesses.IsSelected)
			{
				myFrame.Navigate(typeof(Stewardesses));
				TitleTextBlock.Text = "Stewardesses";
			}
			else if (Crews.IsSelected)
			{
				myFrame.Navigate(typeof(Crews));
				TitleTextBlock.Text = "Crews";
			}
			else if (Tickets.IsSelected)
			{
				myFrame.Navigate(typeof(Tickets));
				TitleTextBlock.Text = "Tickets";
			}
			else if (Planes.IsSelected)
			{
				myFrame.Navigate(typeof(Planes));
				TitleTextBlock.Text = "Planes";
			}
			else if (TakeOffs.IsSelected)
			{
				myFrame.Navigate(typeof(TakeOffs));
				TitleTextBlock.Text = "TakeOffs";
			}
			
		}

		private void HamburgerButton_Click(object sender, RoutedEventArgs e)
		{
			mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
		}
	}
}
