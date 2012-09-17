﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using FuzzyCalcNET.Set;
using FuzzyCalcNET.Controller;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;

namespace FuzzyMarketing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Factor> data;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Window_Initialized(object sender, EventArgs e)
        {
//            data = new ObservableCollection<Factor>();
//            data.Add(new Factor("a", 0.2, 3));
//            data.Add(new Factor("b", 0.1, 5));
//            data.Add(new Factor("c", 0.7, 4));
//            data.Add(new Factor("c", 0.7, 4));
//            data.Add(new Factor("c", 0.7, 4));
//
//            DG_e_v.ItemsSource = data;
//            DG_e_v.CanUserAddRows = true;
//            DG_e_v.CanUserDeleteRows = true;

//            DG_e_v.Columns[0].Header = "Показатель";
//            //DG_e_v.Columns[0].Width = 300;
//            DG_e_v.Columns[1].Header = "Вес";
//            DG_e_v.Columns[1].Width = 80;
//            DG_e_v.Columns[2].Header = "Значение";
//            DG_e_v.Columns[2].Width = 80;
        }

        private void DG_e_v_AutoGeneratedColumns(object sender, EventArgs e)
        {
        }

        private void add_button1_Click(object sender, RoutedEventArgs e)
        {
            data.Add(new Factor());
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ok_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(data[data.Count-1].name);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void About_program_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Fuzzy Management \n(с) 2012. ВолгГТУ. Шаховская Л.С., Аракелова И.В., Коротеев М.В.");
        }

        private void dataGrid1_AutoGeneratedColumns(object sender, EventArgs e)
        {

        }

        private void Image_btn_Click(object sender, RoutedEventArgs e)
        {
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.Filter = "JPEG Images|*.jpg";
			openFileDialog1.Title = "Выберите изображение организационной структуры";
			// Show the dialog and get result.
	    	Nullable<bool> result = openFileDialog1.ShowDialog();
            if (result == true) // Test result.
            {
                string filename = openFileDialog1.FileName;
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit(); // загружаю картинку
                bmp.UriSource = new Uri(filename);
                bmp.EndInit();
                Clipboard.SetImage(bmp);
                RTB.Paste();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
			// Configure save file dialog box
			Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
			dlg.FileName = "Document"; // Default file name
			dlg.DefaultExt = ".rtf"; // Default file extension
			dlg.Filter = "Text documents (.rtf)|*.rtf"; // Filter files by extension
			// Show save file dialog box
			Nullable<bool> result = dlg.ShowDialog();
			string filename;
			// Process save file dialog box results
			if (result == true)
			{
				// Save document
				filename = dlg.FileName;
				TextRange range;
	           	FileStream fStream;
            	range = new TextRange(RTB.Document.ContentStart, RTB.Document.ContentEnd);
            	fStream = new FileStream(filename, FileMode.Create);
            	range.Save(fStream, DataFormats.Rtf);
            	fStream.Close();
			}			
        }

    }
    class Factor
    {
        public string name { get; set; }
        public double weight { get; set; }
        public double value { get; set; }
        public Factor(string n="", double w=0.0, double v=0.0)
        {
            this.name = n;
            this.weight = w;
            this.value = v;
        }
    }
}
