using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_task_7
{
    public class ComplexNumber
    {
        private double re;
        private double im;

        public double Re { get => re; set => re = value; }
        public double Im { get => im; set => im = value; }

        public ComplexNumber() : this(0, 0) { }

        public ComplexNumber(double _re, double _im)
        {
            Re = _re;
            Im = _im;
        }
       
        public ComplexNumber GetConjugate()
        {
            return new ComplexNumber(Re, -Im);
        }

        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.Re + c2.Re, c1.Im + c2.Im);
        }
        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.Re - c2.Re, c1.Im - c2.Im);
        }
        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.Re * c2.Re - c1.Im * c2.Im, c1.Re * c2.Im + c1.Im * c2.Re);
        }
        public static ComplexNumber operator /(ComplexNumber c1, ComplexNumber c2)
        {
            if ((c2.Re * c2.Re + c2.Im * c2.Im).Equals(0) && (c2.Re * c2.Re + c2.Im * c2.Im).Equals(0))
            {
                throw new ArgumentException();
            }
            return new ComplexNumber((c1.Re * c2.Re + c1.Im * c2.Im) / (c2.Re * c2.Re + c2.Im * c2.Im), (c1.Im * c2.Re - c1.Re * c2.Im) / (c2.Re * c2.Re + c2.Im * c2.Im));
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            ComplexNumber p = (ComplexNumber)obj;
            if (Re.Equals(p.Re) && Im.Equals(p.Im)) return true;
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = -196947237;
            hashCode = hashCode * -1521134295 + Re.GetHashCode();
            hashCode = hashCode * -1521134295 + Im.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(ComplexNumber p1, ComplexNumber p2)
        {
            return Object.Equals(p1, p2);
        }
        public static bool operator !=(ComplexNumber p1, ComplexNumber p2)
        {
            return !(p1 == p2);
        }
    }
}
