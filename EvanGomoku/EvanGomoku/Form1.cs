//技术点：graphics画图，重绘机制，输赢检测

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;

namespace EvanGomoku
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private const int chessboardRowCount = 15;  //chessboard box number
        private const int chessboardColCount = 15;
        private int chessboardWidth = 0;  //chessboard size
        private int chessboardHeight = 0;
        private int boxWidth = 0;  //chessboard each box size
        private int boxHeight = 0;
        private Graphics chessboardGraphics;  //chessboard graphics
        private int[,] chessboardState = new int[chessboardRowCount, chessboardColCount];  //0:blank;1:human;2:AI
        private bool isOver = false;

        private void MainForm_Load(object sender, EventArgs e)
        {
            appendLog("Start");
            //get chessboard size
            chessboardWidth = chessboardPanel.Width;
            chessboardHeight = chessboardPanel.Height;
            //get chessboard each box size
            boxWidth = chessboardWidth / chessboardRowCount;
            boxHeight = chessboardHeight / chessboardColCount;
            //init graphics
            chessboardGraphics = chessboardPanel.CreateGraphics();
            //init chessboardState
            initChessboardState();
        }

        private void appendLog(string str)
        {
            logTextBox.Text += str + "\r\n";
            logTextBox.SelectionStart = logTextBox.TextLength;
            logTextBox.ScrollToCaret();
        }

        private void initChessboardState()
        {
            for (int i = 0; i < chessboardRowCount; i++)
            {
                for (int j = 0; j < chessboardColCount; j++)
                {
                    chessboardState[i, j] = 0;
                }
            }
        }

        private void drawChessboard()
        {
            //draw chessboard box
            SolidBrush sbBoxWheat = new SolidBrush(Color.Wheat);
            SolidBrush sbBoxWhite = new SolidBrush(Color.White);
            for (int i = 0; i < chessboardRowCount; i++)
            {
                for (int j = 0; j < chessboardColCount; j++)
                {
                    Rectangle rectangle = new Rectangle(new Point(i * boxWidth, j * boxHeight), new Size(boxWidth, boxHeight));
                    if ((i % 2 == 0) && (j % 2 == 0))
                    {
                        chessboardGraphics.FillRectangle(sbBoxWheat, rectangle);
                    }
                    else if ((i % 2 == 0) && (j % 2 == 1))
                    {
                        chessboardGraphics.FillRectangle(sbBoxWhite, rectangle);
                    }
                    else if ((i % 2 == 1) && (j % 2 == 0))
                    {
                        chessboardGraphics.FillRectangle(sbBoxWhite, rectangle);
                    }
                    else if ((i % 2 == 1) && (j % 2 == 1))
                    {
                        chessboardGraphics.FillRectangle(sbBoxWheat, rectangle);
                    }
                }
            }
            //draw chessboard line
            SolidBrush sbPen = new SolidBrush(Color.Black);
            Pen pen = new Pen(sbPen, 1);
            for (int i = 0; i < chessboardRowCount; i++)
            {
                chessboardGraphics.DrawLine(pen, new Point(i * boxWidth, 0), new Point(i * boxWidth, chessboardHeight));
            }
            for (int j = 0; j < chessboardColCount; j++)
            {
                chessboardGraphics.DrawLine(pen, new Point(0, j * boxHeight), new Point(chessboardHeight, j * boxHeight));
            }
        }

        private int screenX2indexI(int x)
        {
            return x / boxWidth;
        }

        private int screenY2indexJ(int y)
        {
            return y / boxHeight;
        }

        private void drawChesspiece(bool isAI, int indexI, int indexJ)
        {
            SolidBrush sbAI = new SolidBrush(Color.Red);
            SolidBrush sbHuman = new SolidBrush(Color.Black);
            int offset = 2;  //offset to box edge
            Rectangle rectangle = new Rectangle(new Point(indexI * boxWidth + offset, indexJ * boxHeight + offset), new Size(boxWidth - offset * 2, boxHeight - offset - 2));
            if(isAI)
            {
                chessboardGraphics.FillEllipse(sbAI, rectangle);
            }
            else
            {
                chessboardGraphics.FillEllipse(sbHuman, rectangle);
            }
        }

        private void redrawChesspiece()
        {
            for(int i = 0; i < chessboardRowCount; i++)
            {
                for(int j = 0; j < chessboardColCount; j++)
                {
                    if(chessboardState[i, j] == 1)
                    {
                        drawChesspiece(false, i, j);
                    }
                    else if (chessboardState[i, j] == 2)
                    {
                        drawChesspiece(true, i, j);
                    }
                }
            }
        }

        private void chessboardPanel_Paint(object sender, PaintEventArgs e)
        {
            drawChessboard();
            redrawChesspiece();
        }

        private bool isFivePieceInOneLine(int pieceType, int indexI, int indexJ)
        {
            //horizontal
            if(indexI < chessboardRowCount - 4)
            {
                bool result = true;
                for(int i = 1; i <= 4; i++)
                {
                    if(chessboardState[indexI + i, indexJ] != pieceType)
                    {
                        result = false;
                    }
                }
                if(result == true)
                {
                    return true;
                }
            }
            //vertical
            if(indexJ < chessboardColCount - 4)
            {
                bool result = true;
                for (int j = 1; j <= 4; j++)
                {
                    if (chessboardState[indexI, indexJ + j] != pieceType)
                    {
                        result = false;
                    }
                }
                if (result == true)
                {
                    return true;
                }
            }
            //left top to right bottom
            if ((indexI < chessboardRowCount - 4) && (indexJ < chessboardColCount - 4))
            {
                bool result = true;
                for (int k = 1; k <= 4; k++)
                {
                    if (chessboardState[indexI + k, indexJ + k] != pieceType)
                    {
                        result = false;
                    }
                }
                if (result == true)
                {
                    return true;
                }
            }
            //right top to left bottom
            if ((indexI > 4) && (indexJ < chessboardColCount - 4))
            {
                bool result = true;
                for (int k = 1; k <= 4; k++)
                {
                    if (chessboardState[indexI - k, indexJ + k] != pieceType)
                    {
                        result = false;
                    }
                }
                if (result == true)
                {
                    return true;
                }
            }
            return false;
        }

        private void checkWinner()
        {
            for (int i = 0; i < chessboardRowCount; i++)
            {
                for (int j = 0; j < chessboardColCount; j++)
                {
                    if (chessboardState[i, j] == 1)
                    {
                        if(isFivePieceInOneLine(1, i, j))
                        {
                            //human win
                            appendLog("Human win");
                            isOver = true;
                            MessageBox.Show("Human win", "Message", MessageBoxButtons.OK);
                            appendLog("Stop");
                        }
                    }
                    else if (chessboardState[i, j] == 2)
                    {
                        if(isFivePieceInOneLine(2, i, j))
                        {
                            //AI win
                            appendLog("AI win");
                            isOver = true;
                            MessageBox.Show("AI win", "Message", MessageBoxButtons.OK);
                            appendLog("Stop");
                        }
                    }
                }
            }
        }

        private void chessboardPanel_MouseDown(object sender, MouseEventArgs e)
        {
            int indexI = screenX2indexI(e.X);
            int indexJ = screenY2indexJ(e.Y);
            if(isOver == false && chessboardState[indexI, indexJ] == 0)
            {
                appendLog("Human piece in (" + indexI.ToString() + ", " + indexJ.ToString() + ")");
                chessboardState[indexI, indexJ] = 1;
                drawChesspiece(false, indexI, indexJ);
                checkWinner();
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            logTextBox.Text = "";
            appendLog("Restart");
            initChessboardState();
            isOver = false;
            drawChessboard();
            redrawChesspiece();
        }
    }
}
