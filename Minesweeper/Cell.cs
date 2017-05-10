using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Cell
    {
        private int _x, _y, _i, _j, _number;
        private bool _mine, _visible;

        public Cell(int x, int y, int i, int j)
        {
            _i = i;
            _j = j;
            _x = x;
            _y = y;
            _number = 0;
            _mine = false;
            _visible = false;
        }

        public void setNumber(int number)
        {
            _number = number;
        }

        public int getNumber()
        {
            return _number;
        }

        public int getI()
        {
            return _i;
        }

        public int getJ()
        {
            return _j;
        }

        public void PlantMine()
        {
            _mine = true;
        }

        public bool isMine()
        {
            return _mine;
        }

        public int getX()
        {
            return _x;
        }

        public int getY()
        {
            return _y;
        }

        public string getXY()
        {
            return _x + " " + _y;
        }

        public void MakeVisible()
        {
            _visible = true;
        }

        public bool IsVisible()
        {
            return _visible;
        }
    }
}