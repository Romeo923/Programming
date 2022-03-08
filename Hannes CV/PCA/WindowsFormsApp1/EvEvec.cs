using System;
namespace FaceRecogPCA
{
    public class EvEvec : IComparable, ICloneable
    {
        public double EigenValue; // Eigen value
        public double[] EigenVec; // Eigen Vector Array
        public int size; // Size of Eigen Vector array
        public EvEvec()
        {
        }
        public EvEvec(double Ev, double[] Evc, int sz)
        {
            EigenVec = new double[sz];
            EigenValue = Ev;
            size = sz;
            for (int i = 0; i < sz; i++)
                EigenVec[i] = Evc[i];
            // EVecs are already normalized i.e., magnitude of 1
        }
        public int CompareTo(Object rhs) // for sorting
        {
            EvEvec evv = (EvEvec)rhs; // highest to lowest sorting by Eigen value
            return evv.EigenValue.CompareTo(this.EigenValue);
        }
        public object Clone() // for making a copy of the EvEvec object
        {
            EvEvec clone = new EvEvec();
            clone.EigenValue = this.EigenValue;
            if (this.EigenVec != null)
                clone.EigenVec = (double[])this.EigenVec.Clone();
            clone.size = this.size;
            return clone;
        }
    }
}