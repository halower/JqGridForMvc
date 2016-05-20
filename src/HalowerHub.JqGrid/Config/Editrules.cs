using Newtonsoft.Json;

namespace HalowerHub.JqGrid
{
    /// <summary>
    /// 编辑验证规则,是作为jqGrid提供的表单验证的规则，类似正则表达式
    /// </summary>
    public class EditRules
    {
        private string _customfunc;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="required"></param>
        /// <param name="edithidden">只在Form Editing模式下有效，设置为true，就可以让隐藏字段也可以修</param>
        /// <param name="number">设置为true，如果输入值不是数字或者为空，则会报错</param>
        /// <param name="integer"> 是否整数</param>
        /// <param name="minValue">最小值</param>
        /// <param name="maxValue">最大值</param>
        /// <param name="email">是否合法的邮件</param>
        /// <param name="url">检查是不是合法的URL地址</param>
        /// <param name="date">设置为true，输入内容格式需要满足日期格式要求（使用ISO格式，”Y-m-d“），否则将会显示一个错误信息。</param>
        /// <param name="time">设置为true，输入内容格式需要满足时间格式要求，否则将会显示一个错误信息。 目前仅支持”hh:mm“和后接可选的 am/pm 时间格式</param>
        /// <param name="customfun">函数名,函数需要返回一个数组包含以下项目 第一项：true/false，指定验证是否成功 第二项：当第一项为false有效，显示给用户的错误信息。 格式如：[false,”Please enter valid value”]</param>
        public EditRules(bool required=false,bool edithidden=false, bool number = false, bool integer = false, double? minValue = null ,double? maxValue=null,bool email=false, bool url= false, bool date= false, bool time= false, string customfun=null)
        {
            Required = required;
            Edithidden = edithidden;
            Number = number;
            Integer = integer;
            MinValue = minValue;
            MaxValue = maxValue;
            Email = email;
            Url = url;
            Date = date;
            Time = time;
            CustomFunc = customfun;
        }
        /// <summary>
        /// 设置编辑的时候是否可以为空（是否是必须的）。
        /// </summary>
        [JsonProperty("required")]
        public bool Required { get; set; }
        /// <summary>
        /// 只在Form Editing模式下有效，设置为true，就可以让隐藏字段也可以修
        /// </summary>
        [JsonProperty("edithidden")]
        public bool Edithidden { get; set; }
        /// <summary>
        /// 设置为true，如果输入值不是数字或者为空，则会报错
        /// </summary>
        [JsonProperty("number")]
        public bool Number { get; set; }
        /// <summary>
        /// 是否整数
        /// </summary>
        [JsonProperty("integer")]
        public bool Integer { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        [JsonProperty("minValue")]
        public double? MinValue { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        [JsonProperty("maxValue")]
        public double? MaxValue { get; set; }

        /// <summary>
        /// 是否合法的邮件
        /// </summary>
        [JsonProperty("email")]
        public bool Email { get; set; }

        /// <summary>
        /// 检查是不是合法的URL地址
        /// </summary>
        [JsonProperty("url")]
        public bool Url { get; set; }

        /// <summary>
        /// 设置为true，输入内容格式需要满足日期格式要求（使用ISO格式，”Y-m-d“），否则将会显示一个错误信息。
        /// </summary>
        [JsonProperty("date")]
        public bool Date { get; set; }

        /// <summary>
        /// 设置为true，输入内容格式需要满足时间格式要求，否则将会显示一个错误信息。 目前仅支持”hh:mm“和后接可选的 am/pm 时间格式
        /// </summary>
        [JsonProperty("time")]
        public bool Time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("custom")]
        internal bool Custom { get; set; }

        /// <summary>
        /// 函数需要返回一个数组包含以下项目 第一项：true/false，指定验证是否成功 第二项：当第一项为false有效，显示给用户的错误信息。 格式如：[false,”Please enter valid value”]
        /// </summary>
        [JsonProperty("custom_func")]
        public string CustomFunc {
            get
            {
                return _customfunc;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Custom = true;
                    _customfunc = value;
                }
            }
        }
    }
}

/*
Edithidden：只在Form Editing模式下有效，设置为true，就可以让隐藏字段也可以修改。
    required：设置编辑的时候是否可以为空（是否是必须的）。
    Number：设置为true，如果输入值不是数字或者为空，则会报错。
    Integer：是否整数
    minValue：最大值
    maxValue：最小值
    Email：是否合法的邮件
    Url：检查是不是合法的URL地址。
    date：
    time：
    custom：设置为true，则会通过一个自定义的js函数来验证。函数定义在custom_func中。
    custom_func:传递给函数的值一个是需要验证value
*/
