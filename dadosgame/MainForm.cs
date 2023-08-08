/*
 * Created by SharpDevelop.
 * User: Alunos
 * Date: 09/05/2023
 * Time: 22:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace dadosgame
{
	public partial class MainForm : Form
	{
		public MainForm()
		{

			InitializeComponent();
			
		}
	
		Random rnd = new Random(); int vpl = 0; int vpc = 0; int pointpc, pointpl;
		int n1, n2, n3, n4, n5, n6, n7; int time = 0; SoundPlayer dice = new SoundPlayer("rollingDice.wav");
		
		void Button1Click(object sender, EventArgs e)
		{
			label3.Text = "COMPUTADOR: " + pointpc;
			button1.Enabled = false; button2.Enabled = true;
			pictureBox6.Load("dado" + n6 + ".png"); pictureBox7.Load("dado" + n7 + ".png");
			pictureBox4.Enabled = false; pictureBox5.Enabled = false;
			
			if (pointpl > 13) {
				vpc = vpc + 1; label1.Text = "VITÓRIAS DO COMPUTADOR: " + vpc;
				MessageBox.Show("LIMITE EXCEDIDO! Tente novamente...");
			}
			
			if (pointpl < pointpc) {
				vpc = vpc + 1; label1.Text = "VITÓRIAS DO COMPUTADOR: " + vpc;
				MessageBox.Show("Então... VOCÊ PERDEU! Tente novamente.");
			}

			if (pointpl > pointpc && pointpl < 13) {
				vpl = vpl + 1; label2.Text = "VITÓRIAS DO JOGADOR: " + vpl;
				MessageBox.Show("PARABÉNS! Você ganhou. Continue assim!");
			}
			
			if (pointpl == pointpc){
				vpc = vpc + 1; label1.Text = "VITÓRIAS DO COMPUTADOR: " + vpc;
				MessageBox.Show("Vixi... Empate? Sinto em dizer...\n VOCÊ PERDER!");
			}
			
			if (vpc == 3) {
				MessageBox.Show("Como eu digo isso...\nVOCÊ PERDEU O GAME! PERDEU TUDO PARÇA!!!");
			}
			
			if (vpl == 3) {
				MessageBox.Show("Namoral mesmo...XD\nTU É BAUM DEMAIS! PARÁBENS TA RE-APROVADO!");
			}
			
		}
		void Button2Click(object sender, EventArgs e)
		{
			if (vpc > 0 || vpl > 0) {
				pictureBox1.Load("dado" + n1 + ".png");
				pictureBox2.Load("dado" + n2 + ".png");
				
				pictureBox3.Load("interrogacao.png"); pictureBox4.Load("interrogacao.png"); pictureBox5.Load("interrogacao.png");
				pictureBox6.Load("interrogacao.png"); pictureBox7.Load("interrogacao.png"); pointpl = 0; pointpc = 0;
				pictureBox4.Visible = false; pictureBox5.Visible = false; label3.Text = "COMPUTADOR: ?"; label4.Text = "JOGADOR: ";
				pictureBox3.Enabled = true; pictureBox4.Enabled = true; pictureBox5.Enabled = true; pictureBox3.Visible = false;
			}
			
			if (vpl == 3 || vpc == 3) {
				vpl = 0; label2.Text = "VITÓRIAS DO JOGADOR: " + vpl;
				vpc = 0; label1.Text = "VITÓRIAS DO COMPUTADOR: " + vpc;
			}
			
			timer1.Enabled = true;
			button2.Enabled = false; button1.Enabled = true;
			n6 = rnd.Next(1,7); n7 = rnd.Next(1,7);
			pointpc = n6 + n7; time = 0; dice.Play();
		}
		void PictureBox3Click(object sender, EventArgs e)
		{
			pictureBox3.Enabled = false;
			timer1.Enabled = true; dice.Play();
		}
		void PictureBox4Click(object sender, EventArgs e)
		{
			pictureBox4.Enabled = false;
			timer1.Enabled = true; dice.Play();
		}
		void PictureBox5Click(object sender, EventArgs e)
		{
			pictureBox5.Enabled = false;
			timer1.Enabled = true; dice.Play();
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			time++;
			
			if (time > 0 && time < 12) {
				n1 = rnd.Next(1,7);
				pictureBox1.Load("dado" + n1 + ".png");
				n2 = rnd.Next(1,7);
				pictureBox2.Load("dado" + n2 + ".png");
			}
			if (time == 12) {
				timer1.Enabled = false; pointpl = n1 + n2;
				label4.Text = "JOGADOR: " + pointpl; pictureBox3.Visible = true;
			}
			
			if (time > 12 && time < 24) {
				n3 = rnd.Next(1,7);
				pictureBox3.Load("dado" + n3 + ".png");
			}
			if (time == 24) {
				timer1.Enabled = false; pictureBox4.Visible = true;
				pointpl = pointpl + n3; label4.Text = "JOGADOR: " + pointpl;
			}
			
			if (time > 24 && time < 36) {
				n4 = rnd.Next(1,7);
				pictureBox4.Load("dado" + n4 + ".png");
			}
			if (time == 36) {
				timer1.Enabled = false; pictureBox5.Visible = true;
				pointpl = pointpl + n4; label4.Text = "JOGADOR: " + pointpl;
			}
			
			if (time > 36 && time < 48) {
				n5 = rnd.Next(1,7);
				pictureBox5.Load("dado" + n5 + ".png");
			}
			if (time == 48) {
				timer1.Enabled = false; button1.PerformClick();
				pointpl = pointpl + n5; label4.Text = "JOGADOR: " + pointpl;
			}
		}
	}
}
