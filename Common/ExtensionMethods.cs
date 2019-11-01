using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Dynamic;
using System.Reflection;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExtensionMethods
    {
        #region 数据转换
        public static int ToInt(this object obj)
        {
            return CommonHelper.ObjToInt(obj);
        }

        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(this string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }
        /// <summary>
        /// 判断字符串中是否包含操作型特殊字符
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static bool ProcessSqlStr(this string Str)
        {
            bool ReturnValue = true;
            try
            {
                if (Str.Trim() != "")
                {
                    string SqlStr = "exec|insert+|select+|delete|update|count|chr|mid|master+|truncate|char|declare|drop+|drop+table|creat+|create|*|iframe|script|";
                    SqlStr += "exec+|insert|delete+|update+|count(|count+|chr+|+mid(|+mid+|+master+|truncate+|char+|+char(|declare+|drop+table|creat+table";
                    string[] anySqlStr = SqlStr.Split('|');
                    foreach (string ss in anySqlStr)
                    {
                        if (Str.ToLower().IndexOf(ss) >= 0)
                        {
                            ReturnValue = false;
                            break;
                        }
                    }
                }
            }
            catch
            {
                ReturnValue = false;
            }
            return ReturnValue;
        }
        public static int ToInt(this object obj, int defaultValue)
        {
            if (CommonHelper.ObjToInt(obj) == 0)
                return defaultValue;
            return CommonHelper.ObjToInt(obj);
        }
        /// <summary>
        /// 转为C#时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime ToDateC(this DateTime time)
        {
            Int64 dt = new DateTime(1970, 1, 1).Ticks;
            Int64 longTime = time.Ticks - dt;
            return new DateTime(longTime += dt).ToLocalTime();
        }
        public static string ToStr(this object obj)
        {
            return CommonHelper.ObjToStr(obj);
        }

        public static decimal ToDecimal(this object obj)
        {
            return CommonHelper.ObjToDecimal(obj);
        }


        public static int? ToIntNull(this object obj)
        {
            return CommonHelper.ObjToIntNull(obj);
        }

        public static decimal? ToDecimalNull(this object obj)
        {
            return CommonHelper.ObjToDecimalNull(obj);
        }

        public static bool ToBool(this object obj)
        {
            return CommonHelper.ObjToBool(obj);
        }

        /// <summary>
        /// 获得一个字符串的汉语拼音码[南京 yyf]
        /// </summary>
        /// <param name="strText">字符串</param>
        /// <returns>汉语拼音码,该字符串只包含大写的英文字母</returns>
        public static string ToChineseSpell(this string strText)
        {
            return ChineseSpell.GetChineseSpell(strText);
        }

        /// <summary>
        /// 性别格式化
        /// eg:男：M(MR)，女：F(MS)
        /// </summary>
        /// <param name="sex"></param>
        /// <param name="isTH">泰航机票格式</param>
        /// <returns></returns>
        public static string ToEnSex(this string sex, bool isTH = false)
        {
            return sex.IndexOf('男') > -1 ? (isTH ? "MR" : "M") : (sex.IndexOf('女') > -1 ? (isTH ? "MS" : "F") : "");
        }

        /// <summary>
        /// 格式化时间
        /// eg:1983-08-24,format:'ddMMMyy',result:24Aug83
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToInvariantInfoString(this DateTime? date, string format = "ddMMMyy")
        {
            if (date == null)
                return "";
            return date.Value.ToString(format, System.Globalization.DateTimeFormatInfo.InvariantInfo);
        }

        /// <summary>
        /// 把汉字转化为拼音
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string ChangeChangChineseSpell(this string strText)
        {
            return ChineseSpell.ChangChineseSpell(strText);
        }

        /// <summary>
        /// 格式化Sql字符串的值
        /// </summary>
        /// <param name="stringValue"></param>
        /// <returns></returns>
        public static string FormatSqlStringValue(this string stringValue)
        {
            return stringValue.Trim().Replace("'", "''");
        }

        public static string FormatJSStringValue(this string stringValue)
        {
            return stringValue.Trim().Replace("'", "\\'");
        }

        /// <summary>
        /// 格式化报表传参数中的encodeURI将+号编码成了空格
        /// </summary>
        /// <param name="stringValue"></param>
        /// <returns></returns>
        public static string FormatURIStr(this string stringValue)
        {
            return stringValue.Trim().Replace(" ", "+");
        }
        /// <summary>
        /// 将ansi字符串格式化成html字符
        /// </summary>
        /// <param name="stringValue"></param>
        /// <returns></returns>
        public static string FormatHtmlStr(this string stringValue)
        {

            return stringValue.Replace("\n", "<br>").Replace(" ", "&nbsp;").Replace("\r", "<br/>");
        }

        /// <summary>
        /// 格式化json字符串中特殊字符
        /// </summary>
        /// <param name="stringValue"></param>
        /// <returns></returns>
        public static string FormatJSONStr(this string stringValue)
        {
            return stringValue.Replace("\\t", " ").Replace("\\", "").Replace("\\r", "").Replace("\\n", "");
        }

        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? ToDateNull(this object obj)
        {
            return CommonHelper.ObjToDateNull(obj);
        }

        public static double ToDouble(this decimal value)
        {
            return Convert.ToDouble(value);
        }


        //加到类的定义部分 
        private static string[] cstr = { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
        private static string[] wstr = { "", "", "十", "百", "千", "万", "十", "百", "千", "亿", "十", "百", "千" };
        //数字必须在12位整数以内的字符串 
        //调用方式如：text=ConvertToChineseNumber("数字字符串"); 

        public static string ConvertToChineseNumber(string str)
        {
            int len = str.Length;
            int i;
            string tmpstr, rstr;
            rstr = "";
            for (i = 1; i <= len; i++)
            {
                tmpstr = str.Substring(len - i, 1);
                rstr = string.Concat(cstr[int.Parse(tmpstr)] + wstr[i], rstr);
            }
            rstr = rstr.Replace("十零", "十");
            rstr = rstr.Replace("零十", "零");
            rstr = rstr.Replace("零百", "零");
            rstr = rstr.Replace("零千", "零");
            rstr = rstr.Replace("零万", "万");
            for (i = 1; i <= 6; i++)
                rstr = rstr.Replace("零零", "零");
            rstr = rstr.Replace("零万", "零");
            rstr = rstr.Replace("零亿", "亿");
            rstr = rstr.Replace("零零", "零");
            return rstr;
        }
        #endregion

        public static string DisplayName(this Enum e)
        {
            var displayAttr = e.GetType().GetMember(e.ToString()).First().GetCustomAttributes(typeof(DisplayNameAttribute), true);
            if (displayAttr.Length <= 0) return e.ToString();
            return ((DisplayNameAttribute)displayAttr[0]).DisplayName;
        }
        //根据身份证获取年龄
        public static int GetAgeFromIDCode(string IDCode)
        {
            var len = IDCode.Length; // 身份证编码长度
            if (len != 18)
                return 0;
            var date1 = DateTime.Now; // 取得当前日期
            var year1 = date1.Year; // 取得当前年份
            var month1 = date1.Month; // 取得当前月份
            var age = 0;
            age = year1 - IDCode.Substring(6, 4).ToInt();
            return age;
        }
        //根据身份证获取出生日期
        public static string GetBirthdayFromIDCode(string IDCode)
        {
            var len = IDCode.Length; // 身份证编码长度
            if (len != 18)
                return "";

            var birthday = IDCode.Substring(6, 4) + '-' + IDCode.Substring(10, 2) + '-' + IDCode.Substring(12, 2);
            return birthday;
        }

        //根据身份证获取性别
        public static string GetSexFromIDCode(string IDCode)
        {
            var len = IDCode.Length; // 身份证编码长度
            if (len != 18)
                return "";
            int age = IDCode.Substring(16, 1).ToInt() % 2;
            if (age == 0)
                return "女";
            else
                return "男";
        }
    }


    public static class DataTableExtention
    {
        public static T Fill<T>(this DataTable dataTable)
        {

            if (dataTable == null || dataTable.Rows.Count <= 0) return default(T);
            T result = Activator.CreateInstance<T>();
            foreach (var pi in typeof(T).GetProperties())
            {
                if (dataTable.Rows[0].Table.Columns.Contains(pi.Name) && dataTable.Rows[0][pi.Name] != null && dataTable.Rows[0][pi.Name] != DBNull.Value)
                {
                    pi.SetValue(result, dataTable.Rows[0][pi.Name], null);
                }
            }
            return result;
        }
        /// <summary>
        /// 对象转换，对应属性转换到另一个对象
        /// </summary>
        /// <typeparam name="D">目标数据类型</typeparam>
        /// <typeparam name="S">本身数据类型</typeparam>
        /// <param name="removeProperty">排除的属性,','分割属性</param>
        /// <param name="deafult">是否初始化属性值</param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static D Mapper<D, S>(this S s, string removeProperty = "", bool deafult = false)
        {
            D d = Activator.CreateInstance<D>();
            string[] propertys = null;
            bool IsRemove = removeProperty.Trim() != "";
            if (IsRemove) propertys = removeProperty.Split(',');
            try
            {
                var Types = s.GetType();//获得类型  
                var Typed = typeof(D);
                foreach (PropertyInfo sp in Types.GetProperties())//获得类型的属性字段  
                {

                    foreach (PropertyInfo dp in Typed.GetProperties())
                    {
                        if (dp.Name == sp.Name)//判断属性名是否相同  
                        {
                            if (IsRemove && propertys.Contains(sp.Name))
                            {
                                if (deafult)
                                {
                                    if (sp.PropertyType == typeof(string) || sp.PropertyType == typeof(String)) dp.SetValue(d, "", null);//赋值
                                    if (sp.PropertyType == typeof(int) || sp.PropertyType == typeof(decimal)) dp.SetValue(d, 0, null);//赋值
                                }
                                break;
                            }
                            dp.SetValue(d, sp.GetValue(s, null), null);//获得s对象属性的值复制给d对象的属性  
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return d;
        }
        /// <summary>
        /// 对象转换，对应属性转换到另一个对象
        /// </summary>
        /// <typeparam name="D">目标数据类型</typeparam>
        /// <typeparam name="S">本身数据类型</typeparam>
        /// <param name="containsProperty">指定属性映射</param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static D Mapper<D, S>(this S s, ref D d, string containsProperty = "")
        {
            string[] propertys = null;
            bool Contains = containsProperty.Trim() != "";
            if (Contains) propertys = containsProperty.Split(',');
            try
            {
                var Types = s.GetType();//获得类型  
                var Typed = typeof(D);
                foreach (PropertyInfo sp in Types.GetProperties())//获得类型的属性字段  
                {
                    if (Contains && propertys.Contains(sp.Name))
                    {
                        foreach (PropertyInfo dp in Typed.GetProperties())
                        {
                            if (dp.Name == sp.Name)//判断属性名是否相同  
                            {
                                dp.SetValue(d, sp.GetValue(s, null), null);//获得s对象属性的值复制给d对象的属性  
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return d;
        }
        public static IList<T> FillList<T>(this System.Data.DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return new List<T>();
            var result = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                T t = Activator.CreateInstance<T>();
                foreach (var pi in typeof(T).GetProperties())
                {
                    if (row.Table.Columns.Contains(pi.Name) && row[pi.Name] != null && row[pi.Name] != DBNull.Value)
                    {
                        DateTime dt;
                        pi.SetValue(t, DateTime.TryParse(row[pi.Name].ToString(), out dt) ? dt : row[pi.Name], null);
                    }
                }
                result.Add(t);
            }
            return result;
        }



        #region
        /// <summary>
        /// 将包含2个主从DataTable(主从表通过foreignKey关联,从表行的displayName列的每行内容对应grid的一列,从valueName中取值)的DataSet转换为动态对象,序列化为Json字符串,构件ligerui grid.
        /// </summary>
        /// <remarks>
        /// eg:SupplierProvince    AdultNum     SupplierCount
        ///             云南省                       5                           5
        ///       SupplierProvince(foreignKey)    ItemType(displayName)     AdultNum     SumBuyMoney(valueName)
        ///              云南省                                                  aa_Itemtype                     5                             5.00
        ///              云南省                                                  bb_Itemtype                     2                             3.00
        /// grid:SupplierProvince   AdultNum     SupplierCount          aa_Itemtype          bb_Itemtype
        ///               云南省                      5                       5                               5.00                       3.00
        /// </remarks>
        /// <param name="ds"></param>
        /// <param name="foreignKey"></param>
        /// <param name="displayName"></param>
        /// <param name="valueName"></param>
        /// <param name="displayColumns"></param>
        /// <returns></returns>
        public static List<dynamic> Translate(this DataSet ds, string foreignKey, string displayName, string valueName, out Dictionary<string, string> displayColumns)
        {
            var result = new List<dynamic>();
            displayColumns = new Dictionary<string, string>();
            string emptyKey = Guid.NewGuid().ToString();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    result.Add(GetColumnAndValue(ds.Tables[0].Columns, row, ds.Tables[1], foreignKey, displayName, valueName, displayColumns, emptyKey));
                }
            }

            return result;
        }

        private static dynamic GetColumnAndValue(DataColumnCollection columns, DataRow row, DataTable dt2, string foreignKey, string displayName, string valueName, Dictionary<string, string> displayColumns, string emptyKey)
        {
            displayColumns = displayColumns != null ? displayColumns : new Dictionary<string, string>();
            var obj = new ExpandoObject() as IDictionary<string, object>;


            foreach (DataColumn column in columns)
            {
                obj[column.ColumnName] = ToFormat(row[column.ColumnName]);
            }

            if (dt2 != null)
            {
                var dt2Rows = dt2.AsEnumerable().Where(dt => dt.Field<object>(foreignKey).ToStr() == row[foreignKey].ToStr()).Distinct();
                foreach (var dt2Row in dt2Rows)
                {
                    string key = dt2Row[displayName].ToStr(), valuekey = string.IsNullOrWhiteSpace(key) ? emptyKey : key;

                    key = string.IsNullOrWhiteSpace(key) ? "其他(空类型)" : key;
                    if (!displayColumns.ContainsKey(key)) displayColumns.Add(key, valuekey);

                    if (!obj.ContainsKey(valuekey)) obj[valuekey] = ToFormat(dt2Row[valueName]);
                }
            }

            return obj;
        }

        private static object ToFormat(object obj)
        {
            if (obj.GetType().IsValueType && !typeof(DateTime).IsAssignableFrom(obj.GetType())) return Convert.ToDecimal(obj).ToString("0.##");
            // if (new Regex(@"\d+|(\d+[.]\d+)").IsMatch(obj.ToString())) return ((decimal)obj).ToString("0.##");
            if (typeof(DateTime).IsAssignableFrom(obj.GetType())) return Convert.ToDateTime(obj).ToString("yyyy/MM/dd");

            return obj;
        }

        #endregion

    }

}
