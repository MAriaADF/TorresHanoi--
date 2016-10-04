
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;


namespace TorresdeHanoi
{
    public partial class torresHanoi : Form
    {
        private bool Jugar = false;// se crea uan variable que se rellena con el valor si se esta jugando
        private int finalA, finalB, finalC; //se declaran las variables que "sellan" la torre
        public int Intentos, NumAnillos, intentosMin; //se crean las variables que cuentan los intentos, los anillos que deben usarse y el numero minimo de intentos que debe realizar
        private int[] TorreA, TorreB, TorreC; // se utilizan vectores para las torres que estas cargan los anillos
        private int AnillosA, AnillosB, AnillosC;//de crean las variables anillos para validar si se cumplen las reglas del juego
        private bool intA, intB, intC;
        private int posx;
        int comp = 0;
        int comp2 = 0;
        Color color;
        Graphics crear;
        Stopwatch cronos = new Stopwatch();

        public torresHanoi()
        {
            InitializeComponent();
            crear = juego.CreateGraphics();
        }

        //Al presionar click que valide el anillo y el movimiento que se ejecuta
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.X >= 0 & e.X <= 170) & (finalA != 0)) { intA = true; intB = false; intC = false; }
            if ((e.X > 170 & e.X <= 330) & (finalB != 0)) { intB = true; intA = false; intC = false; }
            if ((e.X > 330 & e.X <= 500) & (finalC != 0)) { intC = true; intA = false; intB = false; }
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e) { }
        private void panel1_MouseUp(object sender, MouseEventArgs e) { }
        public void dibuja() { }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void timer1_Tick(object sender, EventArgs e) { }
        private void button5_Click_1(object sender, EventArgs e) { }
        private void btn_demo_Click(object sender, EventArgs e) { }
        private void btn_jugar_Click(object sender, EventArgs e) { }
        
        private void torresHanoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
           
        }
    }
}