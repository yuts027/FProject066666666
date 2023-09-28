using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FProjectCamping.Models.ViewModels.Orders
{
    public class PayOrderVm
    {
        /// <summary>
        /// Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 訂單編號
        /// </summary>
        [Display(Name = "訂單編號")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// 訂單日期
        /// </summary>
        [Display(Name = "訂單日期")]
        public string OrderTime { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        [Display(Name = "付款方式")]
        public string PaymentType { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        [Display(Name = "金額")]
        [DisplayFormat(DataFormatString = "{0:#,#}")]
        public int TotalPrice { get; set; }

        /// <summary>
        /// 訂單狀態
        /// </summary>
        [Display(Name = "訂單狀態")]
        public string Status { get; set; }

        /// <summary>
        /// 訂單狀態
        /// </summary>
        public int StatusEnum { get; set; }

        /// <summary>
        /// 訂購人姓名
        /// </summary>
        [Display(Name = "訂購人姓名")]
        public string Name { get; set; }

        // <summary>
        /// 訂購人電子郵件
        /// </summary>
        [Display(Name = "訂購人電子郵件")]
        public string Email { get; set; }

        // <summary>
        /// 訂購人電話
        /// </summary>
        [Display(Name = "訂購人電話")]
        public string PhoneNum { get; set; }

        public List<OrderItems> OrderItems { get; set; }
    }
}