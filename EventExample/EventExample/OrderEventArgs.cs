using System;

namespace EventExample
{
    /// <summary>
    /// 事件参数
    /// </summary>
    public class OrderEventArgs:EventArgs
    {
        /// <summary>
        /// 菜名
        /// </summary>
        public string NameOfCourse { get; set; }
        /// <summary>
        /// 份数
        /// </summary>
        public int  Count{ get; set; }
    }
}