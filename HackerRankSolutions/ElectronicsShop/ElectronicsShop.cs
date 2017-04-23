using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.ElectronicsShop
{
    /// <summary>
    /// Provides a solution to https://www.hackerrank.com/challenges/electronics-shop?h_r=next-challenge&h_v=zen
    /// 
    /// The problem amounts to maximizing A[i] + B[j] for 
    /// 
    /// A = { A[0], ..., A[n-1] }, 0 <= i < n
    /// B = { B[0], ..., B[m-1] }, 0 <= j < m
    /// 
    /// This is a brute force, O((m * n) * log(m * n)) solution that passes the loose performance constraints
    /// </summary>
    public static class ElectronicsShop
    {
        public static int MoneySpent(int s, int[] kybd, int[] usb)
        {
            var query =
                (
                 from x in kybd
                 from y in usb
                 where (x + y) <= s
                 orderby (x + y) descending
                 select (x + y)
                 );
            return query.Any() ? query.First() : -1;
        }

    }
}
