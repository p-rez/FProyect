﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FProy
{
    /// <summary>
    /// Lógica de interacción para EDIJuegos.xaml
    /// </summary>
    public partial class EDIJuegos : Window
    {
        public EDIJuegos()
        {
            InitializeComponent();
        }

        private void dbg_Loaded(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("Instrucciones: \n 1.- Seleccionar ID del juego\n 2.- Realizar cambios y ajustes en cuadros de texto ó listas\n 3.- Clic en 'guardar cambios' ");
        
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            cb1.ItemsSource = db.Juegos.ToList();
            cb1.DisplayMemberPath = "idjuego";
            cb1.SelectedValuePath = "idjuego";

            cb2.ItemsSource = db.Generos.ToList();
            cb2.DisplayMemberPath = "nameg";
            cb2.SelectedValuePath = "codgen";

            cb3.ItemsSource = db.Consolas.ToList();
            cb3.DisplayMemberPath = "namecons";
            cb3.SelectedValuePath = "codcons";

            cb4.ItemsSource = db.Companias.ToList();
            cb4.DisplayMemberPath = "namec";
            cb4.SelectedValuePath = "codcomp";

        
        
        }

        private void Ver1_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();

            int idGame = (int)cb1.SelectedValue;
           var cons = from s in db.Juegos

                       where s.idjuego == idGame
                       select s;
           dbg.ItemsSource = cons.ToList();

            var cons1 = db.Juegos.SingleOrDefault(s => s.idjuego == idGame);
            t1.Text = cons1.namej;
            t2.Text = Convert.ToString(cons1.precio);
            t3.Text = cons1.rdate;

            
          

        

            
            
   
        }

        private void Ver_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();

            var cons = from s in db.Juegos
                       select s;
            dbg.ItemsSource = cons.ToList();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            int id = (Int32)cb1.SelectedValue;

            var cons = db.Juegos.SingleOrDefault(s => s.idjuego == id);


            if (cons != null)
            {
                cons.namej = Convert.ToString(t1.Text);
                cons.precio = Convert.ToSingle(t2.Text);
                cons.rdate = (String)t3.Text;

                cons.codgen = (String)cb2.SelectedValue;
                cons.codcons = (String)cb3.SelectedValue;
                cons.codcomp = (String)cb4.SelectedValue;

                db.SaveChanges();
            }

        }
    }
}
