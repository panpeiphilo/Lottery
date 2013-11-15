using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using NPOI.SS.UserModel;

namespace Philo.Common.PNpoi
{
    public class ExcelHelper
    {
        /// <summary>
        /// 读取路径中的excel信息
        /// </summary>
        /// <param name="filePath">excel路径</param>
        /// <param name="message">返回的消息</param>
        /// <param name="error">是否成功</param>
        /// <returns></returns>
        public static DataTable ReadExcel(string filePath, ref string message, ref bool error)
        {
            error = false;
            DataTable table = new DataTable();
            try
            {
                FileStream file = new FileStream(filePath, FileMode.Open);
                //根据路径通过已存在的excel来创建HSSFWorkbook，即整个excel文档
                IWorkbook workbook = WorkbookFactory.Create(file);

                //获取excel的第一个sheet
                ISheet sheet = workbook.GetSheet("LotteryList");


                //获取sheet的首行
                IRow headerRow = sheet.GetRow(0);

                //一行最后一个方格的编号 即总的列数
                int cellCount = headerRow.LastCellNum;

                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    table.Columns.Add(column);
                }
                //最后一列的标号  即总的行数
                int rowCount = sheet.LastRowNum;

                for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();

                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                            dataRow[j] = row.GetCell(j).ToString();
                    }

                    table.Rows.Add(dataRow);
                }

                workbook = null;
                sheet = null;

                error = true;
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return table;
        }

        /// <summary>
        /// 更新Excel表格（格式必须一样）
        /// </summary>
        /// <param name="source">源数据</param>
        /// <param name="filepath">excel文件</param>
        /// <param name="error">是否错误</param>
        /// <param name="message">错误消息</param>
        /// <returns>更新的条数</returns>
        public static int UpdateExcel(DataTable source, string filepath, ref bool error, ref string message)
        {
            return 0;
        }

        /// <summary>
        /// 插入Excel表格（格式必须一样）
        /// </summary>
        /// <param name="source">源数据</param>
        /// <param name="filepath">excel文件</param>
        /// <param name="error">是否错误</param>
        /// <param name="message">错误消息</param>
        /// <returns>插入成功的条数</returns>
        public static int InsertExcel(DataTable source, string filepath, ref bool error, ref string message)
        {
            return 0;
        }

      
        /// <summary>
        /// 新建Excel表格
        /// </summary>
        /// <param name="source">源数据</param>
        /// <param name="filepath">excel文件</param>
        /// <param name="sheetName">页名</param>
        /// <param name="error">是否错误</param>
        /// <param name="message">错误消息</param>
        /// <returns>插入成功的条数</returns>
        public static int CreateExcel(DataTable source, string filepath, string sheetName, ref bool error, ref string message)
        {
            return 0;
        }
    }
}
