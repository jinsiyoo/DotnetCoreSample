using System.Collections.Generic;
using System.Data;

namespace DotnetCoreSample.Web.Provider.Interface
{
	public interface ISqlWrite{
		/// <summary>
		/// 寫入資料
		/// (回傳寫入資料筆數)
		/// </summary>
		/// <param name="insertSql">寫入SQL敘述</param>
		/// <param name="param">寫入資料物件</param>
		/// <returns>寫入資料筆數</returns>
		int Insert(string insertSql, object param);

		/// <summary>
		/// 更新資料
		/// (回傳更新資料筆數)
		/// </summary>
		/// <param name="updateSql">更新SQL敘述</param>
		/// <param name="param">更新資料物件</param>
		/// <returns>更新資料筆數</returns>
		int Update(string updateSql, object param);
	}
}