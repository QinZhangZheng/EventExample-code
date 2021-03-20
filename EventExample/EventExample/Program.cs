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
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            customer.Action();
        }
    }
    /// <summary>
    /// 声明一个委托
    /// </summary>
    /// <param name="customer">顾客类</param>
    /// <param name="e"></param>
    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);
    /// <summary>
    /// 顾客类
    /// </summary>
    public class Customer
    {
        private OrderEventHandler orderEventHandler;

        public event OrderEventHandler Order
        {
            add
            {
                this.orderEventHandler += value;
            }
            remove
            {
                this.orderEventHandler -= value;
            }

        }
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
        /// <summary>
        /// 思考
        /// </summary>
        public void Think()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("思考中...");
                System.Threading.Thread.Sleep(500);
            }
            if (orderEventHandler!=null)
            {
                OrderEventArgs e = new OrderEventArgs();
                Console.WriteLine("吃什么？");
                e.NameOfCourse = Console.ReadLine();
                Console.WriteLine("吃几份?");
                e.Count = int.Parse(Console.ReadLine());
                this.orderEventHandler.Invoke(this, e);
            }
        }

        internal void Action()
        {
            Console.ReadKey();
            Think();
            PayTheBill();
        }
    }
    /// <summary>
    /// 服务员类
    /// </summary>
    public class Waiter
    {
        internal void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine($"我要吃{e.NameOfCourse},要{e.Count}份");
            double price = 15;//所有菜15元
            double total = price * e.Count;
            customer.Bill += total;
        }
    }
}
