using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace Minesweeper
{
    public enum Status
    {
        InProgress,
        Won,
        Lost
    }

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    public partial class Form1 : Form
    {
        private Button[,] buttons = new Button[20, 20];
        private List<Cell> cells = new List<Cell>();
        private int _totalMineAmount, _activeMineCount, _timeCounter;

        public Form1(Difficulty difficulty)
        {
            InitializeComponent();
            InitializeButtons();
            InitializeDifficulty(difficulty);
            ChangeStatus(Status.InProgress);

            InitializeTimer();
            InitializeForm();

            PlantMines();
            NumberCells();

            SuspendLayout();
        }

        private void InitializeDifficulty(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    InstantiateMines(20);
                    break;
                case Difficulty.Medium:
                    InstantiateMines(40);
                    break;
                case Difficulty.Hard:
                    InstantiateMines(80);
                    break;
                default:
                    MessageBox.Show("This application has run into technical difficulties, please contact " +
                                    "the idiot who programmed it.");
                    break;
            }
        }

        private void InstantiateMines(int mineAmount)
        {
            _totalMineAmount = mineAmount;
            _activeMineCount = mineAmount;
            LabelMineCount.Text = _activeMineCount + "";
        }

        private void ChangeStatus(Status status)
        {
            switch (status)
            {
                case Status.InProgress:
                    labelGameStatus.Text = "(O_O)";
                    break;
                case Status.Won:
                    labelGameStatus.Text = "(⌐■_■)";
                    break;
                case Status.Lost:
                    labelGameStatus.Text = "(x_x)";
                    break;
            }
        }

        private void InitializeTimer()
        {
            _timeCounter = 0;
            Timer tmr = new Timer();
            tmr.Interval = 1000;
            tmr.Tick += tmr_Tick;
            tmr.Start();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            labelTimer.Text = TimeSpan.FromSeconds(++_timeCounter) + "";
        }

        private void InitializeButtons()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Location = new Point(j * 25, 50 + i * 25);
                    buttons[i, j].Size = new Size(25, 25);
                    buttons[i, j].TabIndex = i;
                    buttons[i, j].Text = " ";
                    buttons[i, j].UseVisualStyleBackColor = true;
                    buttons[i, j].MouseDown += buttons_MouseDown;
                }
            }
        }

        private void InitializeForm()
        {
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 550);
            for (var i = 0; i < 20; i++)
            {
                for (var j = 0; j < 20; j++)
                {
                    Controls.Add(buttons[i, j]);
                    cells.Add(new Cell(buttons[i, j].Location.X, buttons[i, j].Location.Y, i, j));
                }
            }
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Minesweeper";
            ResumeLayout(false);
        }

        private void PlantMines()
        {
            Random random = new Random();

            for (var i = 0; i < _totalMineAmount; i++)
            {
                var randomCell = random.Next(400);
                if (cells[randomCell].isMine())
                {
                    i--; // already has a mine
                }
                else
                {
                    cells[randomCell].PlantMine();
                }
            }
        }

        private void NumberCells()
        {
            foreach (var cell in cells)
            {
                cell.setNumber(CountSurroundingMines(cell.getX(), cell.getY()));
            }
        }

        private int CountSurroundingMines(int x, int y)
        {
            int surroundingMineCount = 0;

            for (int i = -25; i <= 25; i += 25)
            {
                for (int j = -25; j <= 25; j += 25)
                {
                    if (i + x < 0)
                        continue;
                    if (j + y < 50)
                        continue;
                    if (i + x > 475)
                        continue;
                    if (j + y > 525)
                        continue;
                    if (i == 0 && j == 0)
                        continue;

                    Cell adjacentCell = cells.Find(c => c.getX() == (i + x) && c.getY() == (j + y));
                    if (adjacentCell.isMine())
                    {
                        surroundingMineCount++;
                    }
                }
            }

            return surroundingMineCount;
        }

        private void buttons_MouseDown(object sender, MouseEventArgs e)
        {
            var current = sender as Button;
            var x = current.Location.X;
            var y = current.Location.Y;
            Cell currentCell = cells.Find(c => c.getXY() == (x + " " + y));

            if (currentCell.IsVisible())
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (currentCell.isMine())
                    LoseGame();
                else
                    ClickCell(current, currentCell);
            }
            if (e.Button == MouseButtons.Right)
            {
                if (current.Text == "⚑")
                {
                    IncrementMineCount();
                    current.Text = " ";
                    current.ForeColor = Color.Black;
                }
                else
                {
                    DecrementMineCount();
                    current.Text = "⚑";
                    current.ForeColor = Color.Orange;
                }
            }
        }

        private void ClickCell(Button current, Cell currentCell)
        {
            CheckForWin();
            NumberCell(current, currentCell);
            CheckSurroundingCells(current.Location.X, current.Location.Y, currentCell);
        }

        private void CheckForWin()
        {
            int revealedCells = 0;
            foreach (var cell in cells)
            {
                if (cell.IsVisible())
                    revealedCells++;
            }
            if (200 - revealedCells == _totalMineAmount)
            {
                ChangeStatus(Status.Won);
            }
        }

        private void NumberCell(Button current, Cell currentCell)
        {
            int surroundingMines = currentCell.getNumber();

            currentCell.MakeVisible();

            if (surroundingMines == 0)
            {
                current.BackColor = Color.BlanchedAlmond;
                current.Text = " ";
            }
            else
            {
                current.BackColor = Color.AntiqueWhite;
                current.Text = surroundingMines + "";
            }

            current.ForeColor = Color.Blue;
        }

        private void CheckSurroundingCells(int x, int y, Cell currentCell)
        {
            for (int i = -25; i <= 25; i += 25)
            {
                for (int j = -25; j <= 25; j += 25)
                {
                    var adjacentX = i + x;
                    var adjacentY = j + y;

                    if (adjacentX < 0)
                        continue;
                    if (adjacentY < 50)
                        continue;
                    if (adjacentX > 475)
                        continue;
                    if (adjacentY > 525)
                        continue;
                    if (i == 0 && j == 0)
                        continue;

                    Cell adjacentCell = cells.Find(c => c.getX() == adjacentX && c.getY() == adjacentY);
                    int adjacentI = adjacentCell.getI(), adjacentJ = adjacentCell.getJ();

                    if (adjacentCell.isMine() || currentCell.getNumber() != 0)
                    {
                        continue;
                    }
                    buttons_MouseDown(buttons[adjacentI, adjacentJ], new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
                }
            }
        }



        private void LoseGame()
        {
            foreach (Button button in buttons)
            {
                Cell correspondingCell = cells.Find(c => c.getXY() == (button.Location.X + " " + button.Location.Y));
                if (correspondingCell.isMine())
                {
                    button.Text = "💣";
                    button.ForeColor = Color.Red;
                }

                correspondingCell.MakeVisible();
            }
            ChangeStatus(Status.Lost);
        }

        private void IncrementMineCount()
        {
            LabelMineCount.Text = ++_activeMineCount + "";
        }

        private void DecrementMineCount()
        {
            LabelMineCount.Text = --_activeMineCount + "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestartForm(Difficulty.Easy);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RestartForm(Difficulty.Medium);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RestartForm(Difficulty.Hard);
        }

        private void RestartForm(Difficulty difficulty)
        {
            Hide();
            Form1 newForm = new Form1(difficulty);
            newForm.ShowDialog();
            Close();
        }
    }
}
