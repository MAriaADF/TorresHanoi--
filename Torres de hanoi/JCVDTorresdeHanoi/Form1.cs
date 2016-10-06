
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

        //Al mover el mouse hacia las torres, que utilice la funcion del sistema "Refresh" para que dibuje el anillo que se mueve
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (intA | intB | intC) { this.Refresh(); }

            if (intA)
            {
                crear.FillRectangle(new SolidBrush(Color.LightCoral), 90 - (TorreA[AnillosA - 1] * 10), 210 - ((AnillosA - 1) * 20), 20 * TorreA[AnillosA - 1], 20);
                crear.FillRectangle(new SolidBrush(Color.Azure), 85, 210 - ((AnillosA - 1) * 20), 10, 20);// se dibuja el anillo en movimiento y se cambia el color
                int x = e.X - (10 * TorreA[AnillosA - 1]);
                int y = e.Y - 10;
                crear.FillRectangle(new SolidBrush(Color.Black), x, y, 20 * TorreA[AnillosA - 1], 20);

                if (TorreA[AnillosA - 1] == 1) { color = Color.Coral; }
                if (TorreA[AnillosA - 1] == 2) { color = Color.Brown; }
                if (TorreA[AnillosA - 1] == 3) { color = Color.BlueViolet; }
                if (TorreA[AnillosA - 1] == 4) { color = Color.DarkBlue; }
                if (TorreA[AnillosA - 1] == 5) { color = Color.DarkRed; }
                if (TorreA[AnillosA - 1] == 6) { color = Color.Yellow; }
                if (TorreA[AnillosA - 1] == 7) { color = Color.White; }
                if (TorreA[AnillosA - 1] == 8) { color = Color.CadetBlue; }
                crear.FillRectangle(new SolidBrush(color), x + 2, y + 2, (20 * TorreA[AnillosA - 1]) - 4, 16);
            }
            if (intB)
            {
                crear.FillRectangle(new SolidBrush(Color.LightCoral), 250 - (TorreB[AnillosB - 1] * 10), 210 - ((AnillosB - 1) * 20), 20 * TorreB[AnillosB - 1], 20);
                crear.FillRectangle(new SolidBrush(Color.Brown), 245, 210 - ((AnillosB - 1) * 20), 10, 20);
                int x = e.X - (10 * TorreB[AnillosB - 1]);
                int y = e.Y - 10;
                crear.FillRectangle(new SolidBrush(Color.Black), x, y, 20 * TorreB[AnillosB - 1], 20);

                if (TorreB[AnillosB - 1] == 1) { color = Color.Coral; }
                if (TorreB[AnillosB - 1] == 2) { color = Color.Brown; }
                if (TorreB[AnillosB - 1] == 3) { color = Color.BlueViolet; }
                if (TorreB[AnillosB - 1] == 4) { color = Color.DarkBlue; }
                if (TorreB[AnillosB - 1] == 5) { color = Color.DarkRed; }
                if (TorreB[AnillosB - 1] == 6) { color = Color.Yellow; }
                if (TorreB[AnillosB - 1] == 7) { color = Color.White; }
                if (TorreA[AnillosB - 1] == 8) { color = Color.CadetBlue; }
                crear.FillRectangle(new SolidBrush(color), x + 2, y + 2, (20 * TorreB[AnillosB - 1]) - 4, 16);
            }
            if (intC)
            {
                crear.FillRectangle(new SolidBrush(Color.LightCoral), 410 - (TorreC[AnillosC - 1] * 10), 210 - ((AnillosC - 1) * 20), 20 * TorreC[AnillosC - 1], 20);
                crear.FillRectangle(new SolidBrush(Color.Brown), 405, 210 - ((AnillosC - 1) * 20), 10, 20);
                int x = e.X - (10 * TorreC[AnillosC - 1]);
                int y = e.Y - 10;
                crear.FillRectangle(new SolidBrush(Color.Black), x, y, 20 * TorreC[AnillosC - 1], 20);

                if (TorreC[AnillosC - 1] == 1) { color = Color.Coral; }
                if (TorreC[AnillosC - 1] == 2) { color = Color.Brown; }
                if (TorreC[AnillosC - 1] == 3) { color = Color.BlueViolet; }
                if (TorreC[AnillosC - 1] == 4) { color = Color.DarkBlue; }
                if (TorreC[AnillosC - 1] == 5) { color = Color.DarkRed; }
                if (TorreC[AnillosC - 1] == 6) { color = Color.Yellow; }
                if (TorreC[AnillosC - 1] == 7) { color = Color.White; }
                if (TorreA[AnillosC - 1] == 8) { color = Color.CadetBlue; }
                crear.FillRectangle(new SolidBrush(color), x + 2, y + 2, (20 * TorreC[AnillosC - 1]) - 4, 16);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if ((e.X >= 0 & e.X <= 170) & intB & ((finalB < finalA) | finalA == 0))
            {
                finalA = finalB;
                TorreA[AnillosA] = finalB;
                if (AnillosB > 1)
                { finalB = TorreB[AnillosB - 2]; }
                else
                { finalB = TorreB[AnillosB]; }
                TorreB[AnillosB - 1] = 0;
                AnillosA++;
                AnillosB--;
                Intentos++;
            }
            if ((e.X >= 0 & e.X <= 170) & intC & ((finalC < finalA) | finalA == 0))
            {
                finalA = finalC;
                TorreA[AnillosA] = finalC;
                if (AnillosC > 1)
                { finalC = TorreC[AnillosC - 2]; }
                else
                { finalC = TorreC[AnillosC]; }
                TorreC[AnillosC - 1] = 0;
                AnillosA++;
                AnillosC--;
                Intentos++;
            }
            if ((e.X > 170 & e.X <= 330) & intA & ((finalA < finalB) | finalB == 0))
            {
                finalB = finalA;
                TorreB[AnillosB] = finalA;
                if (AnillosA > 1)
                { finalA = TorreA[AnillosA - 2]; }
                else
                { finalA = TorreA[AnillosA]; }
                TorreA[AnillosA - 1] = 0;
                AnillosB++;
                AnillosA--;
                Intentos++;
            }
            if ((e.X > 170 & e.X <= 330) & intC & ((finalC < finalB) | finalB == 0))
            {
                finalB = finalC;
                TorreB[AnillosB] = finalC;
                if (AnillosC > 1)
                { finalC = TorreC[AnillosC - 2]; }
                else
                { finalC = TorreC[AnillosC]; }
                TorreC[AnillosC - 1] = 0;
                AnillosB++;
                AnillosC--;
                Intentos++;
            }
            if ((e.X > 330 & e.X <= 500) & intA & ((finalA < finalC) | finalC == 0))
            {
                finalC = finalA;
                TorreC[AnillosC] = finalA;
                if (AnillosA > 1)
                { finalA = TorreA[AnillosA - 2]; }
                else
                { finalA = TorreA[AnillosA]; }
                TorreA[AnillosA - 1] = 0;
                AnillosC++;
                AnillosA--;
                Intentos++;
            }
            if ((e.X > 330 & e.X <= 5000) & intB & ((finalB < finalC) | finalC == 0))
            {
                finalC = finalB;
                TorreC[AnillosC] = finalB;
                if (AnillosB > 1)
                { finalB = TorreB[AnillosB - 2]; }
                else
                { finalB = TorreB[AnillosB]; }
                TorreB[AnillosB - 1] = 0;
                AnillosC++;
                AnillosB--;
                Intentos++;
            }
            intA = false; intB = false; intC = false;
            this.Refresh();
            lblIntentos2.Text = Intentos.ToString();
            if ((TorreC[NumAnillos - 1] == 1) & Jugar)
            {
                timer1.Stop();
                intentosMin = 0;
                for (int n = 1; n <= NumAnillos; n++)
                { intentosMin = (intentosMin * 2) + 1; }
                if (Intentos > intentosMin)
                {//muestra un mensaje diciendo que ha ganado pero en un numero mayor de intentos a lo esperado
                    string mejor = "Felicidades";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    string mensaje = "Lo lograste en un tiempo de: " + this.lblIntentos3.Text + " con " + this.lblIntentos2.Text + " intentos ";
                    // Muestra el mensaje de ganador

                    result = MessageBox.Show(mensaje, mejor, buttons);

                    var resultado = (MessageBox.Show("Desea salir", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
                    if (resultado == DialogResult.Yes)
                    {
                        this.Close();

                    }
                    if (resultado == DialogResult.No)
                    {
                        panel_juego.Visible = false;
                        panel_menu.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Lo lograste en la cantidad minima de intentos: " + this.lblIntentos2.Text, "Felicidades",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    var resultado = (MessageBox.Show("Desea salir", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
                    if (resultado == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    if (resultado == DialogResult.No)
                    {
                        panel_juego.Visible = false;
                        panel_menu.Visible = true;
                    }

                }
                this.Refresh();
                Jugar = false;
            }
        }
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