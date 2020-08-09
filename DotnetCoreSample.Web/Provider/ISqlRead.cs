using System.Collections.Generic;
using System.Data;

namespace DotnetCoreSample.Web.Provider.Interface
{
    public interface ISqlRead<T>
    {
		/// <summary>
		/// 查詢資料
		/// </summary>
		/// <param name="querySql">SQL敘述</param>
		/// <param name="param">查詢參數物件</param>
		/// <param name="commandType">敘述類型</param>
		/// <returns>資料物件</returns>
        IEnumerable<T> Query(string querySql, object param, CommandType commandType);

		/// <summary>
		/// 查詢第一筆資料
        /// (無結果回傳Null)
		/// </summary>
		/// <param name="querySql">SQL敘述</param>
		/// <param name="param">查詢參數物件</param>
		/// <param name="commandType">敘述類型</param>
		/// <returns>資料物件</returns>
		T QueryFirstOrDefault(string querySql, object param, CommandType commandType);
    }
}