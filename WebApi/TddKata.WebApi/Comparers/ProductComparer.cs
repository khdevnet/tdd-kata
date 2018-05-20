using System;
using System.Collections.Generic;
using TddKata.WebApi.Data.Entities;

namespace TddKata.WebApi.Comparers
{
    public class ProductComparer : IEqualityComparer<Product>
    {
        private int xid;
        private int yid;

        public bool Equals(Product x, Product y)
        {

            if (x == y || x == null || y == null)
            {
                return false;
            }

            xid = x.Id;
            yid = y.Id;

            return x.Id == y.Id
                && x.Name == y.Name
                && x.Price == y.Price;
        }

        public int GetHashCode(Product product)
        {
            return ShiftAndWrap(xid.GetHashCode(), 2) ^ yid.GetHashCode();
        }

        private int ShiftAndWrap(int value, int positions)
        {
            positions = positions & 0x1F;

            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            uint wrapped = number >> (32 - positions);
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }
    }
}