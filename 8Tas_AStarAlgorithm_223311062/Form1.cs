using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8Tas_AStarAlgorithm_223311062
{
    public partial class Form1 : Form
    {
        private Button[,] buttons;

        public Form1()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            buttons = new Button[3, 3]
            {
                { button1, button2, button3 },
                { button4, button5, button6 },
                { button7, button8, button9 }
            };
        }

        private void UpdateBoard(int[,] matris)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = matris[i, j] == 0 ? "" : matris[i, j].ToString();
                }
            }
        }
              
        private int[,] StringToMatrix(string input)
        {
            try
            {
                int[] numbers = input.Split(',').Select(int.Parse).ToArray();
                if (numbers.Length != 9) return null;

                int[,] matrix = new int[3, 3];
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        matrix[i, j] = numbers[i * 3 + j];
                
                return matrix;
            }
            catch
            {
                return null;
            }
        }

        private void btnCoz_Click(object sender, EventArgs e)
        {
            string baslangicInput = txtBaslangic.Text.Trim();
            string hedefInput = txtHedef.Text.Trim();

            int[,] baslangicMatrisi = StringToMatrix(baslangicInput);
            int[,] hedefMatrisi = StringToMatrix(hedefInput);

            if (baslangicMatrisi == null || hedefMatrisi == null)
            {
                MessageBox.Show("Lütfen doğru formatta giriş yapınız! (Örn: 1,2,3,4,5,6,7,8,0)");
                return;
            }

            UpdateBoard(baslangicMatrisi);

            List<int[,]> adimlar = AStarSolver.Solve(baslangicMatrisi, hedefMatrisi);

            if (adimlar != null)
            {
                foreach (var adim in adimlar)
                {
                    UpdateBoard(adim);

                  
                    System.Threading.Thread.Sleep(1000);
                    Application.DoEvents();
                }

                
                MessageBox.Show("Çözüm Tamamlandı!", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Çözüm bulunamadı!");
            }
        }

       
    }
}
