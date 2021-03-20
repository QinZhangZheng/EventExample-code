using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Customer
    {
        /// <summary>
        /// 账单金额
        /// </summary>
        public string Bill { get; set; }
        /// <summary>
        /// 支付账单
        /// </summary>
        public void PayTheBill()
        {
            Console.WriteLine($"付了{this.Bill}元钱");
        }
    }
}
