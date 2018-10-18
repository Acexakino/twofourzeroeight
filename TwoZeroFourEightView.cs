using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twozerofoureight
{
    public partial class TwoZeroFourEightView : Form, View
    {
        Model model;
        Controller controller;

        public TwoZeroFourEightView()
        {
            InitializeComponent();
            model = new TwoZeroFourEightModel();
            model.AttachObserver(this);
            controller = new TwoZeroFourEightController();
            controller.AddModel(model);
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
            KeyPreview = true;
        }

        public void Notify(Model m)
        {
            UpdateBoard(((TwoZeroFourEightModel)m).GetBoard());
            Score_Display.Text = ((TwoZeroFourEightModel)model).GetScore();

            if (((TwoZeroFourEightModel)m).isNotPlayable())
            {
                EndGame();
            }
        }
      
        private void UpdateTile(Label l, int i)
        {
            if (i != 0)
            {
                l.Text = Convert.ToString(i);
            }
            else
            {
                l.Text = "";
            }
            switch (i)
            {
                case 0:
                    l.BackColor = Color.LightGray;
                    break;
                case 2:
                    l.BackColor = Color.FromArgb(255, 204, 153);
                    l.ForeColor = Color.Black;
                    break;
                case 4:
                    l.BackColor = Color.FromArgb(255, 204, 102);
                    l.ForeColor = Color.Black;
                    break;
                case 8:
                    l.BackColor = Color.Orange;
                    l.ForeColor = Color.White;
                    break;
                case 16:
                    l.BackColor = Color.DarkOrange;
                    l.ForeColor = Color.White;
                    break;
                case 32:
                    l.BackColor = Color.Red;
                    l.ForeColor = Color.White;
                    break;
                case 64:
                    l.BackColor = Color.DarkRed;
                    l.ForeColor = Color.White;
                    break;
                case 128:
                    l.BackColor = Color.FromArgb(255, 255, 102);
                    l.ForeColor = Color.Black;
                    break;
                case 256:
                    l.BackColor = Color.Yellow;
                    l.ForeColor = Color.Black;
                    break;
                case 512:
                    l.BackColor = Color.FromArgb(102, 153, 255);
                    l.ForeColor = Color.White;
                    break;
                case 1024:
                    l.BackColor = Color.FromArgb(51, 102, 255);
                    l.ForeColor = Color.White;
                    break;
                case 2048:
                    l.BackColor = Color.FromArgb(0, 0, 255);
                    l.ForeColor = Color.White;
                    break;
                case 4096:
                    l.BackColor = Color.FromArgb(255, 102, 255);
                    l.ForeColor = Color.White;
                    break;
                case 8192:
                    l.BackColor = Color.FromArgb(204, 0, 204);
                    l.ForeColor = Color.White;
                    break;
                case 16384:
                    l.BackColor = Color.FromArgb(153, 0, 204);
                    l.ForeColor = Color.White;
                    break;
                default:
                    l.BackColor = Color.Black;
                    l.ForeColor = Color.White;
                    break;
            }
        }

        private void UpdateBoard(int[,] board)
        {
            UpdateTile(lbl00, board[0, 0]);
            UpdateTile(lbl01, board[0, 1]);
            UpdateTile(lbl02, board[0, 2]);
            UpdateTile(lbl03, board[0, 3]);
            UpdateTile(lbl10, board[1, 0]);
            UpdateTile(lbl11, board[1, 1]);
            UpdateTile(lbl12, board[1, 2]);
            UpdateTile(lbl13, board[1, 3]);
            UpdateTile(lbl20, board[2, 0]);
            UpdateTile(lbl21, board[2, 1]);
            UpdateTile(lbl22, board[2, 2]);
            UpdateTile(lbl23, board[2, 3]);
            UpdateTile(lbl30, board[3, 0]);
            UpdateTile(lbl31, board[3, 1]);
            UpdateTile(lbl32, board[3, 2]);
            UpdateTile(lbl33, board[3, 3]);
        }

        private void EndGame()
        {
            MessageBox.Show("GAME OVER: BETTER LUCK NEXT TIME!");
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "←":
                    controller.ActionPerformed(TwoZeroFourEightController.LEFT);
                    break;
                case "↑":
                    controller.ActionPerformed(TwoZeroFourEightController.UP);
                    break;
                case "→":
                    controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
                    break;
                case "↓":
                    controller.ActionPerformed(TwoZeroFourEightController.DOWN);
                    break;
            }
        }

        private void btnAll_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    btnLeft.Focus();
                    controller.ActionPerformed(TwoZeroFourEightController.LEFT);
                    e.IsInputKey = true;
                    break;
                case Keys.Up:
                    btnUp.Focus();
                    controller.ActionPerformed(TwoZeroFourEightController.UP);
                    e.IsInputKey = true;
                    break;
                case Keys.Right:
                    btnRight.Focus();
                    controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
                    e.IsInputKey = true;
                    break;
                case Keys.Down:
                    btnDown.Focus();
                    controller.ActionPerformed(TwoZeroFourEightController.DOWN);
                    e.IsInputKey = true;
                    break;
            }
        }
    }
}
