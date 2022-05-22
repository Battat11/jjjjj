using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
namespace шещп
{
    class Animal
    {
        protected int width = 0, height = 0;
        protected SolidColorBrush color = new SolidColorBrush(Colors.Red);
        protected Rectangle body = new Rectangle();
        protected int left = 0, top = 0, MoveLeft = 0, MoveTop = 0, speed = 0;
        public void Copy(Animal ob)
        {
            this.width = ob.GetInfo()[0];
            this.height = ob.GetInfo()[1];
            this.left = ob.GetInfo()[2];
            this.top = ob.GetInfo()[3];
            this.speed = ob.GetInfo()[4];
        }
        public int[] GetInfo()
        {
            int[] a = new int[5];
            a[0] = this.width;
            a[1] = this.height;
            a[2] = this.left;
            a[3] = this.top;
            a[4] = this.speed;
            return a;
        }
        public Animal(int w, int h, int l, int t, int s = 1)
        {
            width = w;
            height = h;
            left = l;
            top = t;
            speed = s;
        }
        public void SetColor(SolidColorBrush c)
        {
            this.color = c;
        }
        public void Translaiet(int a, int b)
        {
            this.left += a;
            this.top += b;
            this.body.Margin = new System.Windows.Thickness(this.left, this.top, 0, 0);
        }
        public void Load()
        {
            this.body.Margin = new System.Windows.Thickness(this.left, this.top, 0, 0);
            this.body.Width = this.width;
            this.body.Height = this.height;
            this.body.Fill = this.color;
        }
        public void Update()
        {
            if (this.MoveLeft != this.left || this.MoveTop != this.top)
            {
                if (this.left < this.MoveLeft) { this.left += this.speed; }
                if (this.left > this.MoveLeft) { this.left -= this.speed; }
                if (this.top < this.MoveTop) { this.top += this.speed; }
                if (this.top > this.MoveTop) { this.top -= this.speed; }
                this.body.Margin = new System.Windows.Thickness(this.left, this.top, 0, 0);
            }
            if (this.MoveLeft == this.left && this.MoveTop == this.top)
            {
                Random rand = new Random();
                this.MoveLeft = this.left + rand.Next(-50, 50);
                this.MoveTop = this.top + rand.Next(-50, 50);
            }
        }
        public Rectangle Get()
        {
            return this.body;
        }
    }
}