using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FProjectCamping.Models.Infra.FileValidators
{
	public class FileRequired : IFileValidator
	{
		public void Validate(HttpPostedFileBase file)
		{
			if (file == null || file.ContentLength == 0)
			{
				throw new Exception("請選擇檔案");
			}
		}
	}
	public class ImageValidator : IFileValidator
	{
		public void Validate(HttpPostedFileBase file)
		{
			if (file == null || file.ContentLength == 0)
			{
				return;
			}

			string[] imgExts = { ".jpg", ".jpeg", ".png" };
			string ext = Path.GetExtension(file.FileName).ToLower();

			if (!imgExts.Contains(ext))
			{
				throw new Exception("請上傳有效的圖片文件");
			}

		}
	}


}