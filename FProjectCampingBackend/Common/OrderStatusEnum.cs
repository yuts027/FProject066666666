using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FProjectCamping.Common
{
    public enum OrderStatusEnum
    {
        /// <summary>
        /// 尚未付款
        /// </summary>
        [Display(Name = "尚未付款")]
        Wait = 1,

        /// <summary>
        /// 付款完成
        /// </summary>
        [Display(Name = "付款完成")]
        Payment,

        /// <summary>
        /// 付款失敗
        /// </summary>
        [Display(Name = "付款失敗")]
        Failed,

        /// <summary>
        /// 取消訂單
        /// </summary>
        [Display(Name = "取消訂單")]
        Cancel,

        /// <summary>
        /// 完成訂單
        /// </summary>
        [Display(Name = "完成訂單")]
        Completed,
    }
}