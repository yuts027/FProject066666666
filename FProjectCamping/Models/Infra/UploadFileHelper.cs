using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FProjectCamping.Models.Infra
{
	public interface IFileValidator
	{
		void Validate(HttpPostedFileBase file); //若失敗就回傳錯誤訊息


	}
	public class UploadFileHelper
	{
		public static string Save(HttpPostedFileBase file, string path, IFileValidator[] validators)
		{
			//驗證檔案
			if (validators != null)
			{
				foreach (var validator in validators)
				{
					validator.Validate(file);
				}
			}

			//如果沒有檔案,就結束
			if (file == null || file.ContentLength == 0) return string.Empty;

			//取得一個隨機檔案名
			string ext = Path.GetExtension(file.FileName);
			string fileName = Path.GetRandomFileName() + ext;
			string fullpath = Path.Combine(path, fileName);
			file.SaveAs(fullpath);

			return fileName;
		}
	}
}